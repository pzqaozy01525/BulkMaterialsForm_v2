// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.CommonHelper

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.Result;
using BulkMaterialsForm.Model.View;
using Newtonsoft.Json;
using RestSharp;
using SqlSugar;

namespace BulkMaterialsForm.Help;

public class CommonHelper
{
	public static XNCResultModel PoleXNCResultModel(string url, string key, string secret, object values)
	{
		try
		{
			new XNCResultModel();
			string value = JsonConvert.SerializeObject(values);
			RestClient restClient = new RestClient(url);
			restClient.Timeout = -1;
			RestRequest restRequest = new RestRequest(Method.POST);
			string text = DateTimeToStamp(DateTime.Now).ToString();
			restRequest.AddHeader("api-timestamp", text);
			restRequest.AddHeader("api-userkey", key);
			restRequest.AddHeader("api-signature", MD5Encrypt(key + "|" + text + "|" + MD5Encrypt(secret)));
			restRequest.AddHeader("Content-Type", "application/json");
			restRequest.AddParameter("application/json", value, ParameterType.RequestBody);
			IRestResponse restResponse = restClient.Execute(restRequest);
			if (restResponse != null)
			{
				return JsonConvert.DeserializeObject<XNCResultModel>(restResponse.Content);
			}
			return null;
		}
		catch (Exception ex)
		{
			LogSave.XNCLog("消纳场接口异常: " + ex.Message);
			return null;
		}
	}

	public static bool XNCVerify(string license, string licenseColor, string deviceId, string flag, ref string msg)
	{
		bool flag2 = false;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("deviceId", deviceId);
		dictionary.Add("plateNumber", license);
		dictionary.Add("color", licenseColor);
		dictionary.Add("flag", flag);
		LogSave.XNCLog(DateTime.Now.ToString() + "消纳场验证上传" + JsonConvert.SerializeObject(dictionary));
		XNCResultModel xNCResultModel = PoleXNCResultModel("http://42.236.61.123:8802/translator/api/disposalInOutVehicle/pole", MainData.XNCKEY, MainData.XNCSecret, dictionary);
		LogSave.XNCLog(DateTime.Now.ToString() + "消纳场验证上传返回" + JsonConvert.SerializeObject(flag2));
		if (xNCResultModel != null && xNCResultModel.code == 200)
		{
			flag2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(xNCResultModel.data.ToString())["pole"].ToString().Equals("0");
			if (!flag2)
			{
				msg = "车辆禁止通行！";
			}
		}
		else
		{
			flag2 = false;
			msg = "服务器异常,车辆禁止通行！";
		}
		return flag2;
	}

	public static string GetGLResultModel(string url, object values)
	{
		if (string.IsNullOrWhiteSpace(url) || !Uri.TryCreate(url, UriKind.Absolute, out _))
		{
			LogSave.SaveExeLog("高凌接口调用失败：URL 无效 -> " + (url ?? "null"));
			return "";
		}
		string value = JsonConvert.SerializeObject(values);
		RestClient obj = new RestClient(url)
		{
			Timeout = -1
		};
		RestRequest restRequest = new RestRequest(Method.POST);
		LogSave.Log(DateTime.Now.ToString() + url);
		restRequest.AddHeader("Content-Type", "application/json");
		restRequest.AddParameter("application/json", value, ParameterType.RequestBody);
		IRestResponse restResponse = obj.Execute(restRequest);
		if (restResponse != null)
		{
			LogSave.Log(DateTime.Now.ToString() + url + restResponse.Content);
			return restResponse.Content;
		}
		return "";
	}

	public static bool GetKangFengV1Token()
	{
		bool result = false;
		if (DateTime.Now <= MainData.KFV1ServerTime && !string.IsNullOrWhiteSpace(MainData.KFV1Token))
		{
			return true;
		}
		if (string.IsNullOrWhiteSpace(MainData.companyCodeV1) || string.IsNullOrWhiteSpace(MainData.companynumV1) || string.IsNullOrWhiteSpace(MainData.companypasswordV1))
		{
			return false;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("companyCode", MainData.companyCodeV1);
		dictionary.Add("companynum", MainData.companynumV1);
		dictionary.Add("companypassword", MainData.companypasswordV1);
		Dictionary<string, object> kaiFengV1ResultModel = GetKaiFengV1ResultModel(MainData.KFV1ServerIP + "/transport/login", dictionary);
		if (kaiFengV1ResultModel != null && Convert.ToBoolean(kaiFengV1ResultModel["success"]) && kaiFengV1ResultModel["code"].ToString().Equals("200"))
		{
			dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(kaiFengV1ResultModel["data"].ToString());
			if (dictionary != null)
			{
				result = true;
				MainData.KFV1Token = dictionary["token"].ToString();
				MainData.KFV1ServerTime = Convert.ToDateTime(dictionary["serverTime"]).AddHours(1.0);
			}
		}
		return result;
	}

	public static bool KangFengV1Verify(string license, string licenseColor, string gateCode, string passStatus, ref string msg, ref VehicleNoInfoView vehicleNoInfoView)
	{
		if (GetKangFengV1Token())
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("license", license);
			dictionary.Add("companyCode", MainData.companyCodeV1);
			dictionary.Add("licenseColor", GetKaiFenglicenseColor(licenseColor));
			dictionary.Add("passStatus", passStatus);
			dictionary.Add("gateCode", gateCode);
			Dictionary<string, object> kaiFengV1ResultModel = GetKaiFengV1ResultModel(MainData.KFV1ServerIP + "/transport/check", dictionary, MainData.KFV1Token);
			if (kaiFengV1ResultModel != null)
			{
				if (Convert.ToBoolean(kaiFengV1ResultModel["success"]) && kaiFengV1ResultModel["code"].ToString().Equals("200"))
				{
					dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(kaiFengV1ResultModel["data"].ToString());
					if (dictionary != null)
					{
						if (dictionary["isAllowPass"].ToString().Equals("1"))
						{
							msg = "允许通行";
							if (dictionary.ContainsKey("serialNum"))
							{
								vehicleNoInfoView.serialNum = dictionary["serialNum"].ToString();
							}
							else
							{
								vehicleNoInfoView.serialNum = null;
							}
							if (dictionary.ContainsKey("fuelType"))
							{
								vehicleNoInfoView.fuelType = GetFuelType(dictionary["fuelType"].ToString());
							}
							else
							{
								vehicleNoInfoView.fuelType = "未知";
							}
							if (dictionary.ContainsKey("emissionStandard"))
							{
								vehicleNoInfoView.emissionStandard = GetEmissionStandard(dictionary["emissionStandard"].ToString());
							}
							else
							{
								vehicleNoInfoView.emissionStandard = "未知";
							}
							vehicleNoInfoView.ExeLog = "允许通行";
							return true;
						}
						if (dictionary.ContainsKey("passReason"))
						{
							msg = dictionary["passReason"].ToString();
						}
						else
						{
							msg = "未知";
						}
						if (dictionary.ContainsKey("serialNum"))
						{
							vehicleNoInfoView.serialNum = dictionary["serialNum"].ToString();
						}
						else
						{
							vehicleNoInfoView.serialNum = null;
						}
						return false;
					}
				}
				else
				{
					msg = kaiFengV1ResultModel["message"].ToString();
					if (msg.Contains("Token验证不通过"))
					{
						MainData.KFV1Token = "";
						MainData.KFV1ServerTime = DateTime.Now.AddHours(-2.0);
					}
				}
			}
		}
		return false;
	}

