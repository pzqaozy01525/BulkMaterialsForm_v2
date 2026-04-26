// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.UserControlZS

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.LED;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;
using BulkMaterialsForm.SDK;
using Newtonsoft.Json;

namespace BulkMaterialsForm.View;

public class UserControlZS : UserControl, IVideoMngInterface
{
	public delegate void OpeningOperation(int msg, byte type);

	public delegate void CarRecord(VehicleNoInfoView vehicleNoInfoView);

	private delegate void SetButtonEnableThread();

	public tb_Channel tb_Channel;

	public tb_Device tb_Device;

	public int _logHandle = -1;

	private string id = Guid.NewGuid().ToString("N");

	private XNCResultModel xNCResultModel = new XNCResultModel();

	private DateTime lastDateTime = DateTime.Now.AddSeconds(-31.0);

	private Thread videoNetThread;

	private bool isClose;

	private int ID;

	public int m_nPlayHandle = -1;

	public int ZH_serial_handle = -1;

	public bool IsEnd;

	private IntPtr videoHandle;

	public tb_large_screen Tb_Large_Screen;

	public tb_ChannelSeniorSet seniorSet;

	public byte openType;

	public int openNumber;

	private object ZhenShi_lock = new object();

	private DateTime ioDate = DateTime.Now;

	private VzClientSDK.VZDEV_SERIAL_RECV_DATA_CALLBACK serial_recv_;

	private bool isrg;

	private IContainer components;

	private TableLayoutPanel tableLayoutPanel1;

	private TableLayoutPanel tableLayoutPanel2;

	private Button btnClose;

	private Button btnOpen;

	private Label lalCarNo;

	public GroupBox gboxheader;

	private PictureBox pboxQY;

	private Button LedSetTime;

	private System.Windows.Forms.Timer timer1;

	private Button button1;

	public static event OpeningOperation Operation;

	public event CarRecord carRecord;

	public UserControlZS()
	{
		InitializeComponent();
	}

	public void Init()
	{
		if (MainData.DJPT == "消纳场" && (tb_Device.deviceId == null || tb_Device.deviceId == ""))
		{
			List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("id", id);
			dictionary.Add("name", "进口车牌识别");
			dictionary.Add("addTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			if (tb_Device.CameraType == "监控相机")
			{
				dictionary.Add("type", 1);
			}
			else
			{
				dictionary.Add("type", 2);
			}
			dictionary.Add("disposalsiteId", MainData.disposalsiteId);
			list.Add(dictionary);
			LogSave.XNCLog(DateTime.Now.ToString() + "获取消纳场设备ID上传结构体" + JsonConvert.SerializeObject(list));
			xNCResultModel = CommonHelper.PoleXNCResultModel(MainData.XNCInOutServerUrl + MainData.XNCInOutEndpoint, MainData.XNCKEY, MainData.XNCSecret, list);
			if (xNCResultModel != null)
			{
				LogSave.XNCLog(DateTime.Now.ToString() + "获取消纳场设备ID返回内容" + JsonConvert.SerializeObject(xNCResultModel));
			}
			else
			{
				LogSave.XNCLog(DateTime.Now.ToString() + "获取消纳场设备ID返回内容为空");
			}
			if (xNCResultModel != null && xNCResultModel.code == 1)
			{
				if (!new DataServerContext<tb_Device>().Current.Modify((tb_Device p) => new tb_Device
				{
					deviceId = id
				}, (tb_Device p) => p.id == tb_Device.id))
				{
					LogSave.SaveExeLog(DateTime.Now.ToString() + "保存失败ID=" + tb_Device.id + "设备ID" + xNCResultModel.code);
				}
				tb_Device.deviceId = id;
			}
		}
		if (!MainData.sdtgqy)
		{
			btnOpen.Enabled = false;
		}
		try
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			videoHandle = pboxQY.Handle;
			gboxheader.Text = tb_Device.CameraName;
			Operation += UserControlQY_Operation;
			MqttClientService.openMessage += MqttClientService_openMessage;
			seniorSet = new DataServerContext<tb_ChannelSeniorSet>().Current.GetModel((tb_ChannelSeniorSet it) => it.ChannelId == tb_Channel.id);
			DataServerContext<tb_large_screen> dataServerContext = new DataServerContext<tb_large_screen>();
			Tb_Large_Screen = dataServerContext.Current.GetList((tb_large_screen it) => it.id == tb_Device.bigScreenId).FirstOrDefault();
			LogSave.YBLog(JsonConvert.SerializeObject(Tb_Large_Screen));
			LogSave.YBLog(JsonConvert.SerializeObject(tb_Device));
			OutSystem.carOutRecord += OutSystem_carOutRecord;
			TCPSeerver.carTcpRecord += TCPSeerver_carTcpRecord;
			timer1_Tick(null, null);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("ZS初始化异常" + ex.ToString());
		}
	}

