// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.UserControlHaiKang

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
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

public class UserControlHaiKang : UserControl, IVideoMngInterface
{
	public delegate void OpeningOperation(int msg, byte type, int SnapId, tb_Channel currentChannel, string car_no);

	public delegate void CarRecord(VehicleNoInfoView vehicleNoInfoView);

	private delegate void SetButtonEnableThread();

	public int _logHandle = -1;

	private int m_lRealHandle = -1;

	private Thread videoNetThread;

	private bool isClose;

	private DateTime lastDateTime = DateTime.Now.AddSeconds(-31.0);

	public string IP = "";

	public tb_Channel tb_Channel;

	public tb_Device tb_Device;

	public int m_SerialStart = -1;

	private XNCResultModel xNCResultModel = new XNCResultModel();

	public int SnapId;

	public tb_Channel currentChannel;

	public static CHCNetSDK.SERIALDATACALLBACK sERIALDATACALLBACK;

	public bool IsEnd;

	private IntPtr videoHandle;

	private string id = Guid.NewGuid().ToString("N");

	private int ID;

	public byte openType;

	private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

	public tb_large_screen Tb_Large_Screen;

	public tb_ChannelSeniorSet seniorSet;

	private bool isPlay;

	private string PlayText = "";

	private bool isEnd;

	private int NumberPlay;

	private string car_no = "";

	public string licensePlate = "";

	private CHCNetSDK.LOGINRESULTCALLBACK LoginCallBack;

	private CHCNetSDK.NET_DVR_DEVICEINFO_V40 DeviceInfo;

	private CHCNetSDK.NET_DVR_USER_LOGIN_INFO struLogInfo;

	private object QianYe_lock = new object();

	private bool isrg;

	private DateTime ioDate = DateTime.Now;

	private IContainer components;

	private TableLayoutPanel tableLayoutPanel1;

	private TableLayoutPanel tableLayoutPanel2;

	private Button btnOpen;

	private Button btnClose;

	private Label lalCarNo;

	private PictureBox pboxQY;

	public GroupBox gboxheader;

	private Button LedSetTime;

	private System.Windows.Forms.Timer timer2;

	private Button button1;

	public static event OpeningOperation Operation;

	public event CarRecord carRecord;

