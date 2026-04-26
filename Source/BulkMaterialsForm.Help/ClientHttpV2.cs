// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.ClientHttpV2

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.Result;
using BulkMaterialsForm.Model.Result.YIJIU;
using BulkMaterialsForm.Model.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SqlSugar;

namespace BulkMaterialsForm.Help;

public class ClientHttpV2
{
	private static HttpListener serverComet = new HttpListener();

	public static string port = "14725";

	public static string serverIp = New_IniFile.ReadContentValue("基本设置", "服务地址", MainData.Spath);

	public static object obj = new object();

	public static Thread startThread;

	public static System.Timers.Timer timer = new System.Timers.Timer(10000.0);

	public static bool isLoadVehicle = false;
	public static int isLoadingVehicle = 0;

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

	private static void OnTimedEvent(object source, ElapsedEventArgs e)
	{
		try
		{
			if (Interlocked.CompareExchange(ref isLoadingVehicle, 1, 0) == 0)
			{
				Task.Factory.StartNew(delegate
				{
					try
					{
						GetVehicle();
					}
					finally
					{
						Interlocked.Exchange(ref isLoadingVehicle, 0);
					}
				});
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"[ListenForRequests] 预加载车辆失败: {ex.Message}");
			Interlocked.Exchange(ref isLoadingVehicle, 0);
		}
	}

	public static void InitTime()
	{
		timer.Elapsed += OnTimedEvent;
		timer.AutoReset = true;
		timer.Start();
	}