	public static bool weiyouyuan(string cph, string inout)
	{
		inout = ((!(inout == "入口")) ? "out" : "in");
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(WYYServer("http://fskbtz.weiyouyuan.com.cn/cp/get_carInfo_tz.ashx?cph=" + cph + "&inout=" + inout));
		if (dictionary != null && dictionary.ContainsKey("result"))
		{
			if (dictionary["result"].Equals("1"))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static string WYYServer(string url)
	{
		try
		{
			LogSave.TZLog(DateTime.Now.ToString() + "台账上传" + url);
			RestClient obj = new RestClient(url)
			{
				Timeout = -1
			};
			RestRequest restRequest = new RestRequest(Method.GET);
			restRequest.AddHeader("Content-Type", "application/json");
			IRestResponse restResponse = obj.Execute(restRequest);
			if (restResponse != null)
			{
				LogSave.TZLog(DateTime.Now.ToString() + "台账返回" + restResponse.Content);
				return restResponse.Content;
			}
			return null;
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static string GetEmissionStandard(string type)
	{
		return type switch
		{
			"0" => "国0", 
			"1" => "国1", 
			"2" => "国2", 
			"3" => "国3", 
			"4" => "国4", 
			"5" => "国5", 
			"6" => "国6", 
			"7" => "国7", 
			"D" => "电动", 
			"X" => "无排放阶段", 
			_ => "未知", 
		};
	}

	public static string GetFuelType(string type)
	{
		return type switch
		{
			"A" => "汽油", 
			"B" => "柴油", 
			"C" => "电", 
			"D" => "混合油", 
			"E" => "天然气", 
			"F" => "液化石油气", 
			"L" => "甲醇", 
			"M" => "乙醇", 
			"N" => "太阳能", 
			"O" => "混合动力", 
			"P" => "氢", 
			"Q" => "生物燃料", 
			"Y" => "无", 
			"Z" => "其它", 
			_ => "其它", 
		};
	}

	public static Dictionary<string, object> GetKaiFengV1ResultModel(string url, object values, string token = "")
	{
		try
		{
			string text = JsonConvert.SerializeObject(values);
			LogSave.KaiFengV1(DateTime.Now.ToString() + url + "上传" + text);
			RestClient obj = new RestClient(url)
			{
				Timeout = -1
			};
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddHeader("Content-Type", "application/json");
			if (!string.IsNullOrWhiteSpace(token))
			{
				restRequest.AddHeader("token", token);
			}
			restRequest.AddParameter("application/json", text, ParameterType.RequestBody);
			IRestResponse restResponse = obj.Execute(restRequest);
			if (restResponse != null)
			{
				LogSave.KaiFengV1(DateTime.Now.ToString() + url + "返回" + restResponse.Content);
				return JsonConvert.DeserializeObject<Dictionary<string, object>>(restResponse.Content);
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static Dictionary<string, object> GetAnCheV1ResultModel(string url, object values, string token = "")
	{
		try
		{
			string value = JsonConvert.SerializeObject(values);
			RestClient obj = new RestClient(url)
			{
				Timeout = -1
			};
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddHeader("Content-Type", "application/json");
			if (!string.IsNullOrWhiteSpace(token))
			{
				restRequest.AddHeader("token", token);
			}
			restRequest.AddParameter("application/json", value, ParameterType.RequestBody);
			IRestResponse restResponse = obj.Execute(restRequest);
			if (restResponse != null)
			{
				LogSave.AnCheV1(DateTime.Now.ToString() + url + "返回" + restResponse.Content);
				return JsonConvert.DeserializeObject<Dictionary<string, object>>(restResponse.Content);
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static TYHttpResultModel GetTYData(string url, Dictionary<string, object> values)
	{
		JsonConvert.SerializeObject(values);
		RestClient restClient = new RestClient(url);
		restClient.Timeout = -1;
		RestRequest restRequest = new RestRequest(Method.POST);
		restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
		foreach (string key in values.Keys)
		{
			restRequest.AddParameter(key, values[key]);
		}
		IRestResponse restResponse = restClient.Execute(restRequest);
		if (restResponse != null)
		{
			return JsonConvert.DeserializeObject<TYHttpResultModel>(restResponse.Content);
		}
		return null;
	}

	public static bool GLVerify(string license, string licenseColor, string port, ref string msg, ref VehicleNoInfoView vehicleNoInfoView)
	{
		bool result = false;
		try
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("license", license);
			dictionary.Add("licenseColor", GetlicenseColor(licenseColor));
			LogSave.GLLog(DateTime.Now.ToString() + MainData.GLIISUrl + ":" + port + "校验上传信息：" + JsonConvert.SerializeObject(dictionary));
			string gLResultModel = GetGLResultModel(MainData.GLIISUrl + ":" + port + "/VehInfo/Verify", dictionary);
			LogSave.GLLog(DateTime.Now.ToString() + MainData.GLIISUrl + ":" + port + "校验返回信息：" + gLResultModel);
			if (gLResultModel != "")
			{
				Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(gLResultModel);
				if (dictionary2 != null)
				{
					if (dictionary2.ContainsKey("data") && dictionary2.ContainsKey("result") && dictionary2["result"].ToString().Equals("success"))
					{
						dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(dictionary2["data"].ToString());
						if (dictionary2 != null)
						{
							if (dictionary2.ContainsKey("isPass") && dictionary2.ContainsKey("passMessage") && dictionary2["isPass"].ToString().Equals("1"))
							{
								int num = 0;
								try
								{
									num = Convert.ToInt32(dictionary2["standard"].ToString());
								}
								catch (Exception)
								{
								}
								LogSave.GLLog("standard=" + num + "MainData.gkpf=" + MainData.gkpf);
								if (MainData.gkpf >= num && !licenseColor.Contains("绿") && MainData.gkpf != -1)
								{
									msg = "未达到企业管控排放阶段,禁止通行！";
									vehicleNoInfoView.fuelType = GetFuelType(dictionary2["fuelType"].ToString());
									vehicleNoInfoView.emissionStandard = GetEmissionStandard(dictionary2["standard"].ToString());
									return false;
								}
								vehicleNoInfoView.fuelType = GetFuelType(dictionary2["fuelType"].ToString());
								vehicleNoInfoView.emissionStandard = GetEmissionStandard(dictionary2["standard"].ToString());
								result = true;
							}
							else if (dictionary2.ContainsKey("passMessage"))
							{
								msg = dictionary2["passMessage"].ToString() + ",禁止通行！";
							}
							else
							{
								msg = "车辆禁止通行！";
							}
						}
						else
						{
							msg = "车辆禁止通行！";
						}
					}
					else
					{
						msg = "服务器异常,车辆禁止通行！";
					}
				}
				else
				{
					msg = "服务器异常,车辆禁止通行！";
				}
			}
			else
			{
				msg = "服务器异常,车辆禁止通行！";
			}
		}
		catch (Exception ex2)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "高凌验证异常：" + ex2.Message);
		}
		return result;
	}

	public static bool GLVerify1(string license, string licenseColor, string port, ref string msg, ref VehicleNoInfoView vehicleNoInfoView)
	{
		bool result = false;
		try
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("license", license);
			dictionary.Add("licenseColor", licenseColor);
			LogSave.GLLog(DateTime.Now.ToString() + "校验上传信息：" + JsonConvert.SerializeObject(dictionary));
			string gLResultModel = GetGLResultModel(MainData.GLIISUrl + ":" + port + "/VehInfo/Verify", dictionary);
			LogSave.GLLog(DateTime.Now.ToString() + "校验返回信息：" + gLResultModel);
			if (gLResultModel != "")
			{
				Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(gLResultModel);
				if (dictionary2 != null)
				{
					if (dictionary2.ContainsKey("data") && dictionary2.ContainsKey("result") && dictionary2["result"].ToString().Equals("success"))
					{
						dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(dictionary2["data"].ToString());
						if (dictionary2 != null)
						{
							msg = JsonConvert.SerializeObject(dictionary2);
							if (dictionary2.ContainsKey("isPass") && dictionary2.ContainsKey("passMessage") && dictionary2["isPass"].ToString().Equals("1"))
							{
								return true;
							}
						}
						else
						{
							msg = "车辆禁止通行！";
						}
					}
					else
					{
						msg = "服务器异常,车辆禁止通行！";
					}
				}
				else
				{
					msg = "服务器异常,车辆禁止通行！";
				}
			}
			else
			{
				msg = "服务器异常,车辆禁止通行！";
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "高凌验证异常：" + ex.Message);
		}
		return result;
	}

	public static Dictionary<string, object> GetCompanyControlInfo(string enterpriseID)
	{
		try
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enterpriseID", enterpriseID);
			LogSave.GLLog(DateTime.Now.ToString() + "校验上传信息：" + JsonConvert.SerializeObject(dictionary));
			string gLResultModel = GetGLResultModel(MainData.GLIISUrl + ":" + MainData.GLEnterPort + "/Control/GetCompanyControlInfo", dictionary);
			LogSave.GLLog(DateTime.Now.ToString() + "校验返回信息：" + gLResultModel);
			if (gLResultModel != "")
			{
				Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(gLResultModel);
				if (dictionary2 != null)
				{
					return dictionary2;
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "高凌验证异常：" + ex.Message);
		}
		return null;
	}

	public static bool GLSvaeRecord(string szLprResult, string inOutType, string port, string car_image, string front_image)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("license", szLprResult);
		dictionary.Add("inOutType", inOutType);
		dictionary.Add("gateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
		LogSave.GLLog(DateTime.Now.ToString() + "记录上传PassData/Send" + JsonConvert.SerializeObject(dictionary));
		dictionary.Add("licensImg", car_image);
		dictionary.Add("vehImg", front_image);
		string gLResultModel = GetGLResultModel(MainData.GLIISUrl + ":" + port + "/PassData/Send", dictionary);
		LogSave.GLLog(DateTime.Now.ToString() + "校验返回信息：" + gLResultModel);
		Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(gLResultModel);
		if (dictionary2 != null && dictionary2["result"].ToString().Equals("success"))
		{
			return true;
		}
		return false;
	}

	public static string GetControlLevel(string type)
	{
		string result = "";
		switch (type)
		{
		case "1":
			result = "黄色";
			break;
		case "2":
			result = "橙色";
			break;
		case "3":
			result = "红色";
			break;
		case "4":
			result = "其他";
			break;
		}
		return result;
	}

	public static string GetResponseLevel(string type)
	{
		string result = "";
		switch (type)
		{
		case "1":
			result = "Ⅰ级";
			break;
		case "2":
			result = "Ⅱ级";
			break;
		case "3":
			result = "Ⅲ级";
			break;
		case "4":
			result = "其他";
			break;
		}
		return result;
	}

	public static string GetControlStrategy(string type)
	{
		string result = "";
		switch (type)
		{
		case "1":
			result = "禁行国三及以下重型柴油车（燃气）车通行";
			break;
		case "2":
			result = "禁行国四及以下重型柴油（燃气）车通行";
			break;
		case "3":
			result = "禁行国四及以下重型柴油与国五及以下燃气车通行";
			break;
		case "4":
			result = "停止公路运输";
			break;
		}
		return result;
	}

	public static bool AnCheToken(ref string msg)
	{
		bool result = false;
		if (DateTime.Now <= MainData.ACServerTime && !string.IsNullOrWhiteSpace(MainData.ACToken))
		{
			return true;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("organ", MainData.ACorgan);
		dictionary.Add("ipctype", "getAccessToken");
		dictionary.Add("username", MainData.ACusername);
		dictionary.Add("password", MainData.ACpassword);
		LogSave.AnCheV1(DateTime.Now.ToString() + "验证Token" + JsonConvert.SerializeObject(dictionary));
		Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.ACServerUrl + "/restapi/transportControl/get_data", dictionary);
		if (anCheV1ResultModel != null)
		{
			if (anCheV1ResultModel["code"].ToString().Equals("200") && anCheV1ResultModel.ContainsKey("access_token") && anCheV1ResultModel.ContainsKey("datetime"))
			{
				result = true;
				MainData.ACToken = anCheV1ResultModel["access_token"].ToString();
				MainData.ACServerTime = Convert.ToDateTime(anCheV1ResultModel["datetime"]).AddHours(2.0);
			}
			else if (anCheV1ResultModel.ContainsKey("status"))
			{
				msg = anCheV1ResultModel["status"].ToString();
			}
		}
		else
		{
			msg = "环保局平台异常，请联系环保局！";
		}
		return result;
	}

	public static bool AnGetAuthorizationOrg()
	{
		return false;
	}

	public static bool AnCheVerify(string license, string licenseColor, ref string msg, ref VehicleNoInfoView vehicleNoInfoView, string gateCodeB = "")
	{
		bool result = false;
		try
		{
			if (AnCheToken(ref msg))
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("organ", MainData.ACorgan);
				dictionary.Add("ipctype", "getCheckVehicle");
				dictionary.Add("access_token", MainData.ACToken);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("license", license);
				dictionary2.Add("licenseColor", GetKaiFenglicenseColor(licenseColor));
				dictionary2.Add("enterpriseID", MainData.ACEnterpriseID);
				dictionary2.Add("gateCodeB", gateCodeB);
				dictionary.Add("value", dictionary2);
				LogSave.AnCheV1(DateTime.Now.ToString() + "验证车牌上传" + JsonConvert.SerializeObject(dictionary));
				Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.ACServerUrl + "/restapi/transportControl/get_data", dictionary);
				if (anCheV1ResultModel != null)
				{
					if (anCheV1ResultModel["code"].ToString().Equals("200"))
					{
						dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(anCheV1ResultModel["value"].ToString());
						if (dictionary2.ContainsKey("isControl") && dictionary2["isControl"].ToString().Equals("0"))
						{
							msg = "允许通行";
							result = true;
							try
							{
								tb_tempVehicle model = new DataServerContext<tb_tempVehicle>().Current.GetModel((tb_tempVehicle it) => it.vehicleNo == license);
								if (model == null)
								{
									model = new tb_tempVehicle();
									model.vin = dictionary2["vin"].ToString();
									model.registerDate = dictionary2["registerDate"].ToString();
									model.model = dictionary2["model"].ToString();
									model.fuelType = dictionary2["fuelType"].ToString();
									model.emissionStandard = dictionary2["emissionStandard"].ToString();
									model.useCharacter = dictionary2["useCharacter"].ToString();
									model.cdmc = dictionary2["cdmc"].ToString();
									model.vehicleNo = license;
									model.drivingLicenseImg2 = dictionary2["drivingLicenseImg2"].ToString();
									model.drivingLicenseImg = dictionary2["drivingLicenseImg"].ToString();
									new DataServerContext<tb_tempVehicle>().Current.Add(model);
								}
								else
								{
									model.vin = dictionary2["vin"].ToString();
									model.registerDate = dictionary2["registerDate"].ToString();
									model.model = dictionary2["model"].ToString();
									model.fuelType = dictionary2["fuelType"].ToString();
									model.emissionStandard = dictionary2["emissionStandard"].ToString();
									model.useCharacter = dictionary2["useCharacter"].ToString();
									model.cdmc = dictionary2["cdmc"].ToString();
									model.drivingLicenseImg2 = dictionary2["drivingLicenseImg2"].ToString();
									model.drivingLicenseImg = dictionary2["drivingLicenseImg"].ToString();
									new DataServerContext<tb_tempVehicle>().Current.Modify(model);
								}
							}
							catch (Exception ex)
							{
								LogSave.SaveExeLog(DateTime.Now.ToString() + "新增临时车异常" + ex.ToString());
							}
						}
						else if (dictionary2.ContainsKey("controlReason"))
						{
							result = false;
							msg = dictionary2["controlReason"].ToString();
						}
						else
						{
							result = false;
							msg = "服务器异常";
						}
						if (dictionary2.ContainsKey("emissionStandard"))
						{
							vehicleNoInfoView.emissionStandard = GetEmissionStandard(dictionary2["emissionStandard"].ToString());
						}
						if (dictionary2.ContainsKey("fuelType"))
						{
							vehicleNoInfoView.fuelType = GetFuelType(dictionary2["fuelType"].ToString());
						}
					}
					else
					{
						result = false;
						msg = anCheV1ResultModel["status"].ToString();
					}
				}
				else
				{
					result = false;
					msg = "环保局平台异常，请联系环保局！";
				}
			}
		}
		catch (Exception ex2)
		{
			result = false;
			msg = ex2.ToString();
		}
		return result;
	}

	public static bool acyqyc()
	{
		string msg = "";
		if (AnCheToken(ref msg))
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{
					"organ",
					MainData.ACorgan
				},
				{ "ipctype", "shareOneCtrlOnePolicyData" },
				{
					"access_token",
					MainData.ACToken
				},
				{
					"value",
					new Dictionary<string, object>
					{
						{
							"enterpriseID",
							MainData.ACorgan
						},
						{
							"accessToken",
							MainData.ACToken
						}
					}
				}
			};
			LogSave.AnCheV1(DateTime.Now.ToString() + "请求管控策略" + JsonConvert.SerializeObject(dictionary));
			GetAnCheV1ResultModel(MainData.ACServerUrl + "/restapi/transportControl/put_data", dictionary);
		}
		return false;
	}

	public static bool AnPutdcstatus()
	{
		bool result = false;
		string msg = "";
		if (AnCheToken(ref msg))
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("organ", MainData.ACorgan);
			dictionary.Add("ipctype", "putdcstatus");
			dictionary.Add("access_token", MainData.ACToken);
			List<object> list = new List<object>();
			foreach (tb_Channel item in new DataServerContext<tb_Channel>().Current.GetList())
			{
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("dzbh", item.ChannelPort);
				dictionary2.Add("bgzt", "0");
				dictionary2.Add("vlpzt", "0");
				list.Add(dictionary2);
			}
			dictionary.Add("value", list);
			LogSave.AnCheV1(DateTime.Now.ToString() + "安车设备心跳上传" + JsonConvert.SerializeObject(dictionary));
			Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.ACServerUrl + "/restapi/transportControl/put_data", dictionary);
			if (anCheV1ResultModel != null && anCheV1ResultModel["code"].ToString().Equals("200"))
			{
				result = true;
			}
		}
		return result;
	}