	private void TCPSeerver_carTcpRecord(string ip, byte type)
	{
		try
		{
			if (tb_Device.bjip != null && tb_Device.OpeningMethod != null)
			{
				LogSave.XHTcpLog(DateTime.Now.ToString() + "本机" + tb_Device.bjip + ";;OpeningMethod=" + tb_Device.OpeningMethod + "发送" + ip + "type:" + type + "openType:" + openType);
				if (tb_Device.bjip.Equals(ip) && tb_Device.OpeningMethod == "0")
				{
					LogSave.XHTcpLog(DateTime.Now.ToString() + "匹配成功");
					barrierGate(type);
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "臻识TCPSeerver_carTcpRecord" + ex.ToString());
		}
	}

	private void OutSystem_carOutRecord(VehicleNoInfoView vehicleNoInfoView)
	{
		if (vehicleNoInfoView.devId != tb_Device.id)
		{
			return;
		}
		bool IsRelease;
		string text;
		string licenseColor;
		string imagePath;
		string imagePath2;
		if (vehicleNoInfoView.IsRelease)
		{
			IsRelease = true;
			text = vehicleNoInfoView.VehicleNo;
			licenseColor = vehicleNoInfoView.licenseColor;
			imagePath = vehicleNoInfoView.ImagePath;
			imagePath2 = vehicleNoInfoView.ImagePath;
			if (seniorSet == null)
			{
				goto IL_01d7;
			}
			string[] array = seniorSet.transitColour.Split(',');
			if (array != null && array.Length != 0 && !array.Contains(vehicleNoInfoView.licenseColor))
			{
				vehicleNoInfoView.ExeLog = "此通道禁止此车牌颜色通行";
				vehicleNoInfoView.TrafficStatus = "禁止通行";
				IsRelease = false;
			}
			else
			{
				string[] array2 = seniorSet.ColourWhiteList.Split(',');
				if (array2 == null || array2.Length == 0 || !array2.Contains(vehicleNoInfoView.licenseColor) || new DataServerContext<tb_car_info>().Current.GetModel((tb_car_info it) => it.car_no == vehicleNoInfoView.VehicleNo) != null)
				{
					goto IL_01d7;
				}
				vehicleNoInfoView.ExeLog = "此车牌号不属于白名单";
				vehicleNoInfoView.TrafficStatus = "禁止通行";
				IsRelease = false;
			}
			goto IL_0330;
		}
		if (this.carRecord != null)
		{
			this.carRecord(vehicleNoInfoView);
		}
		vehicleNoInfoView.ExeLog = "人工禁止通行";
		LEDPlay(IsRelease: false, vehicleNoInfoView);
		showVehicleNo(vehicleNoInfoView.VehicleNo + "人工禁止通行");
		return;
		IL_01d7:
		List<tb_car_info> list = new DataServerContext<tb_car_info>().Current.GetList((tb_car_info it) => it.car_no == vehicleNoInfoView.VehicleNo);
		if (list != null && list.Count > 0)
		{
			if (list[0].bz == "黑名单")
			{
				vehicleNoInfoView.TrafficStatus = "禁止通行";
				vehicleNoInfoView.ExeLog = "黑名单禁止通行";
				IsRelease = false;
			}
			else if (MainData.BMDSC)
			{
				goto IL_048c;
			}
		}
		else
		{
			if (!MainData.LSCSN)
			{
				goto IL_048c;
			}
			vehicleNoInfoView.ExeLog = "临时车禁止通行";
			IsRelease = false;
		}
		goto IL_0330;
		IL_048c:
		if (MainData.DJPT == "消纳场")
		{
			string text2 = "1";
			text2 = ((!(tb_Channel.ChannelType == "入口")) ? "2" : "1");
			string msg = "";
			if (CommonHelper.XNCVerify(text, licenseColor, tb_Device.deviceId, text2, ref msg))
			{
				if (MainData.RecordSave(imagePath2, imagePath, text, licenseColor, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null))
				{
					IsRelease = true;
				}
				else
				{
					vehicleNoInfoView.ExeLog = "保存失败！禁止通行";
					IsRelease = false;
				}
			}
			else
			{
				vehicleNoInfoView.ExeLog = msg;
				IsRelease = false;
			}
		}
		else if (MainData.DJPT == "高凌")
		{
			string text3 = "0";
			text3 = tb_Channel.ChannelPort;
			string msg2 = "";
			bool isUpload = false;
			bool isBlacklisted = false;
			List<tb_car_info> carList = new DataServerContext<tb_car_info>().Current.GetList((tb_car_info it) => it.car_no == vehicleNoInfoView.VehicleNo);
			if (carList != null && carList.Count > 0 && carList[0].bz == "黑名单")
			{
				IsRelease = false;
				isUpload = true;
				vehicleNoInfoView.ExeLog = "黑名单禁止通行";
				vehicleNoInfoView.TrafficStatus = "禁止通行";
				isBlacklisted = true;
			}
			if (!isBlacklisted && !CommonHelper.GLVerify(text, licenseColor, text3, ref msg2, ref vehicleNoInfoView))
			{
				IsRelease = false;
				isUpload = true;
				vehicleNoInfoView.ExeLog = msg2;
			}
			if (!MainData.RecordSave(imagePath2, imagePath, text, licenseColor, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView, isUpload))
			{
				IsRelease = false;
				vehicleNoInfoView.ExeLog = msg2 + ";;保存失败";
			}
		}
		else if (MainData.DJPT == "腾跃")
		{
			int num = -1;
			num = ((!(tb_Channel.ChannelType == "入口")) ? MainData.TYExitChannel : MainData.TYEnterChannel);
			string msg3 = "";
			bool isJS = false;
			if (CommonHelper.TYVerify(text, licenseColor, num, imagePath, ref msg3))
			{
				isJS = true;
				IsRelease = true;
			}
			else
			{
				IsRelease = false;
				vehicleNoInfoView.ExeLog = msg3;
			}
			if (!MainData.RecordSave(imagePath2, imagePath, text, licenseColor, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null, isUpload: false, "", isJS))
			{
				vehicleNoInfoView.ExeLog = "保存失败";
				IsRelease = false;
			}
		}
		else if (MainData.DJPT == "中科九州")
		{
			string text4 = "A";
			text4 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
			string msg4 = "";
			string text5 = "";
			string text6 = "";
			if (CommonHelper.KangFengV1Verify(text, licenseColor, tb_Channel.ChannelPort, text4, ref msg4, ref vehicleNoInfoView))
			{
				if (MainData.YZTZ)
				{
					if (CommonHelper.weiyouyuan(text, tb_Channel.ChannelType))
					{
						text6 = "未上传";
						text5 = "摆杆通行";
					}
					else
					{
						text5 = "未摆杆";
						text6 = "禁止上传";
						vehicleNoInfoView.ExeLog = "未补台账，禁止通行";
						IsRelease = false;
					}
				}
				else
				{
					text6 = "未上传";
					text5 = "摆杆通行";
				}
			}
			else
			{
				if (msg4.ToLower().IndexOf("token验证不通过") > 0)
				{
					MainData.KFV1Token = "";
				}
				text5 = "未摆杆";
				IsRelease = false;
				vehicleNoInfoView.ExeLog = msg4;
				if (vehicleNoInfoView.serialNum == null || string.IsNullOrWhiteSpace(vehicleNoInfoView.serialNum))
				{
					text6 = "禁止重复上传";
					goto IL_0330;
				}
				text6 = ((!MainData.barriergate_upload) ? "禁止上传" : "未上传");
			}
			if (!MainData.KaiFengRecordSave(imagePath2, imagePath, text, licenseColor, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text5, text6, ref vehicleNoInfoView))
			{
				vehicleNoInfoView.ExeLog = "保存失败";
				IsRelease = false;
			}
		}
		else if (MainData.DJPT == "安车")
		{
			string msg5 = "";
			string text7 = "";
			string text8 = "";
			if (CommonHelper.AnCheVerify(text, licenseColor, ref msg5, ref vehicleNoInfoView))
			{
				text8 = "未上传";
				text7 = "摆杆通行";
			}
			else
			{
				text8 = "禁止上传";
				text7 = "未摆杆";
				IsRelease = false;
				vehicleNoInfoView.ExeLog = msg5;
			}
			string text9 = "A";
			text9 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
			vehicleNoInfoView.serialNum = MainData.ACEnterpriseID + tb_Channel.ChannelPort + text9 + vehicleNoInfoView.AddTime.ToString("yyMMddHHmmss");
			if (!MainData.KaiFengRecordSave(imagePath2, imagePath, text, licenseColor, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text7, text8, ref vehicleNoInfoView))
			{
				vehicleNoInfoView.ExeLog = "保存失败";
				IsRelease = false;
			}
		}
		else if (MainData.DJPT == "天地人车")
		{
			string msg6 = "";
			string text10 = "";
			string text11 = "";
			if (CommonHelper.tdrcCheVerify(text, licenseColor, ref msg6, ref vehicleNoInfoView, tb_Channel.ChannelPort))
			{
				text11 = "未上传";
				text10 = "摆杆通行";
			}
			else
			{
				text11 = "禁止上传";
				text10 = "未摆杆";
				IsRelease = false;
				vehicleNoInfoView.ExeLog = msg6;
			}
			string text12 = "A";
			text12 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
			vehicleNoInfoView.serialNum = MainData.tdrcEnterpriseID + tb_Channel.ChannelPort + text12 + DateTime.Now.ToString("yyMMddHHmmss");
			if (!MainData.KaiFengRecordSave(imagePath2, imagePath, text, licenseColor, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text10, text11, ref vehicleNoInfoView))
			{
				vehicleNoInfoView.ExeLog = "保存失败";
				IsRelease = false;
			}
		}
		else if (MainData.DJPT == "信阳")
		{
			string msg7 = "";
			string text13 = "";
			string text14 = "";
			if (CommonHelper.xyCheVerify(text, licenseColor, ref msg7, ref vehicleNoInfoView))
			{
				text14 = "未上传";
				text13 = "摆杆通行";
			}
			else
			{
				text14 = "禁止上传";
				text13 = "未摆杆";
				IsRelease = false;
				vehicleNoInfoView.ExeLog = msg7;
			}
			string text15 = "A";
			text15 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
			vehicleNoInfoView.serialNum = MainData.xyOrgan + tb_Channel.ChannelPort + text15 + DateTime.Now.ToString("yyMMddHHmmss");
			if (!MainData.KaiFengRecordSave(imagePath2, imagePath, text, licenseColor, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text13, text14, ref vehicleNoInfoView))
			{
				vehicleNoInfoView.ExeLog = "保存失败";
				IsRelease = false;
			}
		}
		goto IL_0330;
		IL_0330:
		if (MainData.dnyybb)
		{
			Task.Factory.StartNew(delegate
			{
				string text16 = "禁止通行";
				if (IsRelease)
				{
					text16 = "允许通行";
					SpeechSynthesizer obj = new SpeechSynthesizer
					{
						Rate = 1,
						Volume = 100
					};
					text = vehicleNoInfoView.VehicleNo + vehicleNoInfoView.emissionStandard + vehicleNoInfoView.fuelType + text16;
					obj.Speak(text);
				}
				else
				{
					text16 = "禁止通行";
					SpeechSynthesizer obj2 = new SpeechSynthesizer
					{
						Rate = 1,
						Volume = 100
					};
					text = vehicleNoInfoView.VehicleNo + text16;
					obj2.Speak(text);
				}
			});
		}
		if (MainData.scfwq && IsRelease)
		{
			CommonHelper.BstPost(new Dictionary<string, object>
			{
				["licenseColor"] = licenseColor,
				["license"] = text,
				["doorCode"] = tb_Channel.ChannelPort,
				["lsh"] = vehicleNoInfoView.serialNum,
				["companyCode"] = MainData.khdId,
				["enterpriseId"] = MainData.khdId,
				["channelId"] = tb_Channel.id
			});
		}
		LEDPlay(IsRelease, vehicleNoInfoView);
		if (this.carRecord != null)
		{
			this.carRecord(vehicleNoInfoView);
		}
		if (IsRelease && MainData.TXIsOpen)
		{
			CommonHelper.TXHGInOutUpLoad(tb_Channel.guid, vehicleNoInfoView.AddTime, vehicleNoInfoView.VehicleNo, tb_Channel.ChannelName, tb_Channel.ChannelType, vehicleNoInfoView.ImagePath);
		}
		showVehicleNo(text + vehicleNoInfoView.TrafficStatus);
	}

	private void MqttClientService_openMessage(string channelId)
	{
		if (tb_Channel.id == Convert.ToInt32(channelId))
		{
			openNumber = 0;
			if (tb_Device.OpeningMethod == "0")
			{
				openType = 2;
				Open();
			}
			else if (UserControlZS.Operation != null)
			{
				UserControlZS.Operation(Convert.ToInt32(tb_Device.OpeningMethod), 2);
			}
		}
	}

	private void UserControlQY_Operation(int msg, byte type)
	{
		openType = type;
		if (tb_Device.id == msg)
		{
			Open();
		}
	}

	public void Open()
	{
		VzClientSDK.VzLPRClient_SetIOOutputAuto(_logHandle, 0, 500);
	}

	public void Snap(string model)
	{
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(model);
		if (tb_Device.ChannelNo == Convert.ToInt32(dictionary["ChannelNo"]) && tb_Device.id != Convert.ToInt32(dictionary["DeviceId"]))
		{
			ID = Convert.ToInt32(dictionary["id"]);
			string text = FormHelper.BuildImagePath(MainData.strImageDir, "jpg");
			if (VzClientSDK.VzLPRClient_GetSnapShootToJpeg2(m_nPlayHandle, text, 80) == 0)
			{
				DataServerContext<tb_ImageDetaile> dataServerContext = new DataServerContext<tb_ImageDetaile>();
				tb_ImageDetaile model2 = new tb_ImageDetaile
				{
					detaileID = Convert.ToInt32(dictionary["id"]),
					ImagePath = text
				};
				dataServerContext.Current.Add(model2);
			}
		}
	}

	public void StartVideoNetThread()
	{
		videoNetThread = new Thread(videoClientStartPlay);
		videoNetThread.IsBackground = false;
		videoNetThread.Start();
	}

	public void videoClientStartPlay()
	{
		while (!isClose)
		{
			if ((DateTime.Now - lastDateTime).TotalSeconds >= 3.0 && !IsEnd)
			{
				IsEnd = true;
				videoClientOpen_ZhenShi();
				lastDateTime = DateTime.Now;
				if (isClose)
				{
					break;
				}
			}
			Thread.Sleep(150);
		}
	}

	public void videoClientOpen_ZhenShi()
	{
		lock (ZhenShi_lock)
		{
			if (_logHandle < 0)
			{
				try
				{
					short num = short.Parse("80");
					string pStrUserName = "admin";
					string pStrPassword = "admin";
					_logHandle = VzClientSDK.VzLPRClient_Open(tb_Device.CameraIP, (ushort)num, pStrUserName, pStrPassword);
					if (_logHandle == -1)
					{
						setButtonEnable(btEnable: false);
						return;
					}
					m_nPlayHandle = VzClientSDK.VzLPRClient_StartRealPlay(_logHandle, videoHandle);
					if (_logHandle != -1 && m_nPlayHandle != -1)
					{
						MainData.HtZhenShiCallBackDel[_logHandle] = new MainData.video_ZhenShi_VZLPRC_PLATE_INFO_CALLBACK(video_ZhenShi_CALLBACK);
						VzClientSDK.VzLPRClient_SetPlateInfoCallBack(_logHandle, MainData.m_PlateResultCB, IntPtr.Zero, 1);
						MainData.HtZhenShiCallBackIO[_logHandle] = new MainData.video_VZLPRC_GPIO_RECV_CALLBACK(OnserialRECV);
						VzClientSDK.VzLPRClient_SetGPIORecvCallBack(_logHandle, MainData.m_gpio_recvCB, IntPtr.Zero);
						ZH_serial_handle = VzClientSDK.VzLPRClient_SerialStart(_logHandle, 0, null, IntPtr.Zero);
						LogSave.ZSLog("ip=" + tb_Device.CameraIP + "_logHandle=" + _logHandle + ";;ZH_serial_handle" + ZH_serial_handle);
						VzClientSDK.VzLPRClient_SetOfflineCheck(_logHandle);
						setButtonEnable(btEnable: true);
					}
					else
					{
						setButtonEnable(btEnable: false);
					}
				}
				catch (Exception)
				{
				}
			}
		}
		IsEnd = false;
	}

	private void OnserialRECV(int handle, int nGPIOId, int nVal, IntPtr pUserData)
	{
		LogSave.ZSLog(DateTime.Now.ToString() + "openType=" + openType + ";nVal=" + nVal);
		if (handle == _logHandle && tb_Device.OpeningMethod == "0")
		{
			barrierGate((byte)nVal);
		}
	}

	public int video_ZhenShi_CALLBACK(int handle, IntPtr pUserData, IntPtr pResult, uint uNumPlates, VzClientSDK.VZ_LPRC_RESULT_TYPE eResultType, IntPtr pImgFull, IntPtr pImgPlateClip)
	{
		try
		{
			LogSave.ZSLog(DateTime.Now.ToString() + "识别");
			if (MainData.IsBecomeDue)
			{
				isrg = false;
				return 0;
			}
			string text;
			string text2;
			string text3;
			string text4;
			bool IsRelease;
			VehicleNoInfoView vehicleNoInfoView;
			if (eResultType != VzClientSDK.VZ_LPRC_RESULT_TYPE.VZ_LPRC_RESULT_REALTIME && handle == _logHandle && pResult != IntPtr.Zero)
			{
				VzClientSDK.TH_PlateResult tH_PlateResult = (VzClientSDK.TH_PlateResult)Marshal.PtrToStructure(pResult, typeof(VzClientSDK.TH_PlateResult));
				if (tH_PlateResult.license != null)
				{
					text = new string(tH_PlateResult.license).TrimEnd(default(char));
					if (text.Length > 5)
					{
						_ = DateTime.Now;
						text2 = new string(tH_PlateResult.color).TrimEnd(default(char));
						text3 = "";
						DateTime now = DateTime.Now;
						text3 = FormHelper.BuildImagePath(MainData.strImageDir, "jpg");
						VzClientSDK.VzLPRClient_ImageSaveToJpeg(pImgFull, text3, 80);
						text4 = FormHelper.BuildImagePath(MainData.strImageDir, "jpg", "cp");
						showVehicleNo(text + "，平台验证中！");
						LedPrompt(text);
						if (!(tb_Device.CameraType == "标准相机"))
						{
							goto IL_06b4;
						}
						IsRelease = true;
						vehicleNoInfoView = new VehicleNoInfoView();
						vehicleNoInfoView.VehicleNo = text;
						vehicleNoInfoView.AddTime = DateTime.Now;
						vehicleNoInfoView.ChannelName = tb_Channel.ChannelName;
						vehicleNoInfoView.DeviceName = tb_Device.CameraName;
						vehicleNoInfoView.ChannelType = tb_Channel.ChannelType;
						vehicleNoInfoView.ImagePath = text3;
						vehicleNoInfoView.largeId = tb_Device.bigScreenId;
						vehicleNoInfoView.licenseColor = text2;
						vehicleNoInfoView.ChannelId = tb_Device.ChannelNo;
						vehicleNoInfoView.devId = tb_Device.id;
						if (!isrg)
						{
							if (seniorSet == null)
							{
								goto IL_0372;
							}
							string[] array = seniorSet.transitColour.Split(',');
							if (array != null && array.Length != 0 && !array.Contains(text2))
							{
								vehicleNoInfoView.ExeLog = "此通道禁止此车牌颜色通行";
								vehicleNoInfoView.TrafficStatus = "禁止通行";
							}
							else
							{
								string[] array2 = seniorSet.ColourWhiteList.Split(',');
								if (array2 == null || array2.Length == 0 || !array2.Contains(text2) || new DataServerContext<tb_car_info>().Current.GetModel((tb_car_info it) => it.car_no == text) != null)
								{
									goto IL_0372;
								}
								vehicleNoInfoView.ExeLog = "此车牌号不属于白名单";
								vehicleNoInfoView.TrafficStatus = "禁止通行";
							}
							goto IL_0564;
						}
						goto IL_0f5b;
					}
					LogSave.ZSLog(DateTime.Now.ToString() + "isrg");
					isrg = false;
					return 0;
				}
				LogSave.ZSLog(DateTime.Now.ToString() + "isrg");
				isrg = false;
				return 0;
			}
			LogSave.ZSLog(DateTime.Now.ToString() + "isrg");
			isrg = false;
			return 0;
			IL_06dc:
			if (MainData.DJPT == "高凌")
			{
				string text5 = "0";
				text5 = tb_Channel.ChannelPort;
				string msg = "";
				bool isUpload = false;
				bool isBlacklisted = false;
				List<tb_car_info> carList = new DataServerContext<tb_car_info>().Current.GetList((tb_car_info it) => it.car_no == vehicleNoInfoView.VehicleNo);
				if (carList != null && carList.Count > 0 && carList[0].bz == "黑名单")
				{
					IsRelease = false;
					isUpload = true;
					vehicleNoInfoView.ExeLog = "黑名单禁止通行";
					vehicleNoInfoView.TrafficStatus = "禁止通行";
					isBlacklisted = true;
				}
				if (!isBlacklisted && !CommonHelper.GLVerify(text, vehicleNoInfoView.licenseColor, text5, ref msg, ref vehicleNoInfoView))
				{
					IsRelease = false;
					isUpload = true;
					vehicleNoInfoView.ExeLog = msg;
				}
				VzClientSDK.VzLPRClient_ImageSaveToJpeg(pImgPlateClip, text4, 80);
				if (!MainData.RecordSave(text4, text3, text, text2, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView, isUpload))
				{
					IsRelease = false;
					vehicleNoInfoView.ExeLog = msg + ";;保存失败";
				}
			}
			else if (MainData.DJPT == "中科九州")
			{
				string text6 = "A";
				text6 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
				string msg2 = "";
				string text7 = "";
				string text8 = "";
				if (CommonHelper.KangFengV1Verify(text, text2, tb_Channel.ChannelPort, text6, ref msg2, ref vehicleNoInfoView))
				{
					if (MainData.YZTZ)
					{
						if (CommonHelper.weiyouyuan(text, tb_Channel.ChannelType))
						{
							text8 = "未上传";
							text7 = "摆杆通行";
						}
						else
						{
							text7 = "未摆杆";
							text8 = "禁止上传";
							IsRelease = false;
							vehicleNoInfoView.ExeLog = "未补台账，禁止通行";
						}
					}
					else
					{
						text8 = "未上传";
						text7 = "摆杆通行";
					}
				}
				else
				{
					text7 = "未摆杆";
					IsRelease = false;
					vehicleNoInfoView.ExeLog = msg2;
					if (vehicleNoInfoView.serialNum == null || string.IsNullOrWhiteSpace(vehicleNoInfoView.serialNum))
					{
						text8 = "禁止重复上传";
						goto IL_0564;
					}
					text8 = ((!MainData.barriergate_upload) ? "禁止上传" : "未上传");
				}
				VzClientSDK.VzLPRClient_ImageSaveToJpeg(pImgPlateClip, text4, 80);
				if (!MainData.KaiFengRecordSave(text4, text3, text, text2, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text7, text8, ref vehicleNoInfoView))
				{
					vehicleNoInfoView.ExeLog = "保存失败";
					IsRelease = false;
				}
			}
			else if (MainData.DJPT == "安车")
			{
				string msg3 = "";
				string text9 = "";
				string text10 = "";
				if (CommonHelper.AnCheVerify(text, text2, ref msg3, ref vehicleNoInfoView, tb_Channel.ChannelPort))
				{
					text10 = "未上传";
					text9 = "摆杆通行";
				}
				else
				{
					text10 = "禁止上传";
					text9 = "未摆杆";
					IsRelease = false;
					vehicleNoInfoView.ExeLog = msg3;
				}
				string text11 = "A";
				text11 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
				vehicleNoInfoView.serialNum = MainData.ACEnterpriseID + tb_Channel.ChannelPort + text11 + vehicleNoInfoView.AddTime.ToString("yyMMddHHmmss");
				VzClientSDK.VzLPRClient_ImageSaveToJpeg(pImgPlateClip, text4, 80);
				if (!MainData.KaiFengRecordSave(text4, text3, text, text2, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text9, text10, ref vehicleNoInfoView))
				{
					vehicleNoInfoView.ExeLog = "保存失败";
					IsRelease = false;
				}
			}
			else if (MainData.DJPT == "腾跃")
			{
				int num = -1;
				num = ((!(tb_Channel.ChannelType == "入口")) ? MainData.TYExitChannel : MainData.TYEnterChannel);
				string msg4 = "";
				bool flag = false;
				if (CommonHelper.TYVerify(text, text2, num, text3, ref msg4))
				{
					flag = true;
					IsRelease = true;
					VzClientSDK.VzLPRClient_ImageSaveToJpeg(pImgPlateClip, text4, 80);
					if (!MainData.RecordSave(text4, text3, text, text2, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null, isUpload: false, "", flag))
					{
						vehicleNoInfoView.ExeLog = "保存失败";
						IsRelease = false;
					}
				}
				else
				{
					IsRelease = false;
					vehicleNoInfoView.ExeLog = msg4;
				}
			}
			else if (MainData.DJPT == "消纳场")
			{
				string text12 = "1";
				text12 = ((!(tb_Channel.ChannelType == "入口")) ? "2" : "1");
				string msg5 = "";
				if (CommonHelper.XNCVerify(text, text2, tb_Device.deviceId, text12, ref msg5))
				{
					VzClientSDK.VzLPRClient_ImageSaveToJpeg(pImgPlateClip, text4, 80);
					if (MainData.RecordSave(text4, text3, text, text4, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null))
					{
						IsRelease = true;
					}
					else
					{
						vehicleNoInfoView.ExeLog = "保存失败！禁止通行";
						IsRelease = false;
					}
				}
				else
				{
					vehicleNoInfoView.ExeLog = msg5;
					IsRelease = false;
				}
			}
			else if (MainData.DJPT == "天地人车")
			{
				string msg6 = "";
				string text13 = "";
				string text14 = "";
				if (CommonHelper.tdrcCheVerify(text, text2, ref msg6, ref vehicleNoInfoView, tb_Channel.ChannelPort))
				{
					text14 = "未上传";
					text13 = "摆杆通行";
				}
				else
				{
					text14 = "禁止上传";
					text13 = "未摆杆";
					IsRelease = false;
					vehicleNoInfoView.ExeLog = msg6;
				}
				string text15 = "A";
				text15 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
				vehicleNoInfoView.serialNum = MainData.tdrcEnterpriseID + tb_Channel.ChannelPort + text15 + DateTime.Now.ToString("yyMMddHHmmss");
				VzClientSDK.VzLPRClient_ImageSaveToJpeg(pImgPlateClip, text4, 80);
				if (!MainData.KaiFengRecordSave(text4, text3, text, text2, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text13, text14, ref vehicleNoInfoView))
				{
					vehicleNoInfoView.ExeLog = "保存失败";
					IsRelease = false;
				}
			}
			else if (MainData.DJPT == "信阳")
			{
				string msg7 = "";
				string text16 = "";
				string text17 = "";
				if (CommonHelper.xyCheVerify(text, text2, ref msg7, ref vehicleNoInfoView))
				{
					text17 = "未上传";
					text16 = "摆杆通行";
				}
				else
				{
					text17 = "禁止上传";
					text16 = "未摆杆";
					IsRelease = false;
					vehicleNoInfoView.ExeLog = msg7;
				}
				string text18 = "A";
				text18 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
				vehicleNoInfoView.serialNum = MainData.xyOrgan + tb_Channel.ChannelPort + text18 + DateTime.Now.ToString("yyMMddHHmmss");
				VzClientSDK.VzLPRClient_ImageSaveToJpeg(pImgPlateClip, text4, 80);
				if (!MainData.KaiFengRecordSave(text4, text3, text, text2, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text16, text17, ref vehicleNoInfoView))
				{
					vehicleNoInfoView.ExeLog = "保存失败";
					IsRelease = false;
				}
			}
			goto IL_0564;
			IL_0564:
			if (MainData.dnyybb)
			{
				Task.Factory.StartNew(delegate
				{
					string text19 = "禁止通行";
					if (IsRelease)
					{
						text19 = "允许通行";
						SpeechSynthesizer obj = new SpeechSynthesizer
						{
							Rate = 1,
							Volume = 100
						};
						text = vehicleNoInfoView.VehicleNo + vehicleNoInfoView.emissionStandard + vehicleNoInfoView.fuelType + text19;
						obj.Speak(text);
					}
					else
					{
						text19 = "禁止通行";
						SpeechSynthesizer obj2 = new SpeechSynthesizer
						{
							Rate = 1,
							Volume = 100
						};
						text = vehicleNoInfoView.VehicleNo + text19;
						obj2.Speak(text);
					}
				});
			}
			if (MainData.scfwq && IsRelease)
			{
				CommonHelper.BstPost(new Dictionary<string, object>
				{
					["licenseColor"] = text2,
					["license"] = text,
					["doorCode"] = tb_Channel.ChannelPort,
					["lsh"] = vehicleNoInfoView.serialNum,
					["companyCode"] = MainData.khdId,
					["enterpriseId"] = MainData.khdId,
					["channelId"] = tb_Channel.id
				});
			}
			LEDPlay(IsRelease, vehicleNoInfoView);
			if (this.carRecord != null)
			{
				this.carRecord(vehicleNoInfoView);
			}
			if (IsRelease && MainData.TXIsOpen)
			{
				CommonHelper.TXHGInOutUpLoad(tb_Channel.guid, vehicleNoInfoView.AddTime, vehicleNoInfoView.VehicleNo, tb_Channel.ChannelName, tb_Channel.ChannelType, vehicleNoInfoView.ImagePath);
			}
			showVehicleNo(text);
			goto IL_0f5b;
			IL_06b4:
			LogSave.ZSLog(DateTime.Now.ToString() + text + "车牌结束");
			goto end_IL_0000;
			IL_0372:
			List<tb_car_info> list = new DataServerContext<tb_car_info>().Current.GetList((tb_car_info it) => it.car_no == text);
			if (list != null && list.Count > 0)
			{
				if (list[0].bz == "黑名单")
				{
					vehicleNoInfoView.TrafficStatus = "禁止通行";
					vehicleNoInfoView.ExeLog = "黑名单禁止通行";
				}
				else if (!(vehicleNoInfoView.AddTime >= list[0].startTime) || !(vehicleNoInfoView.AddTime <= list[0].endTime))
				{
					vehicleNoInfoView.TrafficStatus = "禁止通行";
					vehicleNoInfoView.ExeLog = "未在有效期以内";
				}
				else if (MainData.BMDSC)
				{
					goto IL_06dc;
				}
			}
			else
			{
				if (MainData.SDZK)
				{
					isrg = true;
					goto IL_0f5b;
				}
				if (!MainData.LSCSN)
				{
					goto IL_06dc;
				}
				vehicleNoInfoView.ExeLog = "临时车禁止通行";
				IsRelease = false;
			}
			goto IL_0564;
			IL_0f5b:
			if (isrg)
			{
				isrg = false;
				OutSystem.AddOut(vehicleNoInfoView);
			}
			goto IL_06b4;
			end_IL_0000:;
		}
		catch (Exception ex)
		{
			LogSave.ZSLog(DateTime.Now.ToString() + "臻识车牌识别异常" + ex.Message);
		}
		return 0;
	}

	public void LEDPlay(bool IsRelease, VehicleNoInfoView vehicleNoInfoView)
	{
		if (!IsRelease)
		{
			Led(vehicleNoInfoView.VehicleNo, isOpen: false);
			vehicleNoInfoView.TrafficStatus = "禁止通行";
			LedPlay(vehicleNoInfoView, isOpen: false);
			return;
		}
		if (!MainData.bxtxhw)
		{
			if (tb_Device.OpeningMethod == "0")
			{
				openType = 2;
				Open();
			}
			else if (UserControlZS.Operation != null)
			{
				UserControlZS.Operation(Convert.ToInt32(tb_Device.OpeningMethod), 2);
			}
		}
		Led(vehicleNoInfoView.VehicleNo, isOpen: true);
		vehicleNoInfoView.TrafficStatus = "允许通行";
		vehicleNoInfoView.ExeLog = "允许通行";
		LedPlay(vehicleNoInfoView, isOpen: true);
	}

	private void setButtonEnable(bool btEnable)
	{
		SetButtonEnableThread method = delegate
		{
			btnOpen.Enabled = btEnable;
			btnClose.Enabled = btEnable;
		};
		try
		{
			Invoke(method);
		}
		catch (Exception)
		{
		}
	}

	private void btnOpen_Click(object sender, EventArgs e)
	{
		if (tb_Device.OpeningMethod == "0")
		{
			if (MainData.dnyybb)
			{
				Task.Factory.StartNew(delegate
				{
					SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
					speechSynthesizer.Rate = 1;
					speechSynthesizer.Volume = 100;
					string textToSpeak = "请注意手动抬杆";
					speechSynthesizer.Speak(textToSpeak);
				});
			}
			openType = 1;
			Open();
		}
		else if (UserControlZS.Operation != null)
		{
			UserControlZS.Operation(Convert.ToInt32(tb_Device.OpeningMethod), 1);
		}
	}

	public void DeviceOpen(string carNo)
	{
		if (tb_Device.OpeningMethod == "0")
		{
			Open();
		}
		else
		{
			_ = UserControlZS.Operation;
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		DateTime start = DateTime.Now.AddSeconds(-120.0);
		DateTime end = DateTime.Now.AddSeconds(-60.0);
		string sVideoFileName = Path.Combine(MainData.strImageDir, DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".mp4");
		new HKSDK();
		MainData.hKLXJ.Add(start, end, 1, 1, sVideoFileName);
	}

	public void showVehicleNo(string vehicleNo)
	{
		lalCarNo.Invoke((Action<string>)delegate(string p)
		{
			lalCarNo.Text = p;
		}, vehicleNo);
	}

	public void LedPrompt(string text)
	{
		if (tb_Device.motherboardType == "FK")
		{
			byte[] ledTextByte = BulkMaterialsForm.LED.LED.GetLedTextByte(text, 1);
			Send485(ledTextByte);
			Thread.Sleep(50);
			ledTextByte = BulkMaterialsForm.LED.LED.GetLedTextByte("平台验证中请稍等", 2);
			Send485(ledTextByte);
			Thread.Sleep(50);
		}
		else if (tb_Device.motherboardType == "KF")
		{
			byte[] data = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(0, text, 0, 60);
			Send485(data);
			Thread.Sleep(50);
			data = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(1, "平台验证中请稍等", 0, 60);
			Send485(data);
		}
	}

	public void Led(string VehicleNo, bool isOpen)
	{
		if (tb_Device.motherboardType == "FK")
		{
			if (isOpen)
			{
				List<int> list = new List<int>();
				list.Add(40);
				byte[] data = BulkMaterialsForm.LED.LED.FangKongStandardVoiceByte(VehicleNo, list);
				Send485(data);
			}
			else
			{
				List<int> list2 = new List<int>();
				list2.Add(43);
				byte[] data2 = BulkMaterialsForm.LED.LED.FangKongStandardVoiceByte(VehicleNo, list2);
				Send485(data2);
			}
		}
		else
		{
			if (!(tb_Device.motherboardType == "KF"))
			{
				return;
			}
			if (isOpen)
			{
				byte[] data3;
				if (tb_Channel.ChannelType == "出口")
				{
					data3 = BulkMaterialsForm.LED.LED.KeFa_SoundPlay(0, VehicleNo + "一路顺风");
					Send485(data3);
				}
				else
				{
					data3 = BulkMaterialsForm.LED.LED.KeFa_SoundPlay(0, VehicleNo + "欢迎光临");
					Send485(data3);
				}
				Thread.Sleep(50);
				data3 = BulkMaterialsForm.LED.LED.KeFa_LedLampLan(0);
				Send485(data3);
				Thread.Sleep(50);
				data3 = BulkMaterialsForm.LED.LED.KeFa_LedLampLv(0);
				Send485(data3);
			}
			else
			{
				byte[] data4 = BulkMaterialsForm.LED.LED.KeFa_SoundPlay(0, VehicleNo + "禁止通行");
				Send485(data4);
			}
		}
	}

	public void LedPlay(VehicleNoInfoView vehicleNoInfoView, bool isOpen)
	{
		if (MainData.DPLX == "YB")
		{
			try
			{
				if (Tb_Large_Screen != null)
				{
					LogSave.YBLog("进入大屏流程");
					YB_SDK.YBLedSendMes(Tb_Large_Screen, vehicleNoInfoView, isOpen);
				}
			}
			catch (Exception ex)
			{
				LogSave.YBLog(DateTime.Now.ToString() + "大屏异常" + ex.ToString());
			}
		}
		else if (MainData.DPLX == "ZH")
		{
			ZHSDK.SendZH(vehicleNoInfoView);
		}
		else
		{
			FKTcp.Send(vehicleNoInfoView);
		}
		if (tb_Device.motherboardType == "FK")
		{
			if (isOpen)
			{
				byte[] ledTextByte = BulkMaterialsForm.LED.LED.GetLedTextByte(vehicleNoInfoView.VehicleNo, 1);
				Send485(ledTextByte);
				Thread.Sleep(50);
				ledTextByte = BulkMaterialsForm.LED.LED.GetLedTextByte("燃料类型:" + vehicleNoInfoView.fuelType, 2);
				Send485(ledTextByte);
				Thread.Sleep(50);
				ledTextByte = BulkMaterialsForm.LED.LED.GetLedTextByte("排放阶段:" + vehicleNoInfoView.emissionStandard, 3);
				Send485(ledTextByte);
				Thread.Sleep(50);
				ledTextByte = BulkMaterialsForm.LED.LED.GetLedTextByte(vehicleNoInfoView.TrafficStatus, 4);
				Send485(ledTextByte);
				Thread.Sleep(50);
			}
			else
			{
				byte[] ledTextByte2 = BulkMaterialsForm.LED.LED.GetLedTextByte(vehicleNoInfoView.VehicleNo, 1);
				Send485(ledTextByte2);
				Thread.Sleep(50);
				ledTextByte2 = BulkMaterialsForm.LED.LED.GetLedTextByte("燃料类型:" + vehicleNoInfoView.fuelType, 2);
				Send485(ledTextByte2);
				Thread.Sleep(50);
				ledTextByte2 = BulkMaterialsForm.LED.LED.GetLedTextByte("排放阶段:" + vehicleNoInfoView.emissionStandard, 3);
				Send485(ledTextByte2);
				Thread.Sleep(50);
				ledTextByte2 = BulkMaterialsForm.LED.LED.GetLedTextByte(vehicleNoInfoView.ExeLog, 4);
				Send485(ledTextByte2);
				Thread.Sleep(50);
			}
		}
		else if (tb_Device.motherboardType == "KF")
		{
			if (isOpen)
			{
				byte[] data = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(0, vehicleNoInfoView.VehicleNo, 0, 60);
				Send485(data);
				Thread.Sleep(50);
				data = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(1, vehicleNoInfoView.fuelType, 0, 60);
				Send485(data);
				Thread.Sleep(50);
				data = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(2, vehicleNoInfoView.emissionStandard, 0, 60);
				Send485(data);
				Thread.Sleep(50);
				data = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(3, vehicleNoInfoView.TrafficStatus, 0, 60);
				Send485(data);
			}
			else
			{
				byte[] data2 = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(0, vehicleNoInfoView.VehicleNo, 0, 60);
				Send485(data2);
				Thread.Sleep(50);
				data2 = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(1, vehicleNoInfoView.fuelType, 0, 60);
				Send485(data2);
				Thread.Sleep(50);
				data2 = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(2, vehicleNoInfoView.emissionStandard, 0, 60);
				Send485(data2);
				Thread.Sleep(50);
				data2 = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(3, vehicleNoInfoView.ExeLog, 0, 60);
				Send485(data2);
			}
		}
	}

	public void Send485(byte[] data)
	{
		IntPtr pData = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
		VzClientSDK.VzLPRClient_SerialSend(ZH_serial_handle, pData, data.Length);
		string text = "";
		foreach (byte b in data)
		{
			text += b.ToString("X2");
		}
		LogSave.ZSLog(DateTime.Now.ToString() + "ZH_serial_handle==" + ZH_serial_handle + "发送485透传" + text);
	}

	public void Close()
	{
		VzClientSDK.VzLPRClient_CancelOfflineCheck(_logHandle);
		VzClientSDK.VzLPRClient_StopRealPlay(m_nPlayHandle);
		VzClientSDK.VzLPRClient_Close(_logHandle);
	}

	private void LedSetTime_Click(object sender, EventArgs e)
	{
		if (tb_Device.motherboardType == "FK")
		{
			byte[] array = MainData.FKSynTime();
			if (array != null)
			{
				Send485(array);
			}
		}
		else if (tb_Device.motherboardType == "KF")
		{
			byte[] array2 = MainData.KFSynTime();
			if (array2 != null)
			{
				Send485(array2);
			}
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (MainData.DJPT == "天地人车")
		{
			CommonHelper.tdrcGateStatusReport(tb_Channel.ChannelPort, "1");
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		VzClientSDK.VzLPRClient_ForceTrigger(_logHandle);
		isrg = true;
	}

	public void barrierGate(byte type)
	{
		try
		{
			if (MainData.ldiody == 1)
			{
				if (type == 1)
				{
					if (ioDate.AddSeconds(3.0) >= DateTime.Now)
					{
						LogSave.QYLog(DateTime.Now.ToString() + "3秒以内" + ioDate.AddSeconds(3.0).ToString());
						return;
					}
					if (MainData.kqykjbd && (openType == 0 || openType == 1))
					{
						try
						{
							MqttService.PublishData("ADMINAT+STACH1=1\r\n", "device/" + tb_Device.IOIP + "/at_cmd");
							MqttService.PublishData("ADMINAT+RELAY=1,ON\r\n", "device/" + tb_Device.IOIP + "/at_cmd");
							List<tcpModel> list = TCPSeerver.tcpModels.Where((tcpModel it) => it.ipAndPort.Contains(tb_Device.bjip)).ToList();
							if (list != null)
							{
								foreach (tcpModel item in list)
								{
									LogSave.TCPLog(DateTime.Now.ToString() + "IP=" + item.ipAndPort + "发送报警");
									TCPSeerver.SendData(item.tcpClient, "ADMINAT+RELAY=1,ON,30000\r\n");
								}
							}
							else
							{
								LogSave.TCPLog(DateTime.Now.ToString() + " 查询报警空" + tb_Device.bjip);
							}
						}
						catch (Exception ex)
						{
							LogSave.SaveExeLog(DateTime.Now.ToString() + "QYTCP发送消息异常" + ex.ToString());
						}
					}
					if (MainData.kqsplx)
					{
						Task.Factory.StartNew(delegate
						{
							tb_exceptional tb_exceptional2 = new tb_exceptional();
							if (openType == 0)
							{
								tb_exceptional2.OpeningType = "遥控器抬杆";
							}
							else if (openType == 1)
							{
								tb_exceptional2.OpeningType = "软件控制抬杆";
							}
							else if (openType == 2)
							{
								tb_exceptional2.OpeningType = "车牌自动抬杆";
							}
							tb_exceptional2.add_time = DateTime.Now;
							tb_exceptional2.CameraId = tb_Device.id;
							DataServerContext<tb_exceptional> dataServerContext = new DataServerContext<tb_exceptional>();
							int value = dataServerContext.Current.AddReturnIdentity(tb_exceptional2);
							if (value > 0)
							{
								tb_videotape zpjList = MainData.tb_Videotapes.FirstOrDefault((tb_videotape it) => it.id == tb_Device.SnapId);
								Task.Factory.StartNew(delegate
								{
									LogSave.DHLog(DateTime.Now.ToString() + "MainData.jhjtype=" + MainData.jhjtype);
									if (MainData.jhjtype == "hk")
									{
										DateTime now = DateTime.Now;
										string sVideoFileName = Path.Combine(MainData.strImageDir, now.ToString("yyyyMMddHHmmssfff") + ".mp4");
										Thread.Sleep(120000);
										DateTime now2 = DateTime.Now;
										MainData.hKLXJ.Add(now, now2.AddMinutes(-1.0), Convert.ToInt32(zpjList.ChannelID), value, sVideoFileName);
									}
									else
									{
										LogSave.DHLog(DateTime.Now.ToString() + "DH开始录像");
										IntPtr logHandle = DHSDK.LXJLogin(MainData.jhjIp, MainData.jhjzh, MainData.jhjmm);
										DateTime now3 = DateTime.Now;
										Thread.Sleep(240000);
										new DHSDK().Download(now3, now3.AddMinutes(-1.0), value, Convert.ToInt32(tb_Device.ChannelID), logHandle);
									}
								});
								if (zpjList != null)
								{
									Task.Factory.StartNew(delegate
									{
										if (zpjList.type == "hk")
										{
											int logHandle = HKSDK.HKLogin(zpjList.IP, zpjList.doccode, zpjList.pass);
											new HKSDK().Snap(value, logHandle, zpjList.snapNumber);
										}
										else
										{
											IntPtr logHandle2 = DHSDK.Login(zpjList.IP, zpjList.doccode, zpjList.pass);
											new DHSDK().Snap(value, logHandle2, zpjList.snapNumber);
										}
									});
								}
							}
						});
					}
					if (MainData.dnyybb && openType == 0)
					{
						Task.Factory.StartNew(delegate
						{
							SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
							speechSynthesizer.Rate = 1;
							speechSynthesizer.Volume = 100;
							string textToSpeak = "请注意遥控抬杆";
							speechSynthesizer.Speak(textToSpeak);
						});
					}
				}
				else if (ioDate.AddSeconds(3.0) >= DateTime.Now)
				{
					LogSave.QYLog(DateTime.Now.ToString() + "3秒以内" + ioDate.AddSeconds(3.0).ToString());
				}
				else
				{
					ioDate = DateTime.Now;
					openType = 0;
					MqttService.PublishData("ADMINAT+RELAY=1,OFF\r\n", "device/" + tb_Device.IOIP + "/at_cmd");
				}
			}
			else if (type == 0)
			{
				if (ioDate.AddSeconds(3.0) >= DateTime.Now)
				{
					LogSave.QYLog(DateTime.Now.ToString() + "3秒以内" + ioDate.AddSeconds(3.0).ToString());
					return;
				}
				if (MainData.kqykjbd && (openType == 0 || openType == 1))
				{
					try
					{
						MqttService.PublishData("ADMINAT+STACH1=1\r\n", "device/" + tb_Device.IOIP + "/at_cmd");
						MqttService.PublishData("ADMINAT+RELAY=1,ON\r\n", "device/" + tb_Device.IOIP + "/at_cmd");
						List<tcpModel> list2 = TCPSeerver.tcpModels.Where((tcpModel it) => it.ipAndPort.Contains(tb_Device.bjip)).ToList();
						if (list2 != null)
						{
							foreach (tcpModel item2 in list2)
							{
								TCPSeerver.SendData(item2.tcpClient, "ADMINAT+RELAY=1,ON,30000\r\n");
							}
						}
					}
					catch (Exception ex2)
					{
						LogSave.SaveExeLog(DateTime.Now.ToString() + "QYTCP发送消息异常" + ex2.ToString());
					}
				}
				if (MainData.kqsplx)
				{
					Task.Factory.StartNew(delegate
					{
						tb_exceptional tb_exceptional2 = new tb_exceptional();
						if (openType == 0)
						{
							tb_exceptional2.OpeningType = "遥控器抬杆";
						}
						else if (openType == 1)
						{
							tb_exceptional2.OpeningType = "软件控制抬杆";
						}
						else if (openType == 2)
						{
							tb_exceptional2.OpeningType = "车牌自动抬杆";
						}
						tb_exceptional2.add_time = DateTime.Now;
						DataServerContext<tb_exceptional> dataServerContext = new DataServerContext<tb_exceptional>();
						int value = dataServerContext.Current.AddReturnIdentity(tb_exceptional2);
						if (value > 0)
						{
							tb_videotape zpjList = MainData.tb_Videotapes.FirstOrDefault((tb_videotape it) => it.id == tb_Device.SnapId);
							Task.Factory.StartNew(delegate
							{
								if (MainData.jhjtype == "hk")
								{
									DateTime now = DateTime.Now;
									string sVideoFileName = Path.Combine(MainData.strImageDir, now.ToString("yyyyMMddHHmmssfff") + ".mp4");
									Thread.Sleep(120000);
									DateTime now2 = DateTime.Now;
									MainData.hKLXJ.Add(now, now2.AddMinutes(-1.0), Convert.ToInt32(zpjList.ChannelID), value, sVideoFileName);
								}
								else
								{
									IntPtr logHandle = DHSDK.LXJLogin(MainData.jhjIp, MainData.jhjzh, MainData.jhjmm);
									DateTime now3 = DateTime.Now;
									Thread.Sleep(240000);
									new DHSDK().Download(now3, now3.AddMinutes(-1.0), value, Convert.ToInt32(tb_Device.ChannelID), logHandle);
								}
							});
							if (zpjList != null)
							{
								Task.Factory.StartNew(delegate
								{
									if (zpjList.type == "hk")
									{
										int logHandle = HKSDK.HKLogin(zpjList.IP, zpjList.doccode, zpjList.pass);
										new HKSDK().Snap(value, logHandle, zpjList.snapNumber);
									}
									else
									{
										IntPtr logHandle2 = DHSDK.Login(zpjList.IP, zpjList.doccode, zpjList.pass);
										new DHSDK().Snap(value, logHandle2, zpjList.snapNumber);
									}
								});
							}
						}
					});
				}
				if (MainData.dnyybb && openType == 0)
				{
					Task.Factory.StartNew(delegate
					{
						SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
						speechSynthesizer.Rate = 1;
						speechSynthesizer.Volume = 100;
						string textToSpeak = "请注意遥控抬杆";
						speechSynthesizer.Speak(textToSpeak);
					});
				}
			}
			else if (ioDate.AddSeconds(3.0) >= DateTime.Now)
			{
				LogSave.QYLog(DateTime.Now.ToString() + "3秒以内" + ioDate.AddSeconds(3.0).ToString());
			}
			else
			{
				MqttService.PublishData("ADMINAT+RELAY=1,OFF\r\n", "device/" + tb_Device.IOIP + "/at_cmd");
				ioDate = DateTime.Now;
				openType = 0;
			}
		}
		catch (Exception ex3)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + "臻识IO异常" + ex3.ToString());
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.btnClose = new System.Windows.Forms.Button();
		this.btnOpen = new System.Windows.Forms.Button();
		this.lalCarNo = new System.Windows.Forms.Label();
		this.LedSetTime = new System.Windows.Forms.Button();
		this.gboxheader = new System.Windows.Forms.GroupBox();
		this.pboxQY = new System.Windows.Forms.PictureBox();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.button1 = new System.Windows.Forms.Button();
		this.tableLayoutPanel1.SuspendLayout();
		this.tableLayoutPanel2.SuspendLayout();
		this.gboxheader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pboxQY).BeginInit();
		base.SuspendLayout();
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.gboxheader, 0, 0);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 2;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(647, 495);
		this.tableLayoutPanel1.TabIndex = 1;
		this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
		this.tableLayoutPanel2.ColumnCount = 5;
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
		this.tableLayoutPanel2.Controls.Add(this.btnClose, 2, 0);
		this.tableLayoutPanel2.Controls.Add(this.btnOpen, 1, 0);
		this.tableLayoutPanel2.Controls.Add(this.lalCarNo, 4, 0);
		this.tableLayoutPanel2.Controls.Add(this.LedSetTime, 3, 0);
		this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 458);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 1;
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel2.Size = new System.Drawing.Size(641, 34);
		this.tableLayoutPanel2.TabIndex = 0;
		this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
		this.btnClose.Location = new System.Drawing.Point(215, 3);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(100, 28);
		this.btnClose.TabIndex = 1;
		this.btnClose.Text = "关闸";
		this.btnClose.UseVisualStyleBackColor = true;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.btnOpen.Dock = System.Windows.Forms.DockStyle.Fill;
		this.btnOpen.Location = new System.Drawing.Point(109, 3);
		this.btnOpen.Name = "btnOpen";
		this.btnOpen.Size = new System.Drawing.Size(100, 28);
		this.btnOpen.TabIndex = 0;
		this.btnOpen.Text = "开闸";
		this.btnOpen.UseVisualStyleBackColor = true;
		this.btnOpen.Click += new System.EventHandler(btnOpen_Click);
		this.lalCarNo.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.lalCarNo.AutoSize = true;
		this.lalCarNo.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.lalCarNo.Location = new System.Drawing.Point(491, 6);
		this.lalCarNo.Name = "lalCarNo";
		this.lalCarNo.Size = new System.Drawing.Size(82, 21);
		this.lalCarNo.TabIndex = 2;
		this.lalCarNo.Text = "豫A00000";
		this.LedSetTime.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LedSetTime.Location = new System.Drawing.Point(321, 3);
		this.LedSetTime.Name = "LedSetTime";
		this.LedSetTime.Size = new System.Drawing.Size(100, 28);
		this.LedSetTime.TabIndex = 7;
		this.LedSetTime.Text = "LED同步时间";
		this.LedSetTime.UseVisualStyleBackColor = true;
		this.LedSetTime.Click += new System.EventHandler(LedSetTime_Click);
		this.gboxheader.Controls.Add(this.pboxQY);
		this.gboxheader.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gboxheader.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.gboxheader.Location = new System.Drawing.Point(3, 3);
		this.gboxheader.Name = "gboxheader";
		this.gboxheader.Size = new System.Drawing.Size(641, 449);
		this.gboxheader.TabIndex = 2;
		this.gboxheader.TabStop = false;
		this.pboxQY.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pboxQY.Location = new System.Drawing.Point(3, 25);
		this.pboxQY.Name = "pboxQY";
		this.pboxQY.Size = new System.Drawing.Size(635, 421);
		this.pboxQY.TabIndex = 1;
		this.pboxQY.TabStop = false;
		this.timer1.Enabled = true;
		this.timer1.Interval = 3600000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.button1.Location = new System.Drawing.Point(3, 3);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(100, 28);
		this.button1.TabIndex = 8;
		this.button1.Text = "抓拍";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.tableLayoutPanel1);
		base.Name = "UserControlZS";
		base.Size = new System.Drawing.Size(647, 495);
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		this.gboxheader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pboxQY).EndInit();
		base.ResumeLayout(false);
	}
}
