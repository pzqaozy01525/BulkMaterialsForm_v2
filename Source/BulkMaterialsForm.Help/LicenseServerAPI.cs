// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.LicenseServerAPI

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BulkMaterialsForm.Help;

public class LicenseServerAPI
{
	private const string SecretKey = "zF9D4Be8z4yURef5";

	private static string GetServerUrl()
	{
		return MainData.ServerIP;
	}

	private static string GetClientId()
	{
		return MainData.khdId;
	}

	private static string ComputeSign(string datestmp)
	{
		return MD5Encrypt(GetClientId() + datestmp + "zF9D4Be8z4yURef5");
	}

	private static string MD5Encrypt(string input)
	{
		byte[] array = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(input));
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			stringBuilder.Append(b.ToString("x2"));
		}
		return stringBuilder.ToString().ToLower();
	}

	private static IRestResponse PostForm(string endpoint, Dictionary<string, object> data)
	{
		string serverUrl = GetServerUrl();
		if (string.IsNullOrEmpty(serverUrl))
		{
			throw new InvalidOperationException("未配置 ServerIP，请在 formRKpz.ini 中添加配置项");
		}
		string text = serverUrl.TrimEnd('/') + endpoint;
		RestClient restClient = new RestClient(text);
		RestRequest restRequest = new RestRequest(Method.POST);
		restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
		data["clientId"] = GetClientId();
		data["datestmp"] = DateTime.Now.ToString("yyyyMMddHHmmss");
		data["sign"] = ComputeSign(data["datestmp"].ToString());
		string text2 = string.Join("&", data.Select((KeyValuePair<string, object> kv) => Uri.EscapeDataString(kv.Key) + "=" + Uri.EscapeDataString(kv.Value?.ToString() ?? "")));
		restRequest.AddParameter("application/x-www-form-urlencoded", text2, ParameterType.RequestBody);
		LogSave.SaveExeLog("[LicenseServerAPI] POST " + text);
		LogSave.SaveExeLog("[LicenseServerAPI] Request: " + text2);
		IRestResponse restResponse = restClient.Execute(restRequest);
		LogSave.SaveExeLog("[LicenseServerAPI] Response: " + restResponse.Content);
		return restResponse;
	}

	private static T? ParseResponse<T>(IRestResponse response) where T : class
	{
		if (response.ResponseStatus != ResponseStatus.Completed || string.IsNullOrEmpty(response.Content))
		{
			return null;
		}
		JObject jObject = JObject.Parse(response.Content);
		JToken jToken = jObject["code"];
		if (jToken == null || jToken.Value<int>() != 1)
		{
			return null;
		}
		JToken jToken2 = jObject["data"];
		if (jToken2 == null)
		{
			return null;
		}
		return jToken2.ToObject<T>();
	}

	public static bool UploadWhiteList(tb_car_info record)
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["type"] = ((record.bz == "黑名单") ? "2" : "1"),
				["license"] = record.car_no ?? "",
				["licenseColor"] = GetLicenseColorCode(record.car_no),
				["owner"] = record.name ?? "",
				["phone"] = record.phone ?? "",
				["dep"] = record.dep ?? "",
				["bz"] = record.bz ?? ""
			};
			JObject jObject = JObject.Parse(PostForm("/api/client/whitelist", data).Content ?? "{}");
			JToken jToken = jObject["code"];
			if (jToken != null && jToken.Value<int>() == 1)
			{
				return true;
			}
			LogSave.SaveExeLog(string.Format("[LicenseServerAPI] UploadWhiteList failed: {0}", jObject["message"]));
			return false;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] UploadWhiteList exception: " + ex.Message);
			return false;
		}
	}

	public static int BatchUploadWhiteList(IEnumerable<tb_car_info> records, Action<int, int> progressCallback = null)
	{
		int num = 0;
		int num2 = 0;
		foreach (tb_car_info record in records)
		{
			num2++;
			if (UploadWhiteList(record))
			{
				num++;
			}
			progressCallback?.Invoke(num, num2);
		}
		return num;
	}

	public static List<WhiteListRecordDto> QueryWhiteList(string type = null, string license = null, int page = 1, int pageSize = 50)
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["type"] = type ?? "",
				["license"] = license ?? "",
				["page"] = page.ToString(),
				["pageSize"] = pageSize.ToString()
			};
			JObject jObject = JObject.Parse(PostForm("/api/client/whitelist/query", data).Content ?? "{}");
			JToken jToken = jObject["code"];
			if (jToken != null && jToken.Value<int>() == 1)
			{
				return (jObject["data"]?["data"])?.ToObject<List<WhiteListRecordDto>>() ?? new List<WhiteListRecordDto>();
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] QueryWhiteList exception: " + ex.Message);
		}
		return new List<WhiteListRecordDto>();
	}

	public static bool DeleteWhiteList(List<int> ids)
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["ids"] = string.Join(",", ids)
			};
			JToken jToken = JObject.Parse(PostForm("/api/client/whitelist/delete", data).Content ?? "{}")["code"];
			return jToken != null && jToken.Value<int>() == 1;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] DeleteWhiteList exception: " + ex.Message);
			return false;
		}
	}

	public static bool UploadCarRecord(VehicleNoInfoView record)
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["serialNum"] = record.serialNum ?? "",
				["license"] = record.VehicleNo ?? "",
				["licenseColor"] = record.licenseColor ?? "",
				["channelName"] = record.ChannelName ?? "",
				["channelType"] = record.ChannelType ?? "",
				["channelId"] = record.ChannelId.ToString(),
				["deviceId"] = record.devId.ToString(),
				["deviceName"] = record.DeviceName ?? "",
				["fuelType"] = record.fuelType ?? "",
				["emissionStandard"] = record.emissionStandard ?? "",
				["cargoName"] = record.channel?.ChannelType ?? "",
				["imagePath"] = record.ImagePath ?? "",
				["addTime"] = record.AddTime.ToString("yyyy-MM-dd HH:mm:ss")
			};
			JObject jObject = JObject.Parse(PostForm("/api/client/car-record", data).Content ?? "{}");
			JToken jToken = jObject["code"];
			if (jToken != null && jToken.Value<int>() == 1)
			{
				return true;
			}
			LogSave.SaveExeLog(string.Format("[LicenseServerAPI] UploadCarRecord failed: {0}", jObject["message"]));
			return false;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] UploadCarRecord exception: " + ex.Message);
			return false;
		}
	}

	public static List<CarRecordDto> QueryCarRecord(string license = null, string channelType = null, DateTime? startDate = null, DateTime? endDate = null, int page = 1, int pageSize = 50)
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["license"] = license ?? "",
				["channelType"] = channelType ?? "",
				["startDate"] = startDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
				["endDate"] = endDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
				["page"] = page.ToString(),
				["pageSize"] = pageSize.ToString()
			};
			JObject jObject = JObject.Parse(PostForm("/api/client/car-record/query", data).Content ?? "{}");
			JToken jToken = jObject["code"];
			if (jToken != null && jToken.Value<int>() == 1)
			{
				return (jObject["data"]?["data"])?.ToObject<List<CarRecordDto>>() ?? new List<CarRecordDto>();
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] QueryCarRecord exception: " + ex.Message);
		}
		return new List<CarRecordDto>();
	}

	public static (bool Success, string Message) CreateTransportLedger(string serialNum, string transportType, string inCargoName, string inCargoWeight, string inTime, string inSupplier, string inReceiver, string inChannelName, string outCargoName, string outCargoWeight, string outTime, string outSupplier, string outReceiver, string outChannelName, string grossWeight, string tareWeight, string netWeight, string scaleTime, string remark = "")
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["serialNum"] = serialNum,
				["transportType"] = transportType,
				["inCargoName"] = inCargoName ?? "",
				["inCargoWeight"] = inCargoWeight ?? "",
				["inTime"] = inTime ?? "",
				["inSupplier"] = inSupplier ?? "",
				["inReceiver"] = inReceiver ?? "",
				["inChannelName"] = inChannelName ?? "",
				["outCargoName"] = outCargoName ?? "",
				["outCargoWeight"] = outCargoWeight ?? "",
				["outTime"] = outTime ?? "",
				["outSupplier"] = outSupplier ?? "",
				["outReceiver"] = outReceiver ?? "",
				["outChannelName"] = outChannelName ?? "",
				["grossWeight"] = grossWeight ?? "",
				["tareWeight"] = tareWeight ?? "",
				["netWeight"] = netWeight ?? "",
				["scaleTime"] = scaleTime ?? "",
				["remark"] = remark ?? ""
			};
			JObject jObject = JObject.Parse(PostForm("/api/client/ledger/transport", data).Content ?? "{}");
			int? num = jObject["code"]?.Value<int>();
			string item = jObject["message"]?.Value<string>() ?? "未知错误";
			if (num == 1)
			{
				return (Success: true, Message: item);
			}
			return (Success: false, Message: item);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] CreateTransportLedger exception: " + ex.Message);
			return (Success: false, Message: ex.Message);
		}
	}

	public static List<TransportLedgerDto> QueryTransportLedger(string vehicleNo = null, string goodsName = null, DateTime? startDate = null, DateTime? endDate = null, int page = 1, int pageSize = 50)
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["vehicleNo"] = vehicleNo ?? "",
				["goodsName"] = goodsName ?? "",
				["startDate"] = startDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
				["endDate"] = endDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
				["page"] = page.ToString(),
				["pageSize"] = pageSize.ToString()
			};
			JObject jObject = JObject.Parse(PostForm("/api/client/ledger/transport/list", data).Content ?? "{}");
			JToken jToken = jObject["code"];
			if (jToken != null && jToken.Value<int>() == 1)
			{
				return (jObject["data"]?["data"])?.ToObject<List<TransportLedgerDto>>() ?? new List<TransportLedgerDto>();
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] QueryTransportLedger exception: " + ex.Message);
		}
		return new List<TransportLedgerDto>();
	}

	public static (bool Success, string Message) CreateSiteVehicleLedger(tb_vehicleInfoV2 v)
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["vehicleNo"] = v.vehicleNo ?? "",
				["licenseColor"] = v.licenseColor ?? "",
				["vehicleType"] = v.vehicleType ?? "",
				["vin"] = v.vin ?? "",
				["fuelType"] = v.fuelType ?? "",
				["emissionStandard"] = v.emissionStandard ?? "",
				["owner"] = v.onwer ?? "",
				["engineNo"] = v.engineNo ?? "",
				["registerDate"] = ((v.registerDate != default(DateTime)) ? v.registerDate.ToString("yyyy-MM-dd") : ""),
				["drivingLicenseImg"] = v.drivingFrontLicenseImg ?? "",
				["accompanyingVehicleImg"] = v.AccompanyingVehicleImg ?? "",
				["remark"] = v.Remark ?? ""
			};
			JObject jObject = JObject.Parse(PostForm("/api/client/ledger/site-vehicle", data).Content ?? "{}");
			int? num = jObject["code"]?.Value<int>();
			string item = jObject["message"]?.Value<string>() ?? "未知错误";
			if (num == 1)
			{
				return (Success: true, Message: item);
			}
			return (Success: false, Message: item);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] CreateSiteVehicleLedger exception: " + ex.Message);
			return (Success: false, Message: ex.Message);
		}
	}

	public static List<SiteVehicleLedgerDto> QuerySiteVehicleLedger(string vehicleNo = null, int page = 1, int pageSize = 50)
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["vehicleNo"] = vehicleNo ?? "",
				["page"] = page.ToString(),
				["pageSize"] = pageSize.ToString()
			};
			JObject jObject = JObject.Parse(PostForm("/api/client/ledger/site-vehicle/list", data).Content ?? "{}");
			JToken jToken = jObject["code"];
			if (jToken != null && jToken.Value<int>() == 1)
			{
				return (jObject["data"]?["data"])?.ToObject<List<SiteVehicleLedgerDto>>() ?? new List<SiteVehicleLedgerDto>();
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] QuerySiteVehicleLedger exception: " + ex.Message);
		}
		return new List<SiteVehicleLedgerDto>();
	}

	public static (bool Success, string Message) CreateNonRoadLedger(tb_vehicleInfoV2 v)
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["vehicleNo"] = v.vehicleNo ?? "",
				["licenseColor"] = v.licenseColor ?? "",
				["emissionStandard"] = v.emissionStandard ?? "",
				["fuelType"] = v.fuelType ?? "",
				["brand"] = v.model ?? "",
				["model"] = v.model ?? "",
				["engineNo"] = v.engineNo ?? "",
				["vehicleType"] = v.vehicleType ?? "",
				["vehicleLicenseImg"] = v.drivingFrontLicenseImg ?? "",
				["engineLicenseImg"] = v.drivingBackLicenseImg ?? "",
				["environmentalLabelImg"] = v.AccompanyingVehicleImg ?? "",
				["remark"] = v.Remark ?? ""
			};
			JObject jObject = JObject.Parse(PostForm("/api/client/ledger/non-road", data).Content ?? "{}");
			int? num = jObject["code"]?.Value<int>();
			string item = jObject["message"]?.Value<string>() ?? "未知错误";
			if (num == 1)
			{
				return (Success: true, Message: item);
			}
			return (Success: false, Message: item);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] CreateNonRoadLedger exception: " + ex.Message);
			return (Success: false, Message: ex.Message);
		}
	}

	public static List<NonRoadLedgerDto> QueryNonRoadLedger(string vehicleNo = null, int page = 1, int pageSize = 50)
	{
		try
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				["tenantId"] = GetClientId(),
				["vehicleNo"] = vehicleNo ?? "",
				["page"] = page.ToString(),
				["pageSize"] = pageSize.ToString()
			};
			JObject jObject = JObject.Parse(PostForm("/api/client/ledger/non-road/list", data).Content ?? "{}");
			JToken jToken = jObject["code"];
			if (jToken != null && jToken.Value<int>() == 1)
			{
				return (jObject["data"]?["data"])?.ToObject<List<NonRoadLedgerDto>>() ?? new List<NonRoadLedgerDto>();
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] QueryNonRoadLedger exception: " + ex.Message);
		}
		return new List<NonRoadLedgerDto>();
	}

	public static List<EnterpriseGoodsTypeDto> GetGoodsTypes()
	{
		try
		{
			RestClient restClient = new RestClient(GetServerUrl().TrimEnd('/') + "/api/client/enterprise/goods-types?tenantId=" + Uri.EscapeDataString(GetClientId()));
			RestRequest request = new RestRequest(Method.GET);
			JObject jObject = JObject.Parse(restClient.Execute(request).Content ?? "{}");
			JToken jToken = jObject["code"];
			if (jToken != null && jToken.Value<int>() == 1)
			{
				return jObject["data"]?.ToObject<List<EnterpriseGoodsTypeDto>>() ?? new List<EnterpriseGoodsTypeDto>();
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("[LicenseServerAPI] GetGoodsTypes exception: " + ex.Message);
		}
		return new List<EnterpriseGoodsTypeDto>();
	}

	private static string GetLicenseColorCode(string carNo)
	{
		if (string.IsNullOrEmpty(carNo))
		{
			return "";
		}
		switch (carNo.Last())
		{
		case 'A':
		case 'B':
		case 'C':
		case 'D':
		case 'E':
			return "1";
		case 'F':
		case 'G':
		case 'H':
		case 'J':
		case 'K':
		case 'L':
		case 'M':
		case 'N':
			return "0";
		default:
			return "";
		}
	}

	public static bool TestConnection()
	{
		try
		{
			string serverUrl = GetServerUrl();
			if (string.IsNullOrEmpty(serverUrl))
			{
				return false;
			}
			return new RestClient(serverUrl.TrimEnd('/') + "/").Execute(new RestRequest(Method.GET)).ResponseStatus == ResponseStatus.Completed;
		}
		catch
		{
			return false;
		}
	}
}