	public static bool AnCheUpLoad(string lsh, string dzbh, string cphm, string cpys, string tgsjq, string tgsjz, string bgzt, string tgzt, ref string msg, string imgURL1, string imgURL2)
	{
		bool result = false;
		try
		{
			if (AnCheToken(ref msg))
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("organ", MainData.ACorgan);
				dictionary.Add("ipctype", "shareDrivingRecord");
				dictionary.Add("access_token", MainData.ACToken);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("lsh", lsh);
				dictionary2.Add("qybh", MainData.ACorgan);
				dictionary2.Add("qymc", MainData.XMMC);
				dictionary2.Add("dzbh", dzbh);
				dictionary2.Add("cphm", cphm);
				dictionary2.Add("cpys", cpys);
				dictionary2.Add("tgsjq", tgsjq);
				dictionary2.Add("tgsjz", tgsjz);
				dictionary2.Add("bgzt", "1");
				dictionary2.Add("tgzt", tgzt);
				dictionary2.Add("serialNum", lsh);
				dictionary2.Add("enterpriseid", MainData.ACEnterpriseID);
				dictionary2.Add("enterpriseId", MainData.ACEnterpriseID);
				dictionary2.Add("entranceGateCode", "A");
				dictionary2.Add("gateCodeB", dzbh);
				dictionary2.Add("inOutComStatus", tgzt);
				dictionary2.Add("date", tgsjq);
				dictionary2.Add("license", cphm);
				dictionary2.Add("licenseColor", cpys);
				dictionary2.Add("rollType", 0);
				tb_tempVehicle model = new DataServerContext<tb_tempVehicle>().Current.GetModel((tb_tempVehicle it) => it.vehicleNo == cphm);
				if (model != null)
				{
					dictionary2.Add("cdmc", model.cdmc);
					dictionary2.Add("vin", model.vin);
					dictionary2.Add("registerDate", model.registerDate);
					dictionary2.Add("model", model.model);
					dictionary2.Add("fuelType", model.fuelType);
					dictionary2.Add("emissionStandard", model.emissionStandard);
					dictionary2.Add("useCharacter", model.useCharacter);
					dictionary2.Add("drivingLicenseImg2", model.drivingLicenseImg2);
					dictionary2.Add("drivingLicenseImg", model.drivingLicenseImg);
				}
				else
				{
					dictionary2.Add("cdmc", "");
					dictionary2.Add("vin", "");
					dictionary2.Add("registerDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
					dictionary2.Add("model", "2");
					dictionary2.Add("fuelType", "A");
					dictionary2.Add("emissionStandard", "5");
					dictionary2.Add("useCharacter", "A");
					dictionary2.Add("drivingLicenseImg2", "");
					dictionary2.Add("drivingLicenseImg", "");
				}
				dictionary2.Add("ysl", 0);
				dictionary2.Add("hwmc", "");
				dictionary2.Add("hylx", "");
				dictionary2.Add("ysldw", "");
				dictionary2.Add("networkStatus", "1");
				LogSave.AnCheV1(DateTime.Now.ToString() + "记录上传" + JsonConvert.SerializeObject(dictionary2));
				dictionary2.Add("imgURL1", "data:image/jpeg;base64," + imgURL1);
				dictionary2.Add("imgURL2", "data:image/jpeg;base64," + imgURL2);
				dictionary.Add("value", dictionary2);
				Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.ACServerUrl + "/restapi/transportControl/put_data", dictionary);
				if (anCheV1ResultModel != null)
				{
					if (anCheV1ResultModel["code"].ToString().Equals("200"))
					{
						result = true;
					}
					else if (dictionary2.ContainsKey("status"))
					{
						result = false;
						msg = dictionary2["status"].ToString();
					}
					else
					{
						result = false;
						msg = "服务器异常";
					}
				}
				else
				{
					result = false;
					msg = "服务器异常";
				}
			}
		}
		catch (Exception ex)
		{
			result = false;
			msg = ex.Message;
		}
		return result;
	}

	public static bool AnCheUpLoadIamge(string lsh, string dzbh, string cphm, string cpys, string zpbh, string zplx, string base64Image, string pzsj, ref string msg)
	{
		bool result = false;
		try
		{
			if (AnCheToken(ref msg))
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("organ", MainData.ACorgan);
				dictionary.Add("ipctype", "sharePhotoInfo");
				dictionary.Add("access_token", MainData.ACToken);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("lsh", lsh);
				dictionary2.Add("qybh", MainData.ACorgan);
				dictionary2.Add("qymc", MainData.XMMC);
				dictionary2.Add("dzbh", dzbh);
				dictionary2.Add("cphm", cphm);
				dictionary2.Add("cpys", cpys);
				dictionary2.Add("zpbh", zpbh);
				dictionary2.Add("zplx", zplx);
				dictionary2.Add("base64Image", base64Image);
				dictionary2.Add("pzsj", pzsj);
				dictionary2.Add("serialNum", lsh);
				dictionary2.Add("enterpriseID", MainData.ACEnterpriseID);
				dictionary2.Add("companyName", MainData.XMMC);
				dictionary2.Add("gateCodeB", dzbh);
				dictionary2.Add("license", cphm);
				dictionary2.Add("licenseColor", cpys);
				dictionary2.Add("imageNum", zpbh);
				dictionary2.Add("imageType", zplx);
				dictionary2.Add("imageTime", pzsj);
				dictionary.Add("value", dictionary2);
				Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.ACServerUrl + "/restapi/transportControl/put_file", dictionary);
				if (anCheV1ResultModel != null)
				{
					if (anCheV1ResultModel["code"].ToString().Equals("200"))
					{
						result = true;
					}
					else if (dictionary2.ContainsKey("status"))
					{
						result = false;
						msg = dictionary2["status"].ToString();
					}
					else
					{
						result = false;
						msg = "服务器异常";
					}
				}
				else
				{
					result = false;
					msg = "服务器异常";
				}
			}
		}
		catch (Exception ex)
		{
			result = false;
			msg = ex.Message;
		}
		return result;
	}

	public static bool tdrcCheToken()
	{
		bool result = false;
		if (DateTime.Now <= MainData.tdrcServerTime && !string.IsNullOrWhiteSpace(MainData.tdrcToken))
		{
			return true;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("organ", MainData.tdrcOrgan);
		dictionary.Add("ipctype", "getAccessToken");
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2.Add("username", MainData.tdrcUsername);
		dictionary2.Add("password", MainData.tdrcPassword);
		dictionary.Add("value", dictionary2);
		LogSave.AnCheV1(DateTime.Now.ToString() + MainData.tdrcUrl + "/restapi/transportControl/get_data登录请求" + JsonConvert.SerializeObject(dictionary));
		Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.tdrcUrl + "/restapi/transportControl/get_data", dictionary);
		if (anCheV1ResultModel != null && anCheV1ResultModel["code"].ToString().Equals("200") && anCheV1ResultModel.ContainsKey("access_token") && anCheV1ResultModel.ContainsKey("datetime"))
		{
			result = true;
			MainData.tdrcToken = anCheV1ResultModel["access_token"].ToString();
			MainData.tdrcServerTime = Convert.ToDateTime(anCheV1ResultModel["datetime"]).AddHours(2.0);
		}
		return result;
	}

	public static bool tdrcyqyc()
	{
		bool result = false;
		if (tdrcCheToken())
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("organ", MainData.tdrcOrgan);
			dictionary.Add("ipctype", "shareOneCtrlOnePolicyData");
			dictionary.Add("access_token", MainData.tdrcToken);
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			dictionary2.Add("enterpriseID", MainData.tdrcOrgan);
			dictionary.Add("value", dictionary2);
			Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.tdrcUrl + "/restapi/transportControl/put_data", dictionary);
			if (anCheV1ResultModel != null && anCheV1ResultModel["code"].ToString().Equals("200") && anCheV1ResultModel.ContainsKey("access_token") && anCheV1ResultModel.ContainsKey("datetime"))
			{
				result = true;
			}
		}
		return result;
	}

	public static bool tdrcCheVerify(string license, string licenseColor, ref string msg, ref VehicleNoInfoView vehicleNoInfoView, string gateCodeB = "")
	{
		bool result = false;
		try
		{
			if (tdrcCheToken())
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("organ", MainData.tdrcOrgan);
				dictionary.Add("ipctype", "getCheckVehicle");
				dictionary.Add("access_token", MainData.tdrcToken);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("license", license);
				dictionary2.Add("licenseColor", GetKaiFenglicenseColor(licenseColor));
				dictionary2.Add("enterpriseID", MainData.tdrcEnterpriseID);
				dictionary2.Add("gateCodeB", gateCodeB);
				dictionary.Add("value", dictionary2);
				LogSave.AnCheV1(DateTime.Now.ToString() + "验证请求" + JsonConvert.SerializeObject(dictionary));
				Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.tdrcUrl + "/restapi/transportControl/get_data", dictionary);
				if (anCheV1ResultModel != null)
				{
					if (anCheV1ResultModel["code"].ToString().Equals("200"))
					{
						dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(anCheV1ResultModel["value"].ToString());
						if (dictionary2.ContainsKey("isControl") && dictionary2["isControl"].ToString().Equals("0"))
						{
							msg = "允许通行";
							result = true;
						}
						else if (dictionary2.ContainsKey("controlReason"))
						{
							result = false;
							msg = dictionary2["controlReason"].ToString();
						}
						else
						{
							result = false;
							msg = "服务器异常";
						}
						if (dictionary2.ContainsKey("emissionStandard"))
						{
							vehicleNoInfoView.emissionStandard = GetEmissionStandard(dictionary2["emissionStandard"].ToString());
						}
						if (dictionary2.ContainsKey("fueltype"))
						{
							vehicleNoInfoView.fuelType = GetFuelType(dictionary2["fueltype"].ToString());
						}
					}
					else
					{
						result = false;
						msg = anCheV1ResultModel["status"].ToString();
					}
				}
				else
				{
					result = false;
					msg = "服务器异常";
				}
			}
			else
			{
				msg = "TOKEN验证失败";
			}
		}
		catch (Exception ex)
		{
			result = false;
			msg = ex.Message;
		}
		return result;
	}

	public static bool tdrcCheUpLoad(string lsh, string dzbh, string cphm, string cpys, string tgsjq, string tgsjz, string rollState, string inOutStatus, ref string msg)
	{
		bool result = false;
		try
		{
			if (tdrcCheToken())
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("organ", MainData.tdrcOrgan);
				dictionary.Add("ipctype", "shareDrivingRecord");
				dictionary.Add("access_token", MainData.tdrcToken);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("serialNum", lsh);
				dictionary2.Add("enterpriseID", MainData.tdrcEnterpriseID);
				dictionary2.Add("entranceGateCode", "A");
				dictionary2.Add("gateCodeB", dzbh);
				dictionary2.Add("inOutComStatus", inOutStatus);
				dictionary2.Add("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				dictionary2.Add("license", cphm);
				dictionary2.Add("licenseColor", cpys);
				dictionary2.Add("rollType", 0);
				dictionary.Add("value", dictionary2);
				Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.tdrcUrl + "restapi/transportControl/put_data", dictionary);
				if (anCheV1ResultModel != null)
				{
					if (anCheV1ResultModel["code"].ToString().Equals("200"))
					{
						result = true;
					}
					else if (dictionary2.ContainsKey("status"))
					{
						result = false;
						msg = dictionary2["status"].ToString();
					}
					else
					{
						result = false;
						msg = "服务器异常";
					}
				}
				else
				{
					result = false;
					msg = "服务器异常";
				}
			}
		}
		catch (Exception ex)
		{
			result = false;
			msg = ex.Message;
		}
		return result;
	}

	public static bool tdrcCheUpLoadIamge(string lsh, string dzbh, string cphm, string cpys, string zpbh, string zplx, string base64Image, string pzsj, ref string msg)
	{
		bool result = false;
		try
		{
			if (tdrcCheToken())
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("organ", MainData.tdrcOrgan);
				dictionary.Add("ipctype", "sharePhotoInfo");
				dictionary.Add("access_token", MainData.tdrcToken);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("serialNum", lsh);
				dictionary2.Add("enterpriseID", MainData.tdrcEnterpriseID);
				dictionary2.Add("companyName", MainData.XMMC);
				dictionary2.Add("gateCodeB", dzbh);
				dictionary2.Add("license", cphm);
				dictionary2.Add("licenseColor", cpys);
				dictionary2.Add("imageNum", zpbh);
				dictionary2.Add("imageType", zplx);
				dictionary2.Add("base64Image", "data:image/jpeg;base64," + base64Image);
				dictionary2.Add("imageTime", pzsj);
				dictionary.Add("value", dictionary2);
				Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.tdrcUrl + "/restapi/transportControl/put_file", dictionary);
				if (anCheV1ResultModel != null)
				{
					if (anCheV1ResultModel["code"].ToString().Equals("200"))
					{
						result = true;
					}
					else if (dictionary2.ContainsKey("status"))
					{
						result = false;
						msg = dictionary2["status"].ToString();
					}
					else
					{
						result = false;
						msg = "服务器异常";
					}
				}
				else
				{
					result = false;
					msg = "服务器异常";
				}
			}
		}
		catch (Exception ex)
		{
			result = false;
			msg = ex.Message;
		}
		return result;
	}

	public static bool tdrcGateStatusReport(string dzbh, string gateStatus)
	{
		bool result = false;
		try
		{
			if (tdrcCheToken())
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("organ", MainData.tdrcOrgan);
				dictionary.Add("ipctype", "gateStatusReport");
				dictionary.Add("access_token", MainData.tdrcToken);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("companyCode", MainData.tdrcOrgan);
				dictionary2.Add("gateCodeB", dzbh);
				dictionary2.Add("gateStatus", gateStatus);
				dictionary2.Add("cameraStatus", "1");
				dictionary2.Add("subtime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				dictionary2.Add("enterpriseID", MainData.tdrcEnterpriseID);
				dictionary.Add("value", dictionary2);
				LogSave.AnCheV1(DateTime.Now.ToString() + "道闸信息请求" + JsonConvert.SerializeObject(dictionary));
				Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.tdrcUrl + "/restapi/transportControl/put_data", dictionary);
				result = anCheV1ResultModel != null && (anCheV1ResultModel["code"].ToString().Equals("200") || (dictionary2.ContainsKey("status") && false));
			}
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	public static bool xyCheToken()
	{
		bool result = false;
		if (DateTime.Now <= MainData.xyServerTime && !string.IsNullOrWhiteSpace(MainData.xyToken))
		{
			return true;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("organ", MainData.xyOrgan);
		dictionary.Add("ipctype", "getAccessToken");
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2.Add("username", MainData.xyUsername);
		dictionary2.Add("password", MainData.xyPassword);
		dictionary.Add("value", dictionary2);
		Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.xyUrl + "/mjApi/restapi/transportControl/get_data", dictionary);
		if (anCheV1ResultModel != null && anCheV1ResultModel["code"].ToString().Equals("200") && anCheV1ResultModel.ContainsKey("access_token") && anCheV1ResultModel.ContainsKey("datetime"))
		{
			result = true;
			MainData.xyToken = anCheV1ResultModel["access_token"].ToString();
			MainData.xyServerTime = Convert.ToDateTime(anCheV1ResultModel["datetime"]).AddHours(2.0);
		}
		return result;
	}

	public static bool xyCheVerify(string license, string licenseColor, ref string msg, ref VehicleNoInfoView vehicleNoInfoView)
	{
		bool result = false;
		try
		{
			if (xyCheToken())
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("organ", MainData.xyOrgan);
				dictionary.Add("ipctype", "getCheckVehicle");
				dictionary.Add("access_token", MainData.xyToken);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("license", license);
				dictionary2.Add("licenseColor", GetKaiFenglicenseColor(licenseColor));
				dictionary.Add("value", dictionary2);
				Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.xyUrl + "/mjApi/restapi/transportControl/get_data", dictionary);
				if (anCheV1ResultModel != null)
				{
					if (anCheV1ResultModel["code"].ToString().Equals("200"))
					{
						dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(anCheV1ResultModel["value"].ToString());
						if (dictionary2.ContainsKey("isControl") && dictionary2["isControl"].ToString().Equals("0"))
						{
							msg = "允许通行";
							result = true;
						}
						else if (dictionary2.ContainsKey("controlReason"))
						{
							result = false;
							msg = dictionary2["controlReason"].ToString();
						}
						else
						{
							result = false;
							msg = "服务器异常";
						}
						if (dictionary2.ContainsKey("emissionStandard"))
						{
							vehicleNoInfoView.emissionStandard = GetEmissionStandard(dictionary2["emissionStandard"].ToString());
						}
						if (dictionary2.ContainsKey("fueltype"))
						{
							vehicleNoInfoView.fuelType = GetFuelType(dictionary2["fueltype"].ToString());
						}
					}
					else
					{
						result = false;
						msg = anCheV1ResultModel["status"].ToString();
					}
				}
				else
				{
					result = false;
					msg = "服务器异常";
				}
			}
		}
		catch (Exception ex)
		{
			result = false;
			msg = ex.Message;
		}
		return result;
	}

	public static bool xyCheUpLoad(string lsh, string dzbh, string cphm, string cpys, string tgsjq, string tgsjz, string rollState, string inOutStatus, ref string msg)
	{
		bool result = false;
		try
		{
			if (xyCheToken())
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("organ", MainData.xyOrgan);
				dictionary.Add("ipctype", "shareDrivingRecord");
				dictionary.Add("access_token", MainData.xyToken);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("lsh", lsh);
				dictionary2.Add("companyCode", MainData.xyOrgan);
				dictionary2.Add("companyName", MainData.XMMC);
				dictionary2.Add("doorCode", dzbh);
				dictionary2.Add("license", cphm);
				dictionary2.Add("licenseColor", cpys);
				dictionary2.Add("passtimeFd", tgsjq);
				dictionary2.Add("passtimeNd", tgsjz);
				dictionary2.Add("rollState", rollState);
				dictionary2.Add("inOutStatus", inOutStatus);
				dictionary2.Add("rollType", 0);
				dictionary2.Add("isControl", 0);
				dictionary.Add("value", dictionary2);
				Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.xyUrl + "/mjapi/restapi/transportControl/put_data", dictionary);
				if (anCheV1ResultModel != null)
				{
					if (anCheV1ResultModel["code"].ToString().Equals("200"))
					{
						result = true;
					}
					else if (dictionary2.ContainsKey("status"))
					{
						result = false;
						msg = dictionary2["status"].ToString();
					}
					else
					{
						result = false;
						msg = "服务器异常";
					}
				}
				else
				{
					result = false;
					msg = "服务器异常";
				}
			}
		}
		catch (Exception ex)
		{
			result = false;
			msg = ex.Message;
		}
		return result;
	}

	public static bool xyCheUpLoadIamge(string lsh, string dzbh, string cphm, string cpys, string zpbh, string zplx, string base64Image, string pzsj, ref string msg)
	{
		bool result = false;
		try
		{
			if (xyCheToken())
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("organ", MainData.xyOrgan);
				dictionary.Add("ipctype", "sharePhotoInfo");
				dictionary.Add("access_token", MainData.xyToken);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("lsh", lsh);
				dictionary2.Add("companyCode", MainData.xyOrgan);
				dictionary2.Add("companyName", MainData.XMMC);
				dictionary2.Add("doorCode", dzbh);
				dictionary2.Add("license", cphm);
				dictionary2.Add("licenseColor", cpys);
				dictionary2.Add("photoCode", zpbh);
				dictionary2.Add("photoType", zplx);
				dictionary2.Add("photoPath", "data:image/jpeg;base64," + base64Image);
				dictionary2.Add("photoTime", pzsj);
				dictionary.Add("value", dictionary2);
				Dictionary<string, object> anCheV1ResultModel = GetAnCheV1ResultModel(MainData.xyUrl + "/mjapi/restapi/transportControl/put_data", dictionary);
				if (anCheV1ResultModel != null)
				{
					if (anCheV1ResultModel["code"].ToString().Equals("200"))
					{
						result = true;
					}
					else if (dictionary2.ContainsKey("status"))
					{
						result = false;
						msg = dictionary2["status"].ToString();
					}
					else
					{
						result = false;
						msg = "服务器异常";
					}
				}
				else
				{
					result = false;
					msg = "服务器异常";
				}
			}
		}
		catch (Exception ex)
		{
			result = false;
			msg = ex.Message;
		}
		return result;
	}

	public static string Encode(string data, string key)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(key);
		byte[] bytes2 = Encoding.ASCII.GetBytes(key);
		DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
		_ = dESCryptoServiceProvider.KeySize;
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, bytes2), CryptoStreamMode.Write);
		StreamWriter streamWriter = new StreamWriter(cryptoStream);
		streamWriter.Write(data);
		streamWriter.Flush();
		cryptoStream.FlushFinalBlock();
		streamWriter.Flush();
		return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
	}

	public static string AESDecrypt(string text, string AesKey, string AesIV)
	{
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(AesKey);
			byte[] bytes2 = Encoding.UTF8.GetBytes(text);
			byte[] array = new RijndaelManaged
			{
				Key = bytes,
				Mode = CipherMode.CBC,
				Padding = PaddingMode.PKCS7,
				BlockSize = 128,
				IV = Encoding.UTF8.GetBytes(AesIV)
			}.CreateEncryptor().TransformFinalBlock(bytes2, 0, bytes2.Length);
			return Convert.ToBase64String(array, 0, array.Length);
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static bool GLSvaeHSRecord(string szLprResult, string inOutType, string port, string car_image, string front_image)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("license", szLprResult);
		dictionary.Add("inOutType", inOutType);
		dictionary.Add("gateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
		LogSave.GLLog(DateTime.Now.ToString() + "记录上传PassData/SendHS" + JsonConvert.SerializeObject(dictionary));
		dictionary.Add("licensImg", car_image);
		dictionary.Add("vehImg", front_image);
		string gLResultModel = GetGLResultModel(MainData.GLIISUrl + ":" + port + "/PassData/SendHS", dictionary);
		LogSave.GLLog(DateTime.Now.ToString() + "校验返回信息：" + gLResultModel);
		Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(gLResultModel);
		if (dictionary2 != null && dictionary2["result"].ToString().Equals("success"))
		{
			return true;
		}
		return false;
	}

	public static bool TYVerify(string szLprResult, string Color, int channelNo, string path, ref string msg)
	{
		try
		{
			string value = ImageToBase64(path);
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("uscc", MainData.TYcode);
			dictionary.Add("deviceId", MainData.TYDeviceId);
			dictionary.Add("channelNo", channelNo);
			dictionary.Add("carId", szLprResult);
			dictionary.Add("carIdColor", Color);
			dictionary.Add("carColor", "");
			dictionary.Add("accessTime", DateTime.Now.ToString("yyyyMMddHHmmss"));
			dictionary.Add("imageSuffix", ".jpg");
			LogSave.TYLog(DateTime.Now.ToString() + "腾跃验证校验上传" + JsonConvert.SerializeObject(dictionary));
			dictionary.Add("imageData", value);
			TYHttpResultModel tYData = GetTYData("http://127.0.0.1:80/api/access/control.do", dictionary);
			dictionary.Remove("imageData");
			LogSave.TYLog(DateTime.Now.ToString() + "腾跃验证校验上传返回" + JsonConvert.SerializeObject(tYData));
			if (tYData != null)
			{
				if (tYData.resultCode == "9000")
				{
					if (MainData.YXMS == "急速模式" && !TYGetDoesItExist(szLprResult))
					{
						tb_TempCarInfo tb_TempCarInfo2 = new tb_TempCarInfo();
						tb_TempCarInfo2.car_no = szLprResult;
						tb_TempCarInfo2.add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
						tb_TempCarInfo2.standard = "";
						tb_TempCarInfo2.isPass = "";
						tb_TempCarInfo2.passMessage = "";
						if (!new DataServerContext<tb_TempCarInfo>().Current.Add(tb_TempCarInfo2))
						{
							LogSave.TYLog(DateTime.Now.ToString() + "新增失败：" + JsonConvert.SerializeObject(tb_TempCarInfo2));
						}
					}
					return true;
				}
				new DataServerContext<tb_TempCarInfo>().Current.Delete((tb_TempCarInfo it) => it.car_no == szLprResult);
				msg = tYData.resultMsg + "禁止通行";
				return false;
			}
			new DataServerContext<tb_TempCarInfo>().Current.Delete((tb_TempCarInfo it) => it.car_no == szLprResult);
			msg = tYData.resultMsg + "禁止通行";
			return false;
		}
		catch (Exception ex)
		{
			msg = "服务器异常，禁止通行！";
			LogSave.TYLog(DateTime.Now.ToString() + "验证异常" + ex.Message);
			return false;
		}
	}

	public static bool TYSaveRecord(string szLprResult, string Color, int channelNo, string path)
	{
		bool result = false;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("uscc", MainData.TYcode);
		dictionary.Add("deviceId", MainData.TYDeviceId);
		dictionary.Add("channelNo", channelNo);
		dictionary.Add("carId", szLprResult);
		dictionary.Add("carIdColor", Color);
		dictionary.Add("carColor", "");
		dictionary.Add("imageSuffix", ".jpg");
		dictionary.Add("accessTime", DateTime.Now.ToString("yyyyMMddHHmmss"));
		LogSave.TYLog(DateTime.Now.ToString() + "腾跃记录上传" + JsonConvert.SerializeObject(dictionary));
		dictionary.Add("imageData", ImageToBase64(path));
		TYHttpResultModel tYData = GetTYData("http://127.0.0.1:80/api/access/pass.do", dictionary);
		LogSave.TYLog(DateTime.Now.ToString() + "腾跃记录上传返回" + JsonConvert.SerializeObject(tYData));
		if (tYData != null && tYData.resultCode == "9000")
		{
			result = true;
		}
		return result;
	}

	public static string MD5Encrypt(string password)
	{
		byte[] array = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(password));
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			stringBuilder.Append(b.ToString("x2"));
		}
		return stringBuilder.ToString().ToLower();
	}

	public static long DateTimeToStamp(DateTime time)
	{
		DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		return (long)(time - dateTime).TotalMilliseconds;
	}

	public static string GetlicenseColor(string Color)
	{
		Color = Color switch
		{
			"蓝色" => "0", 
			"黄色" => "1", 
			"黑色" => "3", 
			"白色" => "2", 
			"绿色" => "4", 
			"黄绿色" => "6", 
			_ => "5", 
		};
		return Color;
	}

	public static string GetKaiFenglicenseColor(string Color)
	{
		if (Color != null)
		{
			int length = Color.Length;
			if (length == 2)
			{
				char c = Color[0];
				if ((uint)c <= 32511u)
				{
					if (c != '白')
					{
						if (c != '绿' || !(Color == "绿色"))
						{
							goto IL_00ff;
						}
						Color = "4";
					}
					else
					{
						if (!(Color == "白色"))
						{
							goto IL_00ff;
						}
						Color = "2";
					}
				}
				else if (c != '蓝')
				{
					if (c != '黄')
					{
						if (c != '黑' || !(Color == "黑色"))
						{
							goto IL_00ff;
						}
						Color = "3";
					}
					else
					{
						if (!(Color == "黄色"))
						{
							if (Color == "黄绿")
							{
								goto IL_00f6;
							}
							goto IL_00ff;
						}
						Color = "1";
					}
				}
				else
				{
					if (!(Color == "蓝色"))
					{
						goto IL_00ff;
					}
					Color = "0";
				}
				goto IL_0106;
			}
			if (length == 3 && Color == "黄绿色")
			{
				goto IL_00f6;
			}
		}
		goto IL_00ff;
		IL_00ff:
		Color = "0";
		goto IL_0106;
		IL_0106:
		return Color;
		IL_00f6:
		Color = "6";
		goto IL_0106;
	}

	public static string ImageToBase64(string fileFullName)
	{
		try
		{
			if (fileFullName == "" || !File.Exists(fileFullName))
			{
				return "";
			}
			Bitmap bitmap = new Bitmap(fileFullName);
			MemoryStream memoryStream = new MemoryStream();
			ImageFormat imageFormat;
			switch (fileFullName.Substring(fileFullName.LastIndexOf('.') + 1, fileFullName.Length - fileFullName.LastIndexOf('.') - 1).ToLower())
			{
			default:
				imageFormat = ImageFormat.Jpeg;
				break;
			case "gif":
				imageFormat = ImageFormat.Gif;
				break;
			case "bmp":
				imageFormat = ImageFormat.Bmp;
				break;
			case "jpg":
			case "jpeg":
				imageFormat = ImageFormat.Jpeg;
				break;
			case "png":
				imageFormat = ImageFormat.Png;
				break;
			}
			ImageFormat format = imageFormat;
			bitmap.Save(memoryStream, format);
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Position = 0L;
			memoryStream.Read(array, 0, (int)memoryStream.Length);
			memoryStream.Close();
			return Convert.ToBase64String(array);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static bool SaveBase64ToImage(string base64String, string outputPath)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(base64String))
			{
				return false;
			}
			string s = CleanBase64String(base64String);
			outputPath = Application.StartupPath + outputPath;
			using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(s)))
			{
				using Image image = Image.FromStream(stream);
				ImageFormat imageFormat = GetImageFormat(outputPath);
				image.Save(outputPath, imageFormat);
			}
			Console.WriteLine("图片已保存到: " + outputPath);
			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine("保存图片失败: " + ex.Message);
			return false;
		}
	}

	private static string CleanBase64String(string base64String)
	{
		if (base64String.Contains("base64,"))
		{
			return base64String.Split(',')[1];
		}
		return base64String;
	}

	private static ImageFormat GetImageFormat(string filePath)
	{
		Path.GetExtension(filePath).ToLower();
		return ImageFormat.Jpeg;
	}

	public static bool GetDoesItExist(string carNo, ref tb_TempCarInfo tb_TempCar)
	{
		return false;
	}

	public static bool TYGetDoesItExist(string carNo)
	{
		try
		{
			bool result = false;
			if (new DataServerContext<tb_TempCarInfo>().Current.GetList((tb_TempCarInfo it) => it.car_no == carNo && Convert.ToDateTime(it.add_time) >= DateTime.Now.Date).FirstOrDefault() != null)
			{
				result = true;
			}
			return result;
		}
		catch (Exception ex)
		{
			LogSave.ZSLog(DateTime.Now.ToString() + "TYGetDoesItExist：" + ex.ToString());
			return false;
		}
	}

	public static List<string> GetVehicleType()
	{
		return new List<string>
		{
			"重型普通半挂车", "重型厢式半挂车", "重型罐式半挂车", "重型平板半挂车", "重型集装箱半挂车", "重型自卸半挂车", "重型特殊结构半挂车", "重型仓栅式半挂车", "重型旅居半挂车", "重型专项作业半挂车",
			"重型低平板半挂车", "中型普通半挂车", "中型厢式半挂车", "中型罐式半挂车", "中型平板半挂车", "中型集装箱半挂车", "中型自卸半挂车", "中型特殊结构半挂车", "中型仓栅式半挂车", "中型旅居半挂车",
			"中型专项作业半挂车", "中型低平板半挂车", "轻型普通半挂车", "轻型厢式半挂车", "轻型罐式半挂车", "轻型平板半挂车", "轻型自卸半挂车", "轻型仓栅式半挂车", "轻型旅居半挂车", "轻型专项作业半挂车",
			"轻型低平板半挂车", "无轨电车", "有轨电车", "自行车", "三轮车", "手推车", "残疾人专用车", "畜力车", "助力自行车", "电动自行车",
			"其他非机动车", "重型普通全挂车", "重型厢式全挂车", "重型罐式全挂车", "重型平板全挂车", "重型集装箱全挂车", "重型自卸全挂车", "重型仓栅式全挂车", "重型旅居全挂车", "重型专项作业全挂车",
			"中型普通全挂车", "中型厢式全挂车", "中型罐式全挂车", "中型平板全挂车", "中型集装箱全挂车", "中型自卸全挂车", "中型仓栅式全挂车", "中型旅居全挂车", "中型专项作业全挂车", "轻型普通全挂车",
			"轻型厢式全挂车", "轻型罐式全挂车", "轻型平板全挂车", "轻型自卸全挂车", "轻型仓栅式全挂车", "轻型旅居全挂车", "轻型专项作业全挂车", "重型普通货车", "重型厢式货车", "重型封闭货车",
			"重型罐式货车", "重型平板货车", "重型集装厢车", "重型自卸货车", "重型特殊结构货车", "重型仓栅式货车", "中型普通货车", "中型厢式货车", "中型封闭货车", "中型罐式货车",
			"中型平板货车", "中型集装厢车", "中型自卸货车", "中型特殊结构货车", "中型仓栅式货车", "轻型普通货车", "轻型厢式货车", "轻型封闭货车", "轻型罐式货车", "轻型平板货车",
			"轻型自卸货车", "轻型特殊结构货车", "轻型仓栅式货车", "微型普通货车", "微型厢式货车", "微型封闭货车", "微型罐式货车", "微型自卸货车", "微型特殊结构货车", "微型仓栅式货车",
			"普通低速货车", "厢式低速货车", "罐式低速货车", "自卸低速货车", "仓栅式低速货车", "轮式装载机械", "轮式挖掘机械", "轮式平地机械", "大型普通客车", "大型双层客车",
			"大型卧铺客车", "大型铰接客车", "大型越野客车", "大型轿车", "大型专用客车", "大型专用校车", "中型普通客车", "中型双层客车", "中型卧铺客车", "中型铰接客车",
			"中型越野客车", "中型轿车", "中型专用客车", "中型专用校车", "小型普通客车", "小型越野客车", "小型轿车", "小型专用客车", "小型专用校车", "微型普通客车",
			"微型越野客车", "微型轿车", "普通正三轮摩托车", "轻便正三轮摩托车", "正三轮载客摩托车", "正三轮载货摩托车", "侧三轮摩托车", "普通二轮摩托车", "轻便二轮摩托车", "三轮汽车",
			"重型半挂牵引车", "重型全挂牵引车", "中型半挂牵引车", "中型全挂牵引车", "轻型半挂牵引车", "轻型全挂牵引车", "道路挖掘", "道路占用", "大型轮式拖拉机", "小型轮式拖拉机",
			"手扶拖拉机", "手扶变形运输机", "其它", "大型专项作业车", "中型专项作业车", "小型专项作业车", "微型专项作业车", "重型专项作业车"
		};
	}

	public static string BstPost(Dictionary<string, object> data)
	{
		try
		{
			RestClient restClient = new RestClient(MainData.ServerIP + "/api/clientApi/GoodsInfoAdd");
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
			data["datestmp"] = DateTime.Now.ToString("yyyyMMddHHmmss");
			data["sign"] = MD5Encrypt(MainData.khdId + data["datestmp"]?.ToString() + "bst");
			string text = "";
			foreach (string key in data.Keys)
			{
				text = text + key + "=" + data[key]?.ToString() + "&";
			}
			restRequest.AddParameter("application/x-www-form-urlencoded", text.TrimEnd('&'), ParameterType.RequestBody);
			return restClient.Execute(restRequest).Content;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "BST货物接口请求异常" + ex.ToString());
			return "";
		}
	}

	public static string BstVehicleInfoPost(Dictionary<string, object> data)
	{
		try
		{
			RestClient restClient = new RestClient(MainData.ServerIP + "/api/clientApi/getVehicleInfo");
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
			data["datestmp"] = DateTime.Now.ToString("yyyyMMddHHmmss");
			data["sign"] = MD5Encrypt(MainData.khdId + data["datestmp"]?.ToString() + "bst");
			string text = "";
			foreach (string key in data.Keys)
			{
				text = text + key + "=" + data[key]?.ToString() + "&";
			}
			restRequest.AddParameter("application/x-www-form-urlencoded", text.TrimEnd('&'), ParameterType.RequestBody);
			return restClient.Execute(restRequest).Content;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "BST获取车牌接口请求异常" + ex.ToString());
			return "";
		}
	}

	public static void TXHGGetToken()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("appKey", MainData.TXappKey);
		dictionary.Add("appSecret", MainData.TXappSecret);
		TXHttpResultModel tXHGToken = GetTXHGToken(MainData.TXServer + "platform/auth/client-token", dictionary);
		if (tXHGToken != null && tXHGToken.code == 1)
		{
			MainData.TXToken = tXHGToken.data.ToString();
		}
	}

	public static void TXHGInOutUpLoad(string accesscontrolId, DateTime date, string licensePlate, string lane, string accessType, string iamge)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("recordId", Guid.NewGuid().ToString("N"));
		dictionary.Add("accesscontrolId", accesscontrolId);
		dictionary.Add("recordTime", date.ToString("yyyyMMddHHmm"));
		dictionary.Add("licensePlate", licensePlate);
		dictionary.Add("checkpoint", lane);
		dictionary.Add("lane", lane);
		if (accessType.Equals("入口"))
		{
			dictionary.Add("accessType", 0);
		}
		else
		{
			dictionary.Add("accessType", 1);
		}
		dictionary.Add("enabled", 1);
		dictionary.Add("carType", 0);
		dictionary.Add("passTime", date.ToString("yyyyMMddHHmmss"));
		dictionary.Add("actived", 1);
		dictionary.Add("img", ImageToBase64(iamge));
		dictionary.Add("creator", "A");
		dictionary.Add("createTime", date.ToString("yyyyMMddHHmmss"));
		dictionary.Add("updator", "A");
		dictionary.Add("updateTime", date.ToString("yyyyMMddHHmmss"));
		TXHttpResultModel tXHGData = GetTXHGData(MainData.TXServer + "api/closedmanage/scmaccessrecordvehicle/addOrUpdate", dictionary);
		if (tXHGData != null)
		{
			_ = tXHGData.code;
			_ = 1;
		}
	}

	public static TXHttpResultModel GetTXHGToken(string url, Dictionary<string, object> values)
	{
		JsonConvert.SerializeObject(values);
		RestClient restClient = new RestClient(url);
		restClient.Timeout = -1;
		RestRequest restRequest = new RestRequest(Method.POST);
		restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
		foreach (string key in values.Keys)
		{
			restRequest.AddParameter(key, values[key]);
		}
		restRequest.AddHeader("token", MainData.TXToken);
		restRequest.AddParameter("Token", MainData.TXToken);
		IRestResponse restResponse = restClient.Execute(restRequest);
		if (restResponse != null)
		{
			return JsonConvert.DeserializeObject<TXHttpResultModel>(restResponse.Content);
		}
		return null;
	}

	public static TXHttpResultModel GetTXHGData(string url, Dictionary<string, object> values)
	{
		string value = JsonConvert.SerializeObject(values);
		RestClient obj = new RestClient(url)
		{
			Timeout = -1
		};
		RestRequest restRequest = new RestRequest(Method.POST);
		restRequest.AddHeader("Content-Type", "application/json");
		if (!string.IsNullOrWhiteSpace(MainData.TXToken))
		{
			restRequest.AddHeader("token", MainData.TXToken);
		}
		restRequest.AddParameter("application/json", value, ParameterType.RequestBody);
		IRestResponse restResponse = obj.Execute(restRequest);
		if (restResponse != null)
		{
			return JsonConvert.DeserializeObject<TXHttpResultModel>(restResponse.Content);
		}
		return null;
	}

	public static List<string> GetCurrentComputerIP()
	{
		List<string> list = new List<string>();
		IPAddress[] addressList = Dns.GetHostEntry("").AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				list.Add(iPAddress.ToString());
			}
		}
		return list;
	}

	public static void SendYiJiu(VehicleNoInfoView vehicleNoInfoView)
	{
		new Dictionary<string, object>();
		PageModel pageModel = new PageModel();
		pageModel.PageIndex = 1;
		pageModel.PageSize = 1;
		List<IConditionalModel> conditionalList = new List<IConditionalModel>();
		List<tb_CarRecord> pageList = new DataServerContext<tb_CarRecord>().Current.GetPageList(conditionalList, pageModel, (tb_CarRecord it) => it.add_time, OrderByType.Desc);
		if (pageList != null)
		{
			_ = pageList.Count;
			_ = 0;
		}
	}

	public static void SendHeMei(VehicleNoInfoView vehicleNoInfoView)
	{
		HeiMeiVehicleRecordReal heiMeiVehicleRecordReal = new HeiMeiVehicleRecordReal();
		if (vehicleNoInfoView.ChannelType == "入口")
		{
			heiMeiVehicleRecordReal.type = 1;
		}
		else
		{
			heiMeiVehicleRecordReal.type = 2;
		}
		heiMeiVehicleRecordReal.entranceName = vehicleNoInfoView.ChannelName;
		heiMeiVehicleRecordReal.plateNum = vehicleNoInfoView.VehicleNo;
		heiMeiVehicleRecordReal.recDatetime = vehicleNoInfoView.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
		heiMeiVehicleRecordReal.colorTypeName = vehicleNoInfoView.licenseColor;
		heiMeiVehicleRecordReal.imgPath = ImageToBase64(vehicleNoInfoView.ImagePath);
		ClientHttpV2.GetYiJiuResultModel(MainData.cdpfUrl + "/eulec/notify/vehicleRecordReal", heiMeiVehicleRecordReal);
	}

	public static void UploadThirdParty(VehicleNoInfoView vehicleNoInfoView)
	{
		if (MainData.cdpfType == "易玖")
		{
			if (vehicleNoInfoView.ChannelType != "入口")
			{
				SendYiJiu(vehicleNoInfoView);
			}
		}
		else if (MainData.cdpfType == "禾美")
		{
			SendHeMei(vehicleNoInfoView);
		}
	}
}