	public static void Init()
	{
		try
		{
			List<string> currentComputerIP = GetCurrentComputerIP();
			if (string.IsNullOrWhiteSpace(port))
			{
				return;
			}
			serverComet.Prefixes.Add("http://127.0.0.1:" + port + "/");
			foreach (string item in currentComputerIP)
			{
				serverComet.Prefixes.Add("http://" + item + ":" + port + "/");
			}
			serverComet.Start();
			startThread = new Thread(ListenForRequests);
			startThread.Start();
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"[Init] 启动HTTP服务失败: {ex.Message}");
			serverComet = new HttpListener();
		}
	}

	private static void ListenForRequests()
	{
		try
		{
			while (serverComet.IsListening)
			{
				HttpListenerContext context = serverComet.GetContext();
				Task.Factory.StartNew(HandleRequestRecordComet, context);
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"[ListenForRequests] 监听请求异常: {ex.Message}");
		}
	}

	private static void HandleRequestRecordComet(object o)
	{
		try
		{
			HttpListenerContext httpListenerContext = (HttpListenerContext)o;
			HttpListenerRequest request = httpListenerContext.Request;
			string value = null;
			using (StreamReader streamReader = new StreamReader(request.InputStream, Encoding.UTF8))
			{
				value = streamReader.ReadToEnd();
			}
			JObject jObject = JsonConvert.DeserializeObject<JObject>(value);
			lock (obj)
			{
				ResultModel resultModel = new ResultModel();
				try
				{
					if (httpListenerContext.Request.RawUrl == "/vehicleRecordReal")
					{
						PageModel pageModel = new PageModel();
						pageModel.PageIndex = 1;
						pageModel.PageSize = 10;
						string outType = "";
						List<IConditionalModel> list = new List<IConditionalModel>();
						if (jObject.ContainsKey("type"))
						{
							if (jObject["type"].ToString().Equals("1"))
							{
								outType = "入口";
							}
							else
							{
								outType = "出口";
							}
							ConditionalModel conditionalModel = new ConditionalModel();
							conditionalModel.FieldName = "out_type";
							conditionalModel.ConditionalType = ConditionalType.In;
							conditionalModel.FieldValue = outType;
							list.Add(conditionalModel);
						}
						DataServerContext<tb_CarRecord> dataServerContext = new DataServerContext<tb_CarRecord>();
						list.Add(new ConditionalModel
						{
							FieldName = "gateSignal",
							ConditionalType = ConditionalType.Equal,
							FieldValue = "摆杆通行"
						});
						List<tb_CarRecord> pageList = dataServerContext.Current.GetPageList(list, pageModel, (tb_CarRecord it) => it.add_time, OrderByType.Desc);
						List<HeiMeiVehicleRecordReal> list2 = new List<HeiMeiVehicleRecordReal>();
						tb_Channel model = new DataServerContext<tb_Channel>().Current.GetModel((tb_Channel it) => it.ChannelType == outType);
						if (pageList != null && pageList.Count > 0)
						{
							foreach (tb_CarRecord item2 in pageList)
							{
								HeiMeiVehicleRecordReal heiMeiVehicleRecordReal = new HeiMeiVehicleRecordReal();
								heiMeiVehicleRecordReal.id = item2.id;
								heiMeiVehicleRecordReal.type = Convert.ToInt32(jObject["type"].ToString());
								heiMeiVehicleRecordReal.entranceName = item2.ChannelPort;
								if (model != null)
								{
									heiMeiVehicleRecordReal.entranceId = model.id;
								}
								heiMeiVehicleRecordReal.plateNum = item2.ChannelPort;
								heiMeiVehicleRecordReal.recDatetime = item2.add_time.ToString("yyyy-MM-dd HH:mm:ss");
								heiMeiVehicleRecordReal.colorTypeName = item2.car_color;
								heiMeiVehicleRecordReal.imgPath = CommonHelper.ImageToBase64(item2.front_image);
								list2.Add(heiMeiVehicleRecordReal);
							}
						}
						resultModel.data = list2;
						resultModel.code = 200;
						resultModel.msg = "成功";
					}
					else if (httpListenerContext.Request.RawUrl == "/vehicleInfo")
					{
						PageModel pageModel2 = new PageModel();
						pageModel2.PageIndex = Convert.ToInt32(jObject["pageNo"]);
						pageModel2.PageSize = Convert.ToInt32(jObject["pageSize"]);
						DataServerContext<tb_vehicleInfoV2> dataServerContext2 = new DataServerContext<tb_vehicleInfoV2>();
						List<IConditionalModel> list3 = new List<IConditionalModel>();
						ConditionalModel conditionalModel2 = new ConditionalModel();
						if (jObject.ContainsKey("plateNum"))
						{
							conditionalModel2.FieldName = "vehicleNo";
							conditionalModel2.ConditionalType = ConditionalType.Like;
							conditionalModel2.FieldValue = jObject["plateNum"].ToString();
							list3.Add(conditionalModel2);
						}
						if (jObject.ContainsKey("vin"))
						{
							conditionalModel2.FieldName = "vin";
							conditionalModel2.ConditionalType = ConditionalType.Like;
							conditionalModel2.FieldValue = jObject["vin"].ToString();
							list3.Add(conditionalModel2);
						}
						if (jObject.ContainsKey("beginTime"))
						{
							conditionalModel2.FieldName = "addTime";
							conditionalModel2.ConditionalType = ConditionalType.GreaterThanOrEqual;
							conditionalModel2.FieldValue = jObject["beginTime"].ToString();
							list3.Add(conditionalModel2);
						}
						if (jObject.ContainsKey("endTime"))
						{
							conditionalModel2.FieldName = "addTime";
							conditionalModel2.ConditionalType = ConditionalType.LessThanOrEqual;
							conditionalModel2.FieldValue = jObject["endTime"].ToString();
							list3.Add(conditionalModel2);
						}
						List<tb_kayValue> list4 = new DataServerContext<tb_kayValue>().Current.GetList();
						List<vehicleInfoHM> list5 = new List<vehicleInfoHM>();
						List<tb_vehicleInfoV2> pageList2 = dataServerContext2.Current.GetPageList(list3, pageModel2, (tb_vehicleInfoV2 it) => it.addTime, OrderByType.Desc);
						if (pageList2 != null)
						{
							foreach (tb_vehicleInfoV2 item in pageList2)
							{
								vehicleInfoHM vehicleInfoHM2 = new vehicleInfoHM();
								vehicleInfoHM2.id = item.id;
								vehicleInfoHM2.plateNum = item.vehicleNo;
								vehicleInfoHM2.colorTypeName = list4.FirstOrDefault((tb_kayValue it) => it.id == Convert.ToInt32(item.licenseColor)).keyValue;
								vehicleInfoHM2.vehicleType = list4.FirstOrDefault((tb_kayValue it) => it.id == Convert.ToInt32(item.vehicleType)).keyValue;
								vehicleInfoHM2.teamName = item.onwer;
								vehicleInfoHM2.useNature = list4.FirstOrDefault((tb_kayValue it) => it.id == Convert.ToInt32(item.useCharacter)).keyValue;
								vehicleInfoHM2.vehicleModel = item.model;
								vehicleInfoHM2.vin = item.vin;
								vehicleInfoHM2.ein = item.engineNo;
								vehicleInfoHM2.einFactory = item.fzdw;
								vehicleInfoHM2.regDate = item.registerDate.ToString("yyyy-MM-dd HH:mm:ss");
								vehicleInfoHM2.billImg = CommonHelper.ImageToBase64(Application.StartupPath + "\\" + item.AccompanyingVehicleImg);
								vehicleInfoHM2.fleetName = item.cdmc;
								vehicleInfoHM2.phone = "";
								vehicleInfoHM2.driveFrontImg = CommonHelper.ImageToBase64(Application.StartupPath + "\\" + item.drivingFrontLicenseImg);
								vehicleInfoHM2.driveBackImg = CommonHelper.ImageToBase64(Application.StartupPath + "\\" + item.drivingBackLicenseImg);
								vehicleInfoHM2.fuel = list4.FirstOrDefault((tb_kayValue it) => it.id == Convert.ToInt32(item.licenseColor)).keyValue;
								vehicleInfoHM2.emissionType = list4.FirstOrDefault((tb_kayValue it) => it.id == Convert.ToInt32(item.licenseColor)).keyValue;
								vehicleInfoHM2.networkingStatus = "1";
								list5.Add(vehicleInfoHM2);
							}
							resultModel.data = list5;
						}
						resultModel.code = 200;
						resultModel.msg = "成功";
						resultModel.total = pageModel2.TotalCount;
					}
					else if (httpListenerContext.Request.RawUrl == "/weigRecord")
					{
						tb_Weig _Weig = JsonConvert.DeserializeObject<tb_Weig>(jObject.ToString());
						DataServerContext<tb_Weig> dataServerContext3 = new DataServerContext<tb_Weig>();
						tb_Weig model2 = dataServerContext3.Current.GetModel((tb_Weig it) => it.order_id == _Weig.order_id);
						if (model2 == null)
						{
							if (dataServerContext3.Current.Add(_Weig))
							{
								resultModel.code = 200;
								resultModel.msg = "成功";
							}
							else
							{
								resultModel.code = 0;
								resultModel.msg = "新增失败";
							}
						}
						else
						{
							model2.door_type = _Weig.door_type;
							model2.goods_type = _Weig.goods_type;
							model2.material_kind = _Weig.material_kind;
							model2.goods_name = _Weig.goods_name;
							model2.material_code = _Weig.material_code;
							model2.tare_weight = _Weig.tare_weight;
							model2.gross_weight = _Weig.gross_weight;
							model2.goods_suttle = _Weig.goods_suttle;
							model2.scale_time = _Weig.scale_time;
							model2.supplier_name = _Weig.supplier_name;
							model2.receiver_name = _Weig.receiver_name;
							if (dataServerContext3.Current.Modify(model2))
							{
								resultModel.code = 200;
								resultModel.msg = "成功";
							}
							else
							{
								resultModel.code = 0;
								resultModel.msg = "修改失败";
							}
						}
					}
					else
					{
						resultModel.code = 0;
						resultModel.msg = "接口不存在";
					}
				}
				catch (Exception ex)
				{
					resultModel.code = 0;
					resultModel.msg = "请求处理异常: " + ex.Message;
				}
				SendData(httpListenerContext.Response, resultModel);
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"[HandleRequestRecordComet] 处理请求异常: {ex.Message}");
		}
	}

	public static void SendData(HttpListenerResponse resp, ResultModel data)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
		resp.ContentType = "application/json";
		resp.SendChunked = false;
		resp.ContentEncoding = Encoding.UTF8;
		resp.ContentLength64 = bytes.Length;
		resp.OutputStream.Write(bytes, 0, bytes.Length);
		resp.OutputStream.Close();
	}

	public static async void GetVehicle()
	{
		if (string.IsNullOrWhiteSpace(MainData.cdpfQYId))
		{
			return;
		}
		object values = new Dictionary<string, object>
		{
			{
				"EnterpriseId",
				MainData.cdpfQYId
			},
			{
				"ClientCode",
				MainData.cdpfGTBM
			}
		};
		ClinetMsgResult resultModel = GetResultModel(MainData.cdpfXSZUrl + "/ComputerApi/ClientHeartBeat", values);
		if (resultModel == null || resultModel.code != 200 || resultModel.data == null || resultModel.data.Count <= 0)
		{
			return;
		}
		List<tb_kayValue> tb_KayValues = new DataServerContext<tb_kayValue>().Current.GetList();
		if (tb_KayValues == null)
		{
			return;
		}
		foreach (CmdEntity item in resultModel.data)
		{
			if (item.cmdType == 0)
			{
				Dictionary<string, object> keyValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.vehicleEntity.ToString());
				if (keyValues == null)
				{
					continue;
				}
				DataServerContext<tb_vehicleInfoV2> dataVehicleInfoV2Server = new DataServerContext<tb_vehicleInfoV2>();
				tb_vehicleInfoV2 tb_VehicleInfoV2 = dataVehicleInfoV2Server.Current.GetModel((tb_vehicleInfoV2 it) => it.vehicleNo == keyValues["vehicleNo"].ToString());
				if (tb_VehicleInfoV2 == null)
				{
					tb_VehicleInfoV2 = new tb_vehicleInfoV2
					{
						vehicleNo = keyValues["vehicleNo"].ToString(),
						vin = keyValues["vin"].ToString(),
						engineNo = keyValues["engineNo"].ToString(),
						onwer = keyValues["onwer"].ToString(),
						address = keyValues["address"].ToString(),
						model = keyValues["model"].ToString(),
						registerDate = Convert.ToDateTime(keyValues["registerDate"]),
						issueDate = Convert.ToDateTime(keyValues["issueDate"]),
						hdzzl = keyValues["hdzzl"].ToString(),
						fzdw = keyValues["fzdw"].ToString(),
						isApprove = Convert.ToInt32(keyValues["isApprove"]),
						hdzrs = keyValues["hdzrs"].ToString(),
						zzl = keyValues["zzl"].ToString(),
						zbzl = keyValues["zbzl"].ToString(),
						wkcc = keyValues["wkcc"].ToString(),
						jyjl = keyValues["jyjl"].ToString(),
						cdmc = keyValues["cdmc"].ToString(),
						Remark = keyValues["Remark"].ToString(),
						licenseColor = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.licenseColorId && it.keyType == "车牌颜色").id.ToString(),
						vehicleType = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.vehicleTypeId && it.keyType == "车辆类型").id.ToString(),
						fuelType = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.fuelTypeId && it.keyType == "燃油类型").id.ToString(),
						emissionStandard = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.emissionStandardId && it.keyType == "排放阶段").id.ToString(),
						useCharacter = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.useCharacterId && it.keyType == "使用性质").id.ToString()
					};
					if (keyValues["drivingFrontLicenseImg"] != null && !string.IsNullOrWhiteSpace(keyValues["drivingFrontLicenseImg"].ToString()))
					{
						tb_VehicleInfoV2.drivingFrontLicenseImg = "\\vehicleImage\\xszzm\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
						await DownloadImageAsync(keyValues["drivingFrontLicenseImg"].ToString(), tb_VehicleInfoV2.drivingFrontLicenseImg);
					}
					if (keyValues["drivingBackLicenseImg"] != null && !string.IsNullOrWhiteSpace(keyValues["drivingBackLicenseImg"].ToString()))
					{
						tb_VehicleInfoV2.drivingBackLicenseImg = "\\vehicleImage\\xszfm\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
						await DownloadImageAsync(keyValues["drivingBackLicenseImg"].ToString(), tb_VehicleInfoV2.drivingBackLicenseImg);
					}
					if (keyValues["AccompanyingVehicleImg"] != null && !string.IsNullOrWhiteSpace(keyValues["AccompanyingVehicleImg"].ToString()))
					{
						tb_VehicleInfoV2.AccompanyingVehicleImg = "\\vehicleImage\\scqd\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
						await DownloadImageAsync(keyValues["AccompanyingVehicleImg"].ToString(), tb_VehicleInfoV2.AccompanyingVehicleImg);
					}
					if (keyValues["frameImg"] != null && !string.IsNullOrWhiteSpace(keyValues["frameImg"].ToString()))
					{
						tb_VehicleInfoV2.frameImg = "\\vehicleImage\\cjzp\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
						await DownloadImageAsync(keyValues["frameImg"].ToString(), tb_VehicleInfoV2.frameImg);
					}
					if (dataVehicleInfoV2Server.Current.Add(tb_VehicleInfoV2))
					{
						UpLoad(tb_VehicleInfoV2, tb_KayValues, item);
					}
					else
					{
						LogSave.SaveExeLog(DateTime.Now.ToString() + "新增车牌失败");
					}
				}
				else
				{
					tb_VehicleInfoV2.vehicleNo = keyValues["vehicleNo"].ToString();
					tb_VehicleInfoV2.vin = keyValues["vin"].ToString();
					tb_VehicleInfoV2.engineNo = keyValues["engineNo"].ToString();
					tb_VehicleInfoV2.onwer = keyValues["onwer"].ToString();
					tb_VehicleInfoV2.address = keyValues["address"].ToString();
					tb_VehicleInfoV2.model = keyValues["model"].ToString();
					tb_VehicleInfoV2.registerDate = Convert.ToDateTime(keyValues["registerDate"]);
					tb_VehicleInfoV2.issueDate = Convert.ToDateTime(keyValues["issueDate"]);
					tb_VehicleInfoV2.hdzzl = keyValues["hdzzl"].ToString();
					tb_VehicleInfoV2.fzdw = keyValues["fzdw"].ToString();
					tb_VehicleInfoV2.isApprove = Convert.ToInt32(keyValues["isApprove"]);
					tb_VehicleInfoV2.hdzrs = keyValues["hdzrs"].ToString();
					tb_VehicleInfoV2.zzl = keyValues["zzl"].ToString();
					tb_VehicleInfoV2.zbzl = keyValues["zbzl"].ToString();
					tb_VehicleInfoV2.wkcc = keyValues["wkcc"].ToString();
					tb_VehicleInfoV2.jyjl = keyValues["jyjl"].ToString();
					tb_VehicleInfoV2.cdmc = keyValues["cdmc"].ToString();
					tb_VehicleInfoV2.Remark = keyValues["Remark"].ToString();
					tb_VehicleInfoV2.licenseColor = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.licenseColorId && it.keyType == "车牌颜色").id.ToString();
					tb_VehicleInfoV2.vehicleType = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.vehicleTypeId && it.keyType == "车辆类型").id.ToString();
					tb_VehicleInfoV2.fuelType = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.fuelTypeId && it.keyType == "燃油类型").id.ToString();
					tb_VehicleInfoV2.emissionStandard = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.emissionStandardId && it.keyType == "排放阶段").id.ToString();
					tb_VehicleInfoV2.useCharacter = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.useCharacterId && it.keyType == "使用性质").id.ToString();
					if (keyValues["drivingFrontLicenseImg"] != null && !string.IsNullOrWhiteSpace(keyValues["drivingFrontLicenseImg"].ToString()))
					{
						tb_VehicleInfoV2.drivingFrontLicenseImg = "\\vehicleImage\\xszzm\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
						await DownloadImageAsync(keyValues["drivingFrontLicenseImg"].ToString(), tb_VehicleInfoV2.drivingFrontLicenseImg);
					}
					if (keyValues["drivingBackLicenseImg"] != null && !string.IsNullOrWhiteSpace(keyValues["drivingBackLicenseImg"].ToString()))
					{
						tb_VehicleInfoV2.drivingBackLicenseImg = "\\vehicleImage\\xszfm\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
						await DownloadImageAsync(keyValues["drivingBackLicenseImg"].ToString(), tb_VehicleInfoV2.drivingBackLicenseImg);
					}
					if (keyValues["AccompanyingVehicleImg"] != null && !string.IsNullOrWhiteSpace(keyValues["AccompanyingVehicleImg"].ToString()))
					{
						tb_VehicleInfoV2.AccompanyingVehicleImg = "\\vehicleImage\\scqd\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
						await DownloadImageAsync(keyValues["AccompanyingVehicleImg"].ToString(), tb_VehicleInfoV2.AccompanyingVehicleImg);
					}
					if (keyValues["frameImg"] != null && !string.IsNullOrWhiteSpace(keyValues["frameImg"].ToString()))
					{
						tb_VehicleInfoV2.frameImg = "\\vehicleImage\\cjzp\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
						await DownloadImageAsync(keyValues["frameImg"].ToString(), tb_VehicleInfoV2.frameImg);
					}
					if (dataVehicleInfoV2Server.Current.Modify(tb_VehicleInfoV2))
					{
						UpLoad(tb_VehicleInfoV2, tb_KayValues, item);
					}
					else
					{
						LogSave.SaveExeLog(DateTime.Now.ToString() + "修改车牌失败");
					}
				}
			}
			else
			{
				if (item.cmdType != 1)
				{
					continue;
				}
				Dictionary<string, object> keyValues2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.vehicleEntity.ToString());
				DataServerContext<tb_vehicleInfoV2> dataServerContext = new DataServerContext<tb_vehicleInfoV2>();
				tb_vehicleInfoV2 tb_VehicleInfoV3 = dataServerContext.Current.GetModel((tb_vehicleInfoV2 it) => it.vehicleNo == keyValues2["vehicleNo"].ToString());
				if (tb_VehicleInfoV3 != null)
				{
					dataServerContext.Current.Modify((tb_vehicleInfoV2 p) => new tb_vehicleInfoV2
					{
						isApprove = Convert.ToInt32(keyValues2["isApprove"])
					}, (tb_vehicleInfoV2 p) => p.id == tb_VehicleInfoV3.id);
				}
			}
		}
	}

	public static ClinetMsgResult GetResultModel(string url, object values)
	{
		try
		{
			string value = JsonConvert.SerializeObject(values);
			RestClient obj = new RestClient(url)
			{
				Timeout = 30000
			};
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddHeader("Content-Type", "application/json");
			restRequest.AddParameter("application/json", value, ParameterType.RequestBody);
			IRestResponse restResponse = obj.Execute(restRequest);
			if (restResponse != null)
			{
				return JsonConvert.DeserializeObject<ClinetMsgResult>(restResponse.Content);
			}
			return null;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"[GetClientResultModel] 请求异常: {ex.Message}");
			return null;
		}
	}

	public static JiuYiMsgResult GetYiJiuResultModel(string url, object values)
	{
		try
		{
			string value = JsonConvert.SerializeObject(values);
			RestClient obj = new RestClient(url)
			{
				Timeout = 30000
			};
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddHeader("Content-Type", "application/json");
			restRequest.AddParameter("application/json", value, ParameterType.RequestBody);
			IRestResponse restResponse = obj.Execute(restRequest);
			if (restResponse != null)
			{
				LogSave.DSFLog(DateTime.Now.ToString() + "请求地址" + url + "返回内如" + restResponse.Content);
				return JsonConvert.DeserializeObject<JiuYiMsgResult>(restResponse.Content);
			}
			return null;
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"[GetYiJiuResultModel] 请求异常: {ex.Message}");
			return null;
		}
	}

	public static void UpLoad(tb_vehicleInfoV2 tb_VehicleInfoV2, List<tb_kayValue> tb_KayValues, CmdEntity item)
	{
		if (!(MainData.cdpfGTBM == "A"))
		{
			return;
		}
		if (MainData.cdpfType == "易玖")
		{
			YiJiuNotify yiJiuNotify = new YiJiuNotify();
			yiJiuNotify.car_code = tb_VehicleInfoV2.vehicleNo;
			yiJiuNotify.car_std = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.fuelTypeId && it.keyType == "燃油类型").keyValue;
			yiJiuNotify.car_type = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.vehicleTypeId && it.keyType == "车辆类型").keyValue;
			yiJiuNotify.car_vin = tb_VehicleInfoV2.vin;
			yiJiuNotify.engine_number = tb_VehicleInfoV2.engineNo;
			yiJiuNotify.license_date = tb_VehicleInfoV2.registerDate;
			yiJiuNotify.driving_license_img = MainData.cdpfIISImageUrl + tb_VehicleInfoV2.drivingFrontLicenseImg;
			yiJiuNotify.car_img = "";
			yiJiuNotify.list_img = MainData.cdpfIISImageUrl + tb_VehicleInfoV2.AccompanyingVehicleImg;
			yiJiuNotify.motorcade = tb_VehicleInfoV2.cdmc;
			yiJiuNotify.car_code_color = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.licenseColorId && it.keyType == "车牌颜色").keyValue;
			yiJiuNotify.car_brand = tb_VehicleInfoV2.model;
			yiJiuNotify.fuel_type = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.fuelTypeId && it.keyType == "燃油类型").keyValue;
			yiJiuNotify.obd = "1";
			yiJiuNotify.engine_model = "";
			yiJiuNotify.engine_plant = "";
			yiJiuNotify.std_query_img = "";
			yiJiuNotify.reviewer = "";
			yiJiuNotify.use_character = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.keyCode == item.useCharacterId && it.keyType == "使用性质").keyValue;
			yiJiuNotify.car_big_img = tb_VehicleInfoV2.vehicleNo;
			yiJiuNotify.fuel_std_img = "";
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("car", yiJiuNotify);
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			dictionary2.Add("data", dictionary);
			Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
			dictionary3.Add("data", dictionary2);
			GetYiJiuResultModel(MainData.cdpfUrl ?? "", dictionary3);
		}
		else if (MainData.cdpfType == "禾美")
		{
			vehicleInfoHM vehicleInfoHM2 = new vehicleInfoHM();
			vehicleInfoHM2.plateNum = tb_VehicleInfoV2.vehicleNo;
			vehicleInfoHM2.colorTypeName = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.id == Convert.ToInt32(tb_VehicleInfoV2.licenseColor)).keyValue;
			vehicleInfoHM2.vehicleType = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.id == Convert.ToInt32(tb_VehicleInfoV2.vehicleType)).keyValue;
			vehicleInfoHM2.teamName = tb_VehicleInfoV2.onwer;
			vehicleInfoHM2.useNature = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.id == Convert.ToInt32(tb_VehicleInfoV2.useCharacter)).keyValue;
			vehicleInfoHM2.vehicleModel = tb_VehicleInfoV2.model;
			vehicleInfoHM2.vin = tb_VehicleInfoV2.vin;
			vehicleInfoHM2.ein = tb_VehicleInfoV2.engineNo;
			vehicleInfoHM2.einFactory = tb_VehicleInfoV2.fzdw;
			vehicleInfoHM2.regDate = tb_VehicleInfoV2.registerDate.ToString("yyyy-MM-dd HH:mm:ss");
			vehicleInfoHM2.billImg = CommonHelper.ImageToBase64(Application.StartupPath + "\\" + tb_VehicleInfoV2.AccompanyingVehicleImg);
			vehicleInfoHM2.fleetName = tb_VehicleInfoV2.cdmc;
			vehicleInfoHM2.phone = "";
			vehicleInfoHM2.driveFrontImg = CommonHelper.ImageToBase64(Application.StartupPath + "\\" + tb_VehicleInfoV2.drivingFrontLicenseImg);
			vehicleInfoHM2.driveBackImg = CommonHelper.ImageToBase64(Application.StartupPath + "\\" + tb_VehicleInfoV2.drivingBackLicenseImg);
			vehicleInfoHM2.fuel = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.id == Convert.ToInt32(tb_VehicleInfoV2.fuelType)).keyValue;
			vehicleInfoHM2.emissionType = tb_KayValues.FirstOrDefault((tb_kayValue it) => it.id == Convert.ToInt32(tb_VehicleInfoV2.emissionStandard)).keyValue;
			vehicleInfoHM2.networkingStatus = "1";
			GetYiJiuResultModel(MainData.cdpfUrl + "/eulec/notify/vehicleInfo", vehicleInfoHM2);
		}
	}

	public static async Task<bool> DownloadImageAsync(string imageUrl, string savePath)
	{
		try
		{
			HttpClient httpClient = new HttpClient();
			savePath = Application.StartupPath + savePath;
			string directoryName = Path.GetDirectoryName(savePath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			byte[] array = await httpClient.GetByteArrayAsync(imageUrl);
			using (FileStream fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
			{
				fileStream.Write(array, 0, array.Length);
			}
			return true;
		}
		catch (Exception)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "下载图片失败" + imageUrl);
			return false;
		}
	}
}