	public UserControlHaiKang()
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
		seniorSet = new DataServerContext<tb_ChannelSeniorSet>().Current.GetModel((tb_ChannelSeniorSet it) => it.ChannelId == tb_Channel.id);
		if (!MainData.sdtgqy)
		{
			btnOpen.Enabled = false;
		}
		Control.CheckForIllegalCrossThreadCalls = false;
		videoHandle = pboxQY.Handle;
		gboxheader.Text = tb_Device.CameraName;
		Operation += UserControlQY_Operation;
		timer1.Interval = 8000;
		timer1.Tick += Timer1_Tick;
		timer2.Start();
		MqttHostService.ioChangeDelegate += MqttHostService_ioChangeDelegate;
		MqttHostService.serverbreakoff += MqttHostService_serverbreakoff;
		DataServerContext<tb_large_screen> dataServerContext = new DataServerContext<tb_large_screen>();
		Tb_Large_Screen = dataServerContext.Current.GetList((tb_large_screen it) => it.id == tb_Device.bigScreenId).FirstOrDefault();
		TCPSeerver.carTcpRecord += TCPSeerver_carTcpRecord;
		OutSystem.carOutRecord += OutSystem_carOutRecord;
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
			goto IL_0a69;
		}
		if (this.carRecord != null)
		{
			this.carRecord(vehicleNoInfoView);
		}
		vehicleNoInfoView.ExeLog = "人工禁止通行";
		LEDPlay(IsRelease: false, vehicleNoInfoView);
		showVehicleNo(vehicleNoInfoView.VehicleNo + "人工禁止通行");
		return;
		IL_0a69:
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
		if (IsRelease && MainData.TXIsOpen)
		{
			CommonHelper.TXHGInOutUpLoad(tb_Channel.guid, vehicleNoInfoView.AddTime, vehicleNoInfoView.VehicleNo, tb_Channel.ChannelName, tb_Channel.ChannelType, vehicleNoInfoView.ImagePath);
		}
		LEDPlay(IsRelease, vehicleNoInfoView);
		if (this.carRecord != null)
		{
			this.carRecord(vehicleNoInfoView);
		}
		showVehicleNo(text + vehicleNoInfoView.TrafficStatus);
		return;
		IL_01d7:
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
					goto IL_0a69;
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
			if (CommonHelper.AnCheVerify(text, licenseColor, ref msg5, ref vehicleNoInfoView, tb_Channel.ChannelPort))
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
		goto IL_0a69;
	}

	private void TCPSeerver_carTcpRecord(string ip, byte type)
	{
		if (tb_Device.bjip.Equals(ip))
		{
			barrierGate(type);
		}
	}

	private void MqttHostService_serverbreakoff(string ip, int data)
	{
		isPlay = false;
	}

	private void MqttHostService_ioChangeDelegate(string ip, int data)
	{
		try
		{
			if (ip.Contains(tb_Device.IOIP))
			{
				barrierGate((byte)data);
			}
		}
		catch (Exception ex)
		{
			LogSave.MQTTLog(DateTime.Now.ToString() + "MqttHostService_ioChangeDelegate:" + ex.ToString());
		}
	}

	public void IO(int data)
	{
		LogSave.MQTTLog(DateTime.Now.ToString() + "openType:" + openType);
		if (MainData.ldiody == 1)
		{
			if (data == 1)
			{
				if (openType == 1)
				{
					isPlay = true;
					PlayText = "请注意软件使用抬杆";
					HKOperate hKOperate = MainData.ListVideo.FirstOrDefault((HKOperate it) => it.tb_Videotape.id == tb_Device.SnapId);
					if (hKOperate == null || hKOperate.IsEnd)
					{
						return;
					}
					hKOperate.IsEnd = true;
					tb_exceptional tb_exceptional2 = new tb_exceptional();
					tb_exceptional2.add_time = DateTime.Now;
					tb_exceptional2.CameraId = tb_Device.id;
					tb_exceptional2.OpeningType = "手动抬杆";
					DataServerContext<tb_exceptional> dataServerContext = new DataServerContext<tb_exceptional>();
					int value = dataServerContext.Current.AddReturnIdentity(tb_exceptional2);
					if (value > 0)
					{
						Task.Factory.StartNew(delegate
						{
							hKOperate.Snap(value);
							DateTime now = DateTime.Now;
							Thread.Sleep(120000);
							ExchangeBoard.Download(now.AddMinutes(-2.0), now.AddMinutes(2.0), hKOperate.tb_Videotape.ChannelID, value);
							hKOperate.IsEnd = false;
						});
					}
				}
				else
				{
					if (NumberPlay > 0 || !string.IsNullOrWhiteSpace(licensePlate))
					{
						return;
					}
					isPlay = true;
					PlayText = "禁止遥控抬杆";
					HKOperate hKOperate2 = MainData.ListVideo.FirstOrDefault((HKOperate it) => it.tb_Videotape.id == tb_Device.SnapId);
					if (hKOperate2 == null || hKOperate2.IsEnd)
					{
						return;
					}
					tb_exceptional tb_exceptional3 = new tb_exceptional();
					tb_exceptional3.add_time = DateTime.Now;
					tb_exceptional3.CameraId = tb_Device.id;
					tb_exceptional3.OpeningType = "遥控抬杆";
					DataServerContext<tb_exceptional> dataServerContext2 = new DataServerContext<tb_exceptional>();
					int value2 = dataServerContext2.Current.AddReturnIdentity(tb_exceptional3);
					hKOperate2.IsEnd = true;
					if (value2 > 0)
					{
						Task.Factory.StartNew(delegate
						{
							hKOperate2.Snap(value2);
							DateTime now = DateTime.Now;
							Thread.Sleep(120000);
							ExchangeBoard.Download(now.AddMinutes(-2.0), now.AddMinutes(2.0), hKOperate2.tb_Videotape.ChannelID, value2);
							hKOperate2.IsEnd = false;
						});
					}
				}
			}
			else
			{
				isPlay = false;
			}
		}
		else if (data == 0)
		{
			if (openType == 1)
			{
				isPlay = true;
				PlayText = "请注意软件使用抬杆";
				HKOperate hKOperate3 = MainData.ListVideo.FirstOrDefault((HKOperate it) => it.tb_Videotape.id == tb_Device.SnapId);
				if (hKOperate3 == null || hKOperate3.IsEnd)
				{
					return;
				}
				hKOperate3.IsEnd = true;
				tb_exceptional tb_exceptional4 = new tb_exceptional();
				tb_exceptional4.add_time = DateTime.Now;
				tb_exceptional4.CameraId = tb_Device.id;
				tb_exceptional4.OpeningType = "手动抬杆";
				DataServerContext<tb_exceptional> dataServerContext3 = new DataServerContext<tb_exceptional>();
				int value3 = dataServerContext3.Current.AddReturnIdentity(tb_exceptional4);
				if (value3 > 0)
				{
					Task.Factory.StartNew(delegate
					{
						hKOperate3.Snap(value3);
						DateTime now = DateTime.Now;
						Thread.Sleep(120000);
						ExchangeBoard.Download(now.AddMinutes(-2.0), now.AddMinutes(2.0), hKOperate3.tb_Videotape.ChannelID, value3);
						hKOperate3.IsEnd = false;
					});
				}
			}
			else
			{
				if (NumberPlay > 0 || !string.IsNullOrWhiteSpace(licensePlate))
				{
					return;
				}
				isPlay = true;
				PlayText = "禁止遥控抬杆";
				HKOperate hKOperate4 = MainData.ListVideo.FirstOrDefault((HKOperate it) => it.tb_Videotape.id == tb_Device.SnapId);
				if (hKOperate4 == null || hKOperate4.IsEnd)
				{
					return;
				}
				tb_exceptional tb_exceptional5 = new tb_exceptional();
				tb_exceptional5.add_time = DateTime.Now;
				tb_exceptional5.CameraId = tb_Device.id;
				tb_exceptional5.OpeningType = "遥控抬杆";
				DataServerContext<tb_exceptional> dataServerContext4 = new DataServerContext<tb_exceptional>();
				int value4 = dataServerContext4.Current.AddReturnIdentity(tb_exceptional5);
				hKOperate4.IsEnd = true;
				if (value4 > 0)
				{
					Task.Factory.StartNew(delegate
					{
						hKOperate4.Snap(value4);
						DateTime now = DateTime.Now;
						Thread.Sleep(120000);
						ExchangeBoard.Download(now.AddMinutes(-2.0), now.AddMinutes(2.0), hKOperate4.tb_Videotape.ChannelID, value4);
						hKOperate4.IsEnd = false;
					});
				}
			}
		}
		else
		{
			isPlay = false;
		}
	}

	private void timer2_Tick(object sender, EventArgs e)
	{
		NumberPlay--;
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		openType = 0;
		timer1.Stop();
	}

	private void UserControlQY_Operation(int msg, byte type, int SnapId, tb_Channel currentChannel, string car_no)
	{
		if (tb_Device.id == msg)
		{
			openType = type;
			this.currentChannel = currentChannel;
			this.SnapId = SnapId;
			this.car_no = car_no;
			Open();
		}
	}

	public void StartVideoNetThread()
	{
		videoClientOpen_HaiKang();
		videoNetThread = new Thread(videoClientStartPlay);
		videoNetThread.IsBackground = false;
		videoNetThread.Start();
	}

	public void videoClientStartPlay()
	{
		while (!isClose)
		{
			if ((DateTime.Now - lastDateTime).TotalSeconds >= 60.0 && !IsEnd)
			{
				IsEnd = true;
				videoClientOpen_HaiKang();
				lastDateTime = DateTime.Now;
				if (isClose)
				{
					break;
				}
			}
			if (isPlay)
			{
				SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
				speechSynthesizer.Rate = 1;
				speechSynthesizer.Volume = 100;
				speechSynthesizer.Speak(PlayText);
				Thread.Sleep(300);
			}
			Thread.Sleep(50);
		}
	}

	public void videoClientOpen_HaiKang()
	{
		lock (QianYe_lock)
		{
			if (_logHandle >= 0)
			{
				if (!CHCNetSDK.NET_DVR_RemoteControl(_logHandle, 20005u, IntPtr.Zero, 0))
				{
					setButtonEnable(btEnable: false);
				}
				else
				{
					setButtonEnable(btEnable: true);
				}
			}
			else
			{
				try
				{
					byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(tb_Device.CameraIP);
					struLogInfo.sDeviceAddress = new byte[129];
					bytes.CopyTo(struLogInfo.sDeviceAddress, 0);
					byte[] bytes2 = Encoding.GetEncoding("GBK").GetBytes(MainData.HKUserName);
					struLogInfo.sUserName = new byte[64];
					bytes2.CopyTo(struLogInfo.sUserName, 0);
					byte[] bytes3 = Encoding.GetEncoding("GBK").GetBytes(MainData.HKPassword);
					struLogInfo.sPassword = new byte[64];
					bytes3.CopyTo(struLogInfo.sPassword, 0);
					struLogInfo.wPort = 8000;
					if (LoginCallBack == null)
					{
						LoginCallBack = cbLoginCallBack;
					}
					struLogInfo.cbLoginResult = LoginCallBack;
					struLogInfo.bUseAsynLogin = false;
					DeviceInfo = default(CHCNetSDK.NET_DVR_DEVICEINFO_V40);
					_logHandle = CHCNetSDK.NET_DVR_Login_V40(ref struLogInfo, ref DeviceInfo);
				LogSave.HKLog($"海康登录: IP={tb_Device.CameraIP}, User={MainData.HKUserName}, Handle={_logHandle}");
				if (_logHandle < 0)
				{
					uint num = CHCNetSDK.NET_DVR_GetLastError();
					LogSave.HKLog($"海康登录失败: IP={tb_Device.CameraIP}, User={MainData.HKUserName}, ErrorCode={num}");
					setButtonEnable(btEnable: false);
				}
					else
					{
						CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO
						{
							hPlayWnd = videoHandle,
							lChannel = 1,
							dwStreamType = 0u,
							dwLinkMode = 0u,
							bBlocked = true,
							dwDisplayBufNum = 1u,
							byProtoType = 0,
							byPreviewMode = 0
						};
						m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(_logHandle, ref lpPreviewInfo, null, (IntPtr)0);
						if (m_lRealHandle < 0)
						{
							_logHandle = -1;
							LogSave.HKLog("NET_DVR_RealPlay_V40:" + CHCNetSDK.NET_DVR_GetLastError());
							setButtonEnable(btEnable: false);
						}
						else
						{
							if (sERIALDATACALLBACK == null)
							{
								sERIALDATACALLBACK = ERIALDATACALLBACK;
							}
							CHCNetSDK.NET_DVR_SetReconnect(_logHandle, 1);
							MainData.HtHaiKangCallBackDel[_logHandle] = new MainData.video_HaiKang_MsgCallback_V31(MsgCallback_V31);
							m_SerialStart = CHCNetSDK.NET_DVR_SerialStart(_logHandle, 2, sERIALDATACALLBACK, IntPtr.Zero);
							setButtonEnable(btEnable: true);
						}
						CHCNetSDK.NET_DVR_SETUPALARM_PARAM lpSetupParam = new CHCNetSDK.NET_DVR_SETUPALARM_PARAM
						{
							byLevel = 1,
							byAlarmInfoType = 1
						};
						if (CHCNetSDK.NET_DVR_SetupAlarmChan_V41(_logHandle, ref lpSetupParam) < 0)
						{
							_logHandle = -1;
							setButtonEnable(btEnable: false);
							LogSave.HKLog("NET_DVR_SetupAlarmChan_V41:" + CHCNetSDK.NET_DVR_GetLastError());
						}
					}
				}
				catch (Exception ex)
				{
					LogSave.HKLog(ex.Message);
				}
			}
		}
		IsEnd = false;
	}

	public void cbLoginCallBack(int lUserID, int dwResult, IntPtr lpDeviceInfo, IntPtr pUser)
	{
	}

	private void ERIALDATACALLBACK(int lSerialHandle, string pRecvDataBuffer, uint dwBufSize, uint dwUser)
	{
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

	private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
	{
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
		else if (UserControlHaiKang.Operation != null)
		{
			UserControlHaiKang.Operation(Convert.ToInt32(tb_Device.OpeningMethod), 1, tb_Device.SnapId, tb_Channel, "");
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		CHCNetSDK.NET_DVR_BARRIERGATE_CFG structure = new CHCNetSDK.NET_DVR_BARRIERGATE_CFG
		{
			dwChannel = 1u,
			byLaneNo = 1,
			byBarrierGateCtrl = 0
		};
		int cb = Marshal.SizeOf(structure);
		IntPtr ptr = IntPtr.Zero;
		try
		{
			ptr = Marshal.AllocHGlobal(cb);
			Marshal.StructureToPtr(structure, ptr, fDeleteOld: true);
			CHCNetSDK.NET_DVR_RemoteControl(_logHandle, 3128u, ptr, cb);
		}
		finally
		{
			if (ptr != IntPtr.Zero)
				Marshal.FreeHGlobal(ptr);
		}
	}

	public void Open()
	{
		CHCNetSDK.NET_DVR_BARRIERGATE_CFG structure = new CHCNetSDK.NET_DVR_BARRIERGATE_CFG
		{
			dwChannel = 1u,
			byLaneNo = 1,
			byBarrierGateCtrl = 1
		};
		int cb = Marshal.SizeOf(structure);
		IntPtr ptr = IntPtr.Zero;
		try
		{
			ptr = Marshal.AllocHGlobal(cb);
			Marshal.StructureToPtr(structure, ptr, fDeleteOld: true);
			CHCNetSDK.NET_DVR_RemoteControl(_logHandle, 3128u, ptr, cb);
		}
		finally
		{
			if (ptr != IntPtr.Zero)
				Marshal.FreeHGlobal(ptr);
		}
	}

	public bool MsgCallback_V31(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
	{
		try
		{
			if (MainData.IsBecomeDue)
			{
				return false;
			}
			string text = Encoding.GetEncoding("GBK").GetString(pAlarmer.sDeviceIP).TrimEnd(default(char));
			if (lCommand == 12368)
			{
				NumberPlay = 10;
				Marshal.SizeOf(default(CHCNetSDK.NET_ITS_PLATE_RESULT));
				CHCNetSDK.NET_ITS_PLATE_RESULT nET_ITS_PLATE_RESULT = (CHCNetSDK.NET_ITS_PLATE_RESULT)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_ITS_PLATE_RESULT));
				if (nET_ITS_PLATE_RESULT.struPlateInfo.sLicense != null && nET_ITS_PLATE_RESULT.struPlateInfo.sLicense.Length > 3)
				{
					if (text != tb_Device.CameraIP)
					{
						return false;
					}
					if (!Directory.Exists(MainData.strImageDir))
					{
						Directory.CreateDirectory(MainData.strImageDir);
					}
					lock ("MsgCallback_V31")
					{
						byte[] array = new byte[nET_ITS_PLATE_RESULT.struPlateInfo.sLicense.Length - 2];
						Buffer.BlockCopy(nET_ITS_PLATE_RESULT.struPlateInfo.sLicense, 2, array, 0, array.Length);
						string text2 = Encoding.GetEncoding("GBK").GetString(array).TrimEnd(default(char));
						licensePlate = text2;
						if (text2.IndexOf("加密") >= 0)
						{
							showVehicleNo(text2);
							licensePlate = "";
							return true;
						}
						showVehicleNo(text2 + "，平台验证中！");
						if (text2.Length < 7)
						{
							licensePlate = "";
							showVehicleNo(text2);
							return true;
						}
						LedPrompt(text2);
						_ = DateTime.Now;
						string empty = string.Empty;
						byte[] array2 = new byte[2];
						Buffer.BlockCopy(nET_ITS_PLATE_RESULT.struPlateInfo.sLicense, 0, array2, 0, 2);
						empty = Encoding.GetEncoding("GBK").GetString(array2) + "色";
						LogSave.QYLog(DateTime.Now.ToString() + text2 + "车牌开始" + empty);
						string car_image = "";
						string text3 = "";
						try
						{
							for (int i = 0; i < nET_ITS_PLATE_RESULT.dwPicNum; i++)
							{
								if (nET_ITS_PLATE_RESULT.struPicInfo[i].dwDataLen != 0)
								{
								string text4 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
								string text5 = Path.Combine(MainData.strImageDir, text4 + ".jpg");
								FileStream fileStream = new FileStream(text5, FileMode.Create);
									int dwDataLen = (int)nET_ITS_PLATE_RESULT.struPicInfo[i].dwDataLen;
									byte[] array3 = new byte[dwDataLen];
									Marshal.Copy(nET_ITS_PLATE_RESULT.struPicInfo[i].pBuffer, array3, 0, dwDataLen);
									fileStream.Write(array3, 0, dwDataLen);
									if (i == 0)
									{
										text3 = text5;
									}
									else
									{
										car_image = text5;
									}
									fileStream.Close();
								}
							}
						}
						catch (Exception)
						{
						}
						if (!(tb_Device.CameraType == "标准相机"))
						{
							goto IL_0690;
						}
						bool IsRelease = true;
						VehicleNoInfoView vehicleNoInfoView = new VehicleNoInfoView();
						vehicleNoInfoView.VehicleNo = text2;
						vehicleNoInfoView.AddTime = DateTime.Now;
						vehicleNoInfoView.ChannelName = tb_Channel.ChannelName;
						vehicleNoInfoView.DeviceName = tb_Device.CameraName;
						vehicleNoInfoView.ChannelType = tb_Channel.ChannelType;
						vehicleNoInfoView.ImagePath = text3;
						vehicleNoInfoView.largeId = tb_Device.bigScreenId;
						vehicleNoInfoView.licenseColor = empty;
						vehicleNoInfoView.ChannelId = tb_Device.ChannelNo;
						vehicleNoInfoView.devId = tb_Device.id;
						if (seniorSet == null)
						{
							goto IL_0525;
						}
						string[] array4 = seniorSet.transitColour.Split(',');
						if (array4 != null && array4.Length != 0 && !array4.Contains(empty))
						{
							vehicleNoInfoView.ExeLog = "此通道禁止此车牌颜色通行";
							vehicleNoInfoView.TrafficStatus = "禁止通行";
						}
						else
						{
							string[] array5 = seniorSet.ColourWhiteList.Split(',');
							if (array5 == null || array5.Length == 0 || !array5.Contains(empty) || new DataServerContext<tb_car_info>().Current.GetModel((tb_car_info it) => it.car_no == text2) != null)
							{
								goto IL_0525;
							}
							vehicleNoInfoView.ExeLog = "此车牌号不属于白名单";
							vehicleNoInfoView.TrafficStatus = "禁止通行";
						}
						goto IL_06bd;
						IL_06bd:
						if (MainData.dnyybb)
						{
							Task.Factory.StartNew(delegate
							{
								string text20 = "禁止通行";
								if (IsRelease)
								{
									text20 = "允许通行";
									SpeechSynthesizer obj = new SpeechSynthesizer
									{
										Rate = 1,
										Volume = 100
									};
									text2 = vehicleNoInfoView.VehicleNo + vehicleNoInfoView.emissionStandard + vehicleNoInfoView.fuelType + text20;
									obj.Speak(text2);
								}
								else
								{
									text20 = "禁止通行";
									SpeechSynthesizer obj2 = new SpeechSynthesizer
									{
										Rate = 1,
										Volume = 100
									};
									text2 = vehicleNoInfoView.VehicleNo + text20;
									obj2.Speak(text2);
								}
							});
						}
						if (IsRelease && MainData.TXIsOpen)
						{
							CommonHelper.TXHGInOutUpLoad(tb_Channel.guid, vehicleNoInfoView.AddTime, vehicleNoInfoView.VehicleNo, tb_Channel.ChannelName, tb_Channel.ChannelType, vehicleNoInfoView.ImagePath);
						}
						LEDPlay(IsRelease, vehicleNoInfoView);
						if (this.carRecord != null)
						{
							this.carRecord(vehicleNoInfoView);
						}
						showVehicleNo(text2);
						goto IL_06a0;
						IL_0690:
						licensePlate = "";
						goto end_IL_00c0;
						IL_06a0:
						if (isrg)
						{
							isrg = false;
							OutSystem.AddOut(vehicleNoInfoView);
						}
						goto IL_0690;
						IL_0776:
						if (MainData.DJPT == "中科九州")
						{
							if (MainData.DJPT == "中科九州")
							{
								string text6 = "A";
								text6 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
								string msg = "";
								string text7 = "";
								string text8 = "";
								if (CommonHelper.KangFengV1Verify(text2, empty, tb_Channel.ChannelPort, text6, ref msg, ref vehicleNoInfoView))
								{
									if (MainData.YZTZ)
									{
										if (CommonHelper.weiyouyuan(text2, tb_Channel.ChannelType))
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
									vehicleNoInfoView.ExeLog = msg;
									if (vehicleNoInfoView.serialNum == null || string.IsNullOrWhiteSpace(vehicleNoInfoView.serialNum))
									{
										text8 = "禁止重复上传";
										goto IL_06bd;
									}
									text8 = ((!MainData.barriergate_upload) ? "禁止上传" : "未上传");
								}
								if (!MainData.KaiFengRecordSave(car_image, text3, text2, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, msg, text7, text8, ref vehicleNoInfoView))
								{
									vehicleNoInfoView.ExeLog = "保存失败";
									IsRelease = false;
								}
							}
						}
						else if (MainData.DJPT == "高凌")
						{
							string text9 = "0";
							text9 = tb_Channel.ChannelPort;
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
							if (!isBlacklisted && !CommonHelper.GLVerify(text2, vehicleNoInfoView.licenseColor, text9, ref msg2, ref vehicleNoInfoView))
							{
								IsRelease = false;
								isUpload = true;
								vehicleNoInfoView.ExeLog = msg2;
							}
							if (!MainData.RecordSave(car_image, text3, text2, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView, isUpload))
							{
								IsRelease = false;
								vehicleNoInfoView.ExeLog = msg2 + ";;保存失败";
							}
						}
						else if (MainData.DJPT == "安车")
						{
							string msg3 = "";
							string text10 = "";
							string text11 = "";
							if (CommonHelper.AnCheVerify(text2, empty, ref msg3, ref vehicleNoInfoView, tb_Channel.ChannelPort))
							{
								text11 = "未上传";
								text10 = "摆杆通行";
							}
							else
							{
								text11 = "禁止上传";
								text10 = "未摆杆";
								IsRelease = false;
								vehicleNoInfoView.ExeLog = msg3;
							}
							string text12 = "A";
							text12 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
							vehicleNoInfoView.serialNum = MainData.ACEnterpriseID + tb_Channel.ChannelPort + text12 + vehicleNoInfoView.AddTime.ToString("yyMMddHHmmss");
							if (!MainData.KaiFengRecordSave(car_image, text3, text2, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text10, text11, ref vehicleNoInfoView))
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
							bool isJS = false;
							if (CommonHelper.TYVerify(text2, empty, num, text3, ref msg4))
							{
								IsRelease = true;
								isJS = true;
							}
							else
							{
								IsRelease = false;
								vehicleNoInfoView.ExeLog = msg4;
							}
							if (!MainData.RecordSave(car_image, text3, text2, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null, isUpload: false, "", isJS))
							{
								vehicleNoInfoView.ExeLog = "保存失败";
								IsRelease = false;
							}
						}
						else if (MainData.DJPT == "消纳场")
						{
							string text13 = "1";
							text13 = ((!(tb_Channel.ChannelType == "入口")) ? "2" : "1");
							string msg5 = "";
							if (CommonHelper.XNCVerify(text2, empty, tb_Device.deviceId, text13, ref msg5))
							{
								if (MainData.RecordSave(car_image, text3, text2, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null))
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
							string text14 = "";
							string text15 = "";
							if (CommonHelper.tdrcCheVerify(text2, empty, ref msg6, ref vehicleNoInfoView))
							{
								text15 = "未上传";
								text14 = "摆杆通行";
							}
							else
							{
								text15 = "禁止上传";
								text14 = "未摆杆";
								IsRelease = false;
								vehicleNoInfoView.ExeLog = msg6;
							}
							string text16 = "A";
							text16 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
							vehicleNoInfoView.serialNum = MainData.tdrcOrgan + tb_Channel.ChannelPort + text16 + DateTime.Now.ToString("yyMMddHHmmss");
							if (!MainData.KaiFengRecordSave(car_image, text3, text2, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text14, text15, ref vehicleNoInfoView))
							{
								vehicleNoInfoView.ExeLog = "保存失败";
								IsRelease = false;
							}
						}
						else if (MainData.DJPT == "信阳")
						{
							string msg7 = "";
							string text17 = "";
							string text18 = "";
							if (CommonHelper.xyCheVerify(text2, empty, ref msg7, ref vehicleNoInfoView))
							{
								text18 = "未上传";
								text17 = "摆杆通行";
							}
							else
							{
								text18 = "禁止上传";
								text17 = "未摆杆";
								IsRelease = false;
								vehicleNoInfoView.ExeLog = msg7;
							}
							string text19 = "A";
							text19 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
							vehicleNoInfoView.serialNum = MainData.xyOrgan + tb_Channel.ChannelPort + text19 + DateTime.Now.ToString("yyMMddHHmmss");
							if (!MainData.KaiFengRecordSave(car_image, text3, text2, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text17, text18, ref vehicleNoInfoView))
							{
								vehicleNoInfoView.ExeLog = "保存失败";
								IsRelease = false;
							}
						}
						goto IL_06bd;
						IL_0525:
						List<tb_car_info> list = new DataServerContext<tb_car_info>().Current.GetList((tb_car_info it) => it.car_no == text2);
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
								goto IL_0776;
							}
						}
						else
						{
							if (MainData.SDZK)
							{
								isrg = true;
								goto IL_06a0;
							}
							if (!MainData.LSCSN)
							{
								goto IL_0776;
							}
							vehicleNoInfoView.ExeLog = "临时车禁止通行";
							IsRelease = false;
						}
						goto IL_06bd;
						end_IL_00c0:;
					}
				}
			}
		}
		catch (Exception ex2)
		{
			LogSave.HKLog(DateTime.Now.ToString() + ex2.ToString());
		}
		return true;
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
			else if (UserControlHaiKang.Operation != null)
			{
				UserControlHaiKang.Operation(Convert.ToInt32(tb_Device.OpeningMethod), 2, tb_Device.SnapId, tb_Channel, vehicleNoInfoView.VehicleNo);
			}
		}
		car_no = vehicleNoInfoView.VehicleNo;
		Led(vehicleNoInfoView.VehicleNo, isOpen: true);
		vehicleNoInfoView.TrafficStatus = "允许通行";
		vehicleNoInfoView.ExeLog = "允许通行";
		LedPlay(vehicleNoInfoView, isOpen: true);
	}

	public void showVehicleNo(string vehicleNo)
	{
		lalCarNo.Invoke((Action<string>)delegate(string p)
		{
			lalCarNo.Text = p;
		}, vehicleNo);
	}

	public void LedPlay(VehicleNoInfoView vehicleNoInfoView, bool isOpen)
	{
		if (MainData.DPLX == "YB")
		{
			if (Tb_Large_Screen != null)
			{
				YB_SDK.YBLedSendMes(Tb_Large_Screen, vehicleNoInfoView, isOpen);
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
				data = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(1, "燃料类型:" + vehicleNoInfoView.fuelType, 0, 60);
				Send485(data);
				Thread.Sleep(50);
				data = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(2, "排放阶段:" + vehicleNoInfoView.emissionStandard, 0, 60);
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
				data2 = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(1, "燃料类型:" + vehicleNoInfoView.fuelType, 0, 60);
				Send485(data2);
				Thread.Sleep(50);
				data2 = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(2, "排放阶段:" + vehicleNoInfoView.emissionStandard, 0, 60);
				Send485(data2);
				Thread.Sleep(50);
				data2 = BulkMaterialsForm.LED.LED.ShowKeFa1TextByID(3, vehicleNoInfoView.ExeLog, 0, 60);
				Send485(data2);
			}
		}
		else if (tb_Device.motherboardType == "HK-2")
		{
			if (isOpen)
			{
				HaiKangSendSoundText2KFLed(vehicleNoInfoView.VehicleNo + ":允许通行", "燃料类型:" + vehicleNoInfoView.fuelType + ",排放阶段:" + vehicleNoInfoView.emissionStandard, 30);
			}
			else
			{
				HaiKangSendSoundText2KFLed(vehicleNoInfoView.VehicleNo + ":禁止通行", vehicleNoInfoView.ExeLog, 30);
			}
		}
		else if (tb_Device.motherboardType == "HK-4")
		{
			HaiKangSendSoundText4KFLed(vehicleNoInfoView, 30);
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
		else if (tb_Device.motherboardType == "KF")
		{
			if (isOpen)
			{
				byte[] data3 = BulkMaterialsForm.LED.LED.KeFa_SoundPlay(0, VehicleNo + "欢迎光临");
				Send485(data3);
			}
			else
			{
				byte[] data4 = BulkMaterialsForm.LED.LED.KeFa_SoundPlay(0, VehicleNo + "禁止通行");
				Send485(data4);
			}
		}
		else if (tb_Device.motherboardType == "HK-2")
		{
			if (isOpen)
			{
				if (tb_Channel.ChannelType == "入口")
				{
					HaiKangPlayVoice("欢迎光临");
				}
				else
				{
					HaiKangPlayVoice("一路顺风");
				}
			}
			else
			{
				HaiKangPlayVoice("禁止通行");
			}
		}
		else
		{
			if (!(tb_Device.motherboardType == "HK-4"))
			{
				return;
			}
			if (isOpen)
			{
				if (tb_Channel.ChannelType == "入口")
				{
					HaiKangPlayVoice("欢迎光临");
				}
				else
				{
					HaiKangPlayVoice("一路顺风");
				}
			}
			else
			{
				HaiKangPlayVoice("禁止通行");
			}
		}
	}

	public void Send485(byte[] data)
	{
		CHCNetSDK.NET_DVR_SerialSend(m_SerialStart, 1, data, Convert.ToUInt32(data.Length));
	}

	public string QYSmallSaveImage(QianYe_SDK.T_PicInfo tPicInfo)
	{
		string text = "";
		string text2 = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
		if (tPicInfo.ptVehiclePicBuff != IntPtr.Zero && tPicInfo.uiVehiclePicLen != 0)
		{
			byte[] array = new byte[tPicInfo.uiVehiclePicLen];
			Marshal.Copy(tPicInfo.ptVehiclePicBuff, array, 0, (int)tPicInfo.uiVehiclePicLen);
			text = Path.Combine(MainData.strImageDir, text2 + ".jpg");
			FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
			fileStream.Write(array, 0, (int)tPicInfo.uiVehiclePicLen);
			fileStream.Close();
			fileStream.Dispose();
		}
		return text;
	}

	public void Snap(string model)
	{
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(model);
		if (tb_Device.ChannelNo == Convert.ToInt32(dictionary["ChannelNo"]) && tb_Device.id != Convert.ToInt32(dictionary["DeviceId"]))
		{
			ID = Convert.ToInt32(dictionary["id"]);
			string text = Path.Combine(MainData.strImageDir, DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg");
			CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA
			{
				wPicQuality = 0,
				wPicSize = 255
			};
			if (CHCNetSDK.NET_DVR_CaptureJPEGPicture(_logHandle, 1, ref lpJpegPara, text))
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

	public void Close()
	{
		CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
		CHCNetSDK.NET_DVR_Logout(_logHandle);
	}

	public void HaiKangPlayVoice(string voice)
	{
		combinateBroadcast combinateBroadcast2 = new combinateBroadcast();
		BroadcastInfoList broadcastInfoList = new BroadcastInfoList();
		combinateBroadcast2.CombinateBroadcast.volume = 5;
		broadcastInfoList.BroadcastInfo.customValue = voice;
		combinateBroadcast2.CombinateBroadcast.BroadcastInfoList.Add(broadcastInfoList);
		HaiKangSend("http://" + tb_Device.CameraIP + ":80/ISAPI/Parking/channels/1/voiceBroadcastInfo/combinateBroadcast?format=json", "PUT", combinateBroadcast2);
	}

	public void HaiKangSendSoundText2KFLed(string vehicleNo, string text, int time = 0)
	{
		multiScene multiScene2 = new multiScene();
		LEDConfigurationList lEDConfigurationList = new LEDConfigurationList();
		SingleSceneLEDConfigurations singleSceneLEDConfigurations = new SingleSceneLEDConfigurations();
		LEDConfiguration lEDConfiguration = new LEDConfiguration();
		ShowInfoList showInfoList = new ShowInfoList();
		if (time != 0)
		{
			singleSceneLEDConfigurations.displayTime = time;
		}
		else
		{
			singleSceneLEDConfigurations.displayTime = 30;
		}
		LineInfoList lineInfoList = new LineInfoList();
		lineInfoList.LineInfo.id = 1;
		lineInfoList.LineInfo.customValue = vehicleNo;
		showInfoList.ShowInfo.LineInfoList.Add(lineInfoList);
		ShowInfoList showInfoList2 = new ShowInfoList();
		LineInfoList lineInfoList2 = new LineInfoList();
		showInfoList2.ShowInfo.id = 2;
		lineInfoList2.LineInfo.id = 1;
		lineInfoList2.LineInfo.customValue = text;
		showInfoList2.ShowInfo.LineInfoList.Add(lineInfoList2);
		lEDConfiguration.ShowInfoList.Add(showInfoList);
		lEDConfiguration.ShowInfoList.Add(showInfoList2);
		lEDConfigurationList.LEDConfiguration = lEDConfiguration;
		singleSceneLEDConfigurations.LEDConfigurationList.Add(lEDConfigurationList);
		multiScene2.SingleSceneLEDConfigurations = singleSceneLEDConfigurations;
		HaiKangSend("http://" + tb_Device.CameraIP + ":80/ISAPI/Parking/channels/1/LEDConfigurations/multiScene/1?format=json", "PUT", multiScene2);
	}

	public void HaiKangSendSoundText4KFLed(VehicleNoInfoView vehicleNoInfoView, int time = 0)
	{
		multiScene multiScene2 = new multiScene();
		LEDConfigurationList lEDConfigurationList = new LEDConfigurationList();
		SingleSceneLEDConfigurations singleSceneLEDConfigurations = new SingleSceneLEDConfigurations();
		LEDConfiguration lEDConfiguration = new LEDConfiguration();
		ShowInfoList showInfoList = new ShowInfoList();
		if (time != 0)
		{
			singleSceneLEDConfigurations.displayTime = time;
		}
		else
		{
			singleSceneLEDConfigurations.displayTime = 30;
		}
		LineInfoList lineInfoList = new LineInfoList();
		lineInfoList.LineInfo.id = 1;
		lineInfoList.LineInfo.customValue = vehicleNoInfoView.VehicleNo;
		showInfoList.ShowInfo.LineInfoList.Add(lineInfoList);
		ShowInfoList showInfoList2 = new ShowInfoList();
		LineInfoList lineInfoList2 = new LineInfoList();
		showInfoList2.ShowInfo.id = 2;
		lineInfoList2.LineInfo.id = 1;
		lineInfoList2.LineInfo.customValue = "燃料类型:" + vehicleNoInfoView.fuelType;
		showInfoList2.ShowInfo.LineInfoList.Add(lineInfoList2);
		ShowInfoList showInfoList3 = new ShowInfoList();
		LineInfoList lineInfoList3 = new LineInfoList();
		showInfoList3.ShowInfo.id = 3;
		lineInfoList3.LineInfo.id = 1;
		lineInfoList3.LineInfo.customValue = "排放阶段:" + vehicleNoInfoView.emissionStandard;
		showInfoList3.ShowInfo.LineInfoList.Add(lineInfoList3);
		ShowInfoList showInfoList4 = new ShowInfoList();
		LineInfoList lineInfoList4 = new LineInfoList();
		showInfoList4.ShowInfo.id = 4;
		lineInfoList4.LineInfo.id = 1;
		lineInfoList4.LineInfo.customValue = vehicleNoInfoView.TrafficStatus;
		showInfoList4.ShowInfo.LineInfoList.Add(lineInfoList4);
		lEDConfiguration.ShowInfoList.Add(showInfoList);
		lEDConfiguration.ShowInfoList.Add(showInfoList2);
		lEDConfiguration.ShowInfoList.Add(showInfoList3);
		lEDConfiguration.ShowInfoList.Add(showInfoList4);
		lEDConfigurationList.LEDConfiguration = lEDConfiguration;
		singleSceneLEDConfigurations.LEDConfigurationList.Add(lEDConfigurationList);
		multiScene2.SingleSceneLEDConfigurations = singleSceneLEDConfigurations;
		HaiKangSend("http://" + tb_Device.CameraIP + ":80/ISAPI/Parking/channels/1/LEDConfigurations/multiScene/1?format=json", "PUT", multiScene2);
	}

	public void HaiKangSend(string url, string method, object data)
	{
		try
		{
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
			webRequest.Method = method;
			webRequest.Credentials = new NetworkCredential(MainData.HKUserName, MainData.HKPassword);
			if (method != "Get")
			{
				string text = JsonConvert.SerializeObject(data);
				LogSave.HKLog(DateTime.Now.ToString() + url + "发送内容=" + text);
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				webRequest.ContentType = "application/json";
				webRequest.ContentLength = bytes.Length;
				using (Stream requestStream = webRequest.GetRequestStream())
				{
					requestStream.Write(bytes, 0, bytes.Length);
				}
			}
			using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
			using (Stream responseStream = webResponse.GetResponseStream())
			using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
			{
				string text2 = reader.ReadToEnd();
				LogSave.HKLog(DateTime.Now.ToString() + url + "返回内容=" + text2);
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog($"[HaiKangSend] 请求失败: {ex.Message}");
		}
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

	private void button1_Click(object sender, EventArgs e)
	{
		CHCNetSDK.NET_DVR_MANUALSNAP lpInter = new CHCNetSDK.NET_DVR_MANUALSNAP
		{
			byOSDEnable = 0,
			byLaneNo = 1
		};
		CHCNetSDK.NET_DVR_PLATE_RESULT lpOuter = new CHCNetSDK.NET_DVR_PLATE_RESULT
		{
			pBuffer1 = Marshal.AllocHGlobal(31457280),
			pBuffer2 = Marshal.AllocHGlobal(31457280),
			pBuffer3 = Marshal.AllocHGlobal(31457280),
			pBuffer4 = Marshal.AllocHGlobal(31457280),
			pBuffer5 = Marshal.AllocHGlobal(31457280)
		};
		try
		{
			if (!CHCNetSDK.NET_DVR_ManualSnap(_logHandle, ref lpInter, ref lpOuter))
			{
				return;
			}
			byte[] array = new byte[lpOuter.struPlateInfo.sLicense.Length - 2];
			Buffer.BlockCopy(lpOuter.struPlateInfo.sLicense, 2, array, 0, array.Length);
			string text = Encoding.GetEncoding("GBK").GetString(array).TrimEnd(default(char));
			licensePlate = text;
			if (text.IndexOf("加密") >= 0)
			{
				showVehicleNo(text);
				licensePlate = "";
				return;
			}
			showVehicleNo(text + "，平台验证中！");
			if (text.Length < 7)
			{
				licensePlate = "";
				showVehicleNo("未识别到正确车牌");
				return;
			}
			LedPrompt(text);
			_ = DateTime.Now;
			string empty = string.Empty;
			byte[] array2 = new byte[2];
			Buffer.BlockCopy(lpOuter.struPlateInfo.sLicense, 0, array2, 0, 2);
			empty = Encoding.GetEncoding("GBK").GetString(array2) + "色";
			LogSave.QYLog(DateTime.Now.ToString() + text + "车牌开始" + empty);
			CHCNetSDK.NET_DVR_JPEGPARA nET_DVR_JPEGPARA = new CHCNetSDK.NET_DVR_JPEGPARA
			{
				wPicQuality = 0,
				wPicSize = 255
			};
			string text2 = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
			string car_image = "";
			string text3 = "";
			string text4 = Path.Combine(MainData.strImageDir, text2 + ".jpg");
			if (CHCNetSDK.NET_DVR_CapturePicture(_logHandle, text4))
			{
				text3 = text4;
			}
			if (!(tb_Device.CameraType == "标准相机"))
			{
				goto IL_0e24;
			}
			bool IsRelease = true;
			VehicleNoInfoView vehicleNoInfoView = new VehicleNoInfoView();
			vehicleNoInfoView.VehicleNo = text;
			vehicleNoInfoView.AddTime = DateTime.Now;
			vehicleNoInfoView.ChannelName = tb_Channel.ChannelName;
			vehicleNoInfoView.DeviceName = tb_Device.CameraName;
			vehicleNoInfoView.ChannelType = tb_Channel.ChannelType;
			vehicleNoInfoView.ImagePath = text3;
			vehicleNoInfoView.largeId = tb_Device.bigScreenId;
			vehicleNoInfoView.licenseColor = empty;
			vehicleNoInfoView.ChannelId = tb_Device.ChannelNo;
			vehicleNoInfoView.devId = tb_Device.id;
			if (seniorSet == null)
			{
				goto IL_0453;
			}
			string[] array3 = seniorSet.transitColour.Split(',');
			if (array3 != null && array3.Length != 0 && !array3.Contains(empty))
			{
				vehicleNoInfoView.ExeLog = "此通道禁止此车牌颜色通行";
				vehicleNoInfoView.TrafficStatus = "禁止通行";
			}
			else
			{
				string[] array4 = seniorSet.ColourWhiteList.Split(',');
				if (array4 == null || array4.Length == 0 || !array4.Contains(empty) || new DataServerContext<tb_car_info>().Current.GetModel((tb_car_info it) => it.car_no == text) != null)
				{
					goto IL_0453;
				}
				vehicleNoInfoView.ExeLog = "此车牌号不属于白名单";
				vehicleNoInfoView.TrafficStatus = "禁止通行";
			}
			goto IL_0e30;
			IL_0453:
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
					goto IL_05da;
				}
			}
			else
			{
				if (MainData.SDZK)
				{
					isrg = true;
					goto IL_05b8;
				}
				if (!MainData.LSCSN)
				{
					goto IL_05da;
				}
				vehicleNoInfoView.ExeLog = "临时车禁止通行";
				IsRelease = false;
			}
			goto IL_0e30;
			IL_0e30:
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
			if (IsRelease && MainData.TXIsOpen)
			{
				CommonHelper.TXHGInOutUpLoad(tb_Channel.guid, vehicleNoInfoView.AddTime, vehicleNoInfoView.VehicleNo, tb_Channel.ChannelName, tb_Channel.ChannelType, vehicleNoInfoView.ImagePath);
			}
			LEDPlay(IsRelease, vehicleNoInfoView);
			if (this.carRecord != null)
			{
				this.carRecord(vehicleNoInfoView);
			}
			showVehicleNo(text);
			goto IL_05b8;
			IL_05da:
			if (MainData.DJPT == "中科九州")
			{
				if (MainData.DJPT == "中科九州")
				{
					string text5 = "A";
					text5 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
					string msg = "";
					string text6 = "";
					string text7 = "";
					if (CommonHelper.KangFengV1Verify(text, empty, tb_Channel.ChannelPort, text5, ref msg, ref vehicleNoInfoView))
					{
						if (MainData.YZTZ)
						{
							if (CommonHelper.weiyouyuan(text, tb_Channel.ChannelType))
							{
								text7 = "未上传";
								text6 = "摆杆通行";
							}
							else
							{
								text6 = "未摆杆";
								text7 = "禁止上传";
								IsRelease = false;
								vehicleNoInfoView.ExeLog = "未补台账，禁止通行";
							}
						}
						else
						{
							text7 = "未上传";
							text6 = "摆杆通行";
						}
					}
					else
					{
						text6 = "未摆杆";
						IsRelease = false;
						vehicleNoInfoView.ExeLog = msg;
						if (vehicleNoInfoView.serialNum == null || string.IsNullOrWhiteSpace(vehicleNoInfoView.serialNum))
						{
							text7 = "禁止重复上传";
							goto IL_0e30;
						}
						text7 = ((!MainData.barriergate_upload) ? "禁止上传" : "未上传");
					}
					if (!MainData.KaiFengRecordSave(car_image, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, msg, text6, text7, ref vehicleNoInfoView))
					{
						vehicleNoInfoView.ExeLog = "保存失败";
						IsRelease = false;
					}
				}
			}
			else if (MainData.DJPT == "高凌")
			{
				string text8 = "0";
				text8 = tb_Channel.ChannelPort;
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
				if (!isBlacklisted && !CommonHelper.GLVerify(text, vehicleNoInfoView.licenseColor, text8, ref msg2, ref vehicleNoInfoView))
				{
					IsRelease = false;
					isUpload = true;
					vehicleNoInfoView.ExeLog = msg2;
				}
				if (!MainData.RecordSave(car_image, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView, isUpload))
				{
					IsRelease = false;
					vehicleNoInfoView.ExeLog = msg2 + ";;保存失败";
				}
			}
			else if (MainData.DJPT == "安车")
			{
				string msg3 = "";
				string text9 = "";
				string text10 = "";
				if (CommonHelper.AnCheVerify(text, empty, ref msg3, ref vehicleNoInfoView, tb_Channel.ChannelPort))
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
				if (!MainData.KaiFengRecordSave(car_image, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text9, text10, ref vehicleNoInfoView))
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
				bool isJS = false;
				if (CommonHelper.TYVerify(text, empty, num, text3, ref msg4))
				{
					IsRelease = true;
					isJS = true;
				}
				else
				{
					IsRelease = false;
					vehicleNoInfoView.ExeLog = msg4;
				}
				if (!MainData.RecordSave(car_image, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null, isUpload: false, "", isJS))
				{
					vehicleNoInfoView.ExeLog = "保存失败";
					IsRelease = false;
				}
			}
			else if (MainData.DJPT == "消纳场")
			{
				string text12 = "1";
				text12 = ((!(tb_Channel.ChannelType == "入口")) ? "2" : "1");
				string msg5 = "";
				if (CommonHelper.XNCVerify(text, empty, tb_Device.deviceId, text12, ref msg5))
				{
					if (MainData.RecordSave(car_image, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null))
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
				if (CommonHelper.tdrcCheVerify(text, empty, ref msg6, ref vehicleNoInfoView))
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
				vehicleNoInfoView.serialNum = MainData.tdrcOrgan + tb_Channel.ChannelPort + text15 + DateTime.Now.ToString("yyMMddHHmmss");
				if (!MainData.KaiFengRecordSave(car_image, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text13, text14, ref vehicleNoInfoView))
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
				if (CommonHelper.xyCheVerify(text, empty, ref msg7, ref vehicleNoInfoView))
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
				if (!MainData.KaiFengRecordSave(car_image, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text16, text17, ref vehicleNoInfoView))
				{
					vehicleNoInfoView.ExeLog = "保存失败";
					IsRelease = false;
				}
			}
			goto IL_0e30;
			IL_05b8:
			if (isrg)
			{
				isrg = false;
				OutSystem.AddOut(vehicleNoInfoView);
			}
			goto IL_0e24;
			IL_0e24:
			licensePlate = "";
		}
		finally
		{
			Marshal.FreeHGlobal(lpOuter.pBuffer1);
			Marshal.FreeHGlobal(lpOuter.pBuffer2);
			Marshal.FreeHGlobal(lpOuter.pBuffer3);
			Marshal.FreeHGlobal(lpOuter.pBuffer4);
			Marshal.FreeHGlobal(lpOuter.pBuffer5);
		}
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
							int sId = 0;
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
								tb_exceptional2.car_no = car_no;
							}
							if (SnapId != 0)
							{
								sId = SnapId;
								tb_exceptional2.ChannelType = currentChannel.ChannelType;
							}
							else
							{
								sId = tb_Device.SnapId;
								tb_exceptional2.ChannelType = tb_Channel.ChannelType;
							}
							SnapId = 0;
							currentChannel = new tb_Channel();
							tb_exceptional2.add_time = DateTime.Now;
							tb_exceptional2.CameraId = tb_Device.id;
							DataServerContext<tb_exceptional> dataServerContext = new DataServerContext<tb_exceptional>();
							int value = dataServerContext.Current.AddReturnIdentity(tb_exceptional2);
							if (value > 0)
							{
								tb_videotape zpjList = MainData.tb_Videotapes.FirstOrDefault((tb_videotape it) => it.id == sId);
								Task.Factory.StartNew(delegate
								{
									if (MainData.jhjtype == "hk")
									{
										DateTime start = DateTime.Now.AddSeconds(-60.0);
										DateTime end = DateTime.Now.AddSeconds(60.0);
										string sVideoFileName = Path.Combine(MainData.strImageDir, DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".mp4");
										Thread.Sleep(60000);
										new HKSDK();
										MainData.hKLXJ.Add(start, end, Convert.ToInt32(zpjList.ChannelID), value, sVideoFileName);
									}
									else
									{
										LogSave.DHLog(DateTime.Now.ToString() + "DH开始录像");
										IntPtr logHandle = DHSDK.LXJLogin(MainData.jhjIp, MainData.jhjzh, MainData.jhjmm);
										DateTime now = DateTime.Now;
										Thread.Sleep(240000);
										new DHSDK().Download(now, now.AddMinutes(-1.0), value, Convert.ToInt32(tb_Device.ChannelID), logHandle);
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
							Task.Factory.StartNew(delegate
							{
								if (MainData.jhjtype == "hk")
								{
									int lUserID = HKSDK.HKLogin(MainData.jhjIp, MainData.jhjzh, MainData.jhjmm);
									DateTime now = DateTime.Now;
									Thread.Sleep(60000);
									new HKSDK().Download(now.AddMinutes(-1.0), now.AddMinutes(1.0), Convert.ToInt32(tb_Device.ChannelID), value, lUserID);
								}
								else
								{
									IntPtr logHandle = DHSDK.LXJLogin(MainData.jhjIp, MainData.jhjzh, MainData.jhjmm);
									DateTime now2 = DateTime.Now;
									Thread.Sleep(240000);
									new DHSDK().Download(now2, now2.AddMinutes(-1.0), value, Convert.ToInt32(tb_Device.ChannelID), logHandle);
								}
							});
							tb_videotape zpjList = MainData.tb_Videotapes.FirstOrDefault((tb_videotape it) => it.id == tb_Device.SnapId);
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
		this.btnOpen = new System.Windows.Forms.Button();
		this.lalCarNo = new System.Windows.Forms.Label();
		this.btnClose = new System.Windows.Forms.Button();
		this.LedSetTime = new System.Windows.Forms.Button();
		this.gboxheader = new System.Windows.Forms.GroupBox();
		this.pboxQY = new System.Windows.Forms.PictureBox();
		this.timer2 = new System.Windows.Forms.Timer(this.components);
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
		this.tableLayoutPanel1.Size = new System.Drawing.Size(691, 614);
		this.tableLayoutPanel1.TabIndex = 0;
		this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(tableLayoutPanel1_Paint);
		this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
		this.tableLayoutPanel2.ColumnCount = 5;
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
		this.tableLayoutPanel2.Controls.Add(this.btnOpen, 1, 0);
		this.tableLayoutPanel2.Controls.Add(this.lalCarNo, 4, 0);
		this.tableLayoutPanel2.Controls.Add(this.btnClose, 2, 0);
		this.tableLayoutPanel2.Controls.Add(this.LedSetTime, 3, 0);
		this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 577);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 1;
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel2.Size = new System.Drawing.Size(685, 34);
		this.tableLayoutPanel2.TabIndex = 0;
		this.btnOpen.Dock = System.Windows.Forms.DockStyle.Fill;
		this.btnOpen.Location = new System.Drawing.Point(117, 3);
		this.btnOpen.Name = "btnOpen";
		this.btnOpen.Size = new System.Drawing.Size(108, 28);
		this.btnOpen.TabIndex = 0;
		this.btnOpen.Text = "开闸";
		this.btnOpen.UseVisualStyleBackColor = true;
		this.btnOpen.Click += new System.EventHandler(btnOpen_Click);
		this.lalCarNo.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.lalCarNo.AutoSize = true;
		this.lalCarNo.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.lalCarNo.Location = new System.Drawing.Point(529, 6);
		this.lalCarNo.Name = "lalCarNo";
		this.lalCarNo.Size = new System.Drawing.Size(82, 21);
		this.lalCarNo.TabIndex = 2;
		this.lalCarNo.Text = "豫A00000";
		this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
		this.btnClose.Location = new System.Drawing.Point(231, 3);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(108, 28);
		this.btnClose.TabIndex = 1;
		this.btnClose.Text = "关闸";
		this.btnClose.UseVisualStyleBackColor = true;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.LedSetTime.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LedSetTime.Location = new System.Drawing.Point(345, 3);
		this.LedSetTime.Name = "LedSetTime";
		this.LedSetTime.Size = new System.Drawing.Size(108, 28);
		this.LedSetTime.TabIndex = 4;
		this.LedSetTime.Text = "LED同步时间";
		this.LedSetTime.UseVisualStyleBackColor = true;
		this.LedSetTime.Click += new System.EventHandler(LedSetTime_Click);
		this.gboxheader.Controls.Add(this.pboxQY);
		this.gboxheader.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gboxheader.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.gboxheader.Location = new System.Drawing.Point(3, 3);
		this.gboxheader.Name = "gboxheader";
		this.gboxheader.Size = new System.Drawing.Size(685, 568);
		this.gboxheader.TabIndex = 2;
		this.gboxheader.TabStop = false;
		this.pboxQY.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pboxQY.Location = new System.Drawing.Point(3, 25);
		this.pboxQY.Name = "pboxQY";
		this.pboxQY.Size = new System.Drawing.Size(679, 540);
		this.pboxQY.TabIndex = 1;
		this.pboxQY.TabStop = false;
		this.timer2.Interval = 1000;
		this.timer2.Tick += new System.EventHandler(timer2_Tick);
		this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.button1.Location = new System.Drawing.Point(3, 3);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(108, 28);
		this.button1.TabIndex = 5;
		this.button1.Text = "抓拍";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.tableLayoutPanel1);
		base.Name = "UserControlHaiKang";
		base.Size = new System.Drawing.Size(691, 614);
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		this.gboxheader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pboxQY).EndInit();
		base.ResumeLayout(false);
	}
}
