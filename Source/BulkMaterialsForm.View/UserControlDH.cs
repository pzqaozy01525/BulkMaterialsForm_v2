// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.UserControlDH

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
using System.Timers;
using System.Windows.Forms;
using BulkMaterialsForm.Help;
using BulkMaterialsForm.LED;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;
using BulkMaterialsForm.SDK;
using NetSDKCS;
using Newtonsoft.Json;

namespace BulkMaterialsForm.View;

public class UserControlDH : UserControl, IVideoMngInterface
{
	public delegate void OpeningOperation(int msg, byte type);

	public delegate void CarRecord(VehicleNoInfoView vehicleNoInfoView);

	private delegate void SetButtonEnableThread();

	public tb_Channel tb_Channel;

	public tb_Device tb_Device;

	public IntPtr _logHandle = IntPtr.Zero;

	private string id = Guid.NewGuid().ToString("N");

	private XNCResultModel xNCResultModel = new XNCResultModel();

	private DateTime lastDateTime = DateTime.Now.AddSeconds(-31.0);

	private Thread videoNetThread;

	private bool isClose;

	private int ID;

	private NET_DEVICEINFO_Ex m_DeviceInfo;

	private IntPtr m_RealPlayID = IntPtr.Zero;

	private fAnalyzerDataCallBack m_AnalyzerDataCallBack;

	public bool IsEnd;

	private IntPtr videoHandle;

	public tb_ChannelSeniorSet seniorSet;

	public tb_large_screen Tb_Large_Screen;

	private DateTime ioDate = DateTime.Now;

	private object DaHua_lock = new object();

	public byte openType;

	private System.Timers.Timer timer = new System.Timers.Timer(20000.0);

	private bool isrg;

	private IContainer components;

	private TableLayoutPanel tableLayoutPanel1;

	private TableLayoutPanel tableLayoutPanel2;

	private Button btnClose;

	private Button btnOpen;

	private Label lalCarNo;

	public GroupBox gboxheader;

	private PictureBox pboxQY;

	private System.Windows.Forms.Timer timer1;

	private Button LedSetTime;

	private Button button1;

	public static event OpeningOperation Operation;

	public event CarRecord carRecord;

	public UserControlDH()
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
		seniorSet = new DataServerContext<tb_ChannelSeniorSet>().Current.GetModel((tb_ChannelSeniorSet it) => it.ChannelId == tb_Channel.id);
		Control.CheckForIllegalCrossThreadCalls = false;
		videoHandle = pboxQY.Handle;
		gboxheader.Text = tb_Device.CameraName;
		m_AnalyzerDataCallBack = (fAnalyzerDataCallBack)Delegate.Combine(m_AnalyzerDataCallBack, new fAnalyzerDataCallBack(AnalyzerDataCallBack));
		timer.Elapsed += timer1_Tick;
		Operation += UserControlDH_Operation;
		TCPSeerver.carTcpRecord += TCPSeerver_carTcpRecord;
		DataServerContext<tb_large_screen> dataServerContext = new DataServerContext<tb_large_screen>();
		Tb_Large_Screen = dataServerContext.Current.GetList((tb_large_screen it) => it.id == tb_Device.bigScreenId).FirstOrDefault();
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
	}

	private void UserControlDH_Operation(int msg, byte type)
	{
		openType = type;
		if (tb_Device.id == msg)
		{
			Open();
		}
	}

	private void TCPSeerver_carTcpRecord(string ip, byte type)
	{
		if (tb_Device.bjip.Equals(ip))
		{
			barrierGate(type);
		}
	}

	public void Open()
	{
		int waittime = 5000;
		NET_CTRL_OPEN_STROBE structure = new NET_CTRL_OPEN_STROBE
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_OPEN_STROBE)),
			nChannelId = 0,
			szPlateNumber = ""
		};
		IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_OPEN_STROBE)));
		Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
		if (!NETClient.ControlDevice(_logHandle, EM_CtrlType.OPEN_STROBE, intPtr, waittime))
		{
			LogSave.DHLog(DateTime.Now.ToString() + "开闸失败：" + NETClient.GetLastError());
		}
		Marshal.FreeHGlobal(intPtr);
	}

	public void Snap(string model)
	{
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(model);
		if (tb_Device.ChannelNo == Convert.ToInt32(dictionary["ChannelNo"]) && tb_Device.id != Convert.ToInt32(dictionary["DeviceId"]))
		{
			ID = Convert.ToInt32(dictionary["id"]);
			string text = FormHelper.BuildImagePath(MainData.strImageDir, "jpg");
			if (NETClient.CapturePicture(m_RealPlayID, text, EM_NET_CAPTURE_FORMATS.JPEG))
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
				videoClientOpen_DAHUA();
				lastDateTime = DateTime.Now;
				if (isClose)
				{
					break;
				}
			}
			Thread.Sleep(50);
		}
	}

	public void videoClientOpen_DAHUA()
	{
		lock (DaHua_lock)
		{
			if (!(_logHandle != IntPtr.Zero))
			{
				try
				{
					_logHandle = NETClient.Login(tb_Device.CameraIP, 37777, MainData.DHUserName, MainData.DHPassword, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref m_DeviceInfo);
					LogSave.DHLog(DateTime.Now.ToString() + "tb_Device.CameraIP: " + tb_Device.CameraIP + ";_logHandle:" + _logHandle);
					if (_logHandle == IntPtr.Zero)
					{
						setButtonEnable(btEnable: false);
						return;
					}
					m_RealPlayID = NETClient.RealPlay(_logHandle, 0, videoHandle);
					LogSave.DHLog(DateTime.Now.ToString() + "tb_Device.CameraIP: " + tb_Device.CameraIP + ";m_RealPlayID:" + m_RealPlayID);
					if (IntPtr.Zero == m_RealPlayID)
					{
						setButtonEnable(btEnable: false);
						return;
					}
					if (_logHandle != IntPtr.Zero && m_RealPlayID != IntPtr.Zero)
					{
						IntPtr intPtr = NETClient.RealLoadPicture(_logHandle, 0, 1u, bNeedPicFile: true, m_AnalyzerDataCallBack, _logHandle, IntPtr.Zero);
						if (IntPtr.Zero == intPtr)
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

	private int AnalyzerDataCallBack(IntPtr lAnalyzerHandle, uint dwEventType, IntPtr pEventInfo, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser, int nSequence, IntPtr reserved)
	{
		try
		{
			if (MainData.IsBecomeDue)
			{
				isrg = false;
				return 0;
			}
			if (_logHandle == dwUser)
			{
				lock ("video_DaHua_CALLBACK")
				{
					NET_A_DEV_EVENT_TRAFFICJUNCTION_INFO nET_A_DEV_EVENT_TRAFFICJUNCTION_INFO = (NET_A_DEV_EVENT_TRAFFICJUNCTION_INFO)Marshal.PtrToStructure(pEventInfo, typeof(NET_A_DEV_EVENT_TRAFFICJUNCTION_INFO));
					if (nET_A_DEV_EVENT_TRAFFICJUNCTION_INFO.stTrafficCar.szPlateNumber == "")
					{
						LogSave.DHLog(DateTime.Now.ToString() + "无牌车");
						nET_A_DEV_EVENT_TRAFFICJUNCTION_INFO.stTrafficCar.szPlateNumber = "无牌车";
					}
					string text = nET_A_DEV_EVENT_TRAFFICJUNCTION_INFO.stTrafficCar.szPlateNumber;
					LogSave.DHLog(DateTime.Now.ToString() + text + "车牌开始颜色" + nET_A_DEV_EVENT_TRAFFICJUNCTION_INFO.stTrafficCar.szPlateColor);
					if (text.Contains("无牌"))
					{
						LogSave.DHLog(DateTime.Now.ToString() + "包含车牌" + text);
						isrg = false;
						return 0;
					}
					DateTime now = DateTime.Now;
					string empty = string.Empty;
					switch (nET_A_DEV_EVENT_TRAFFICJUNCTION_INFO.stTrafficCar.szPlateColor)
					{
					case "Blue":
						empty = "蓝色";
						break;
					case "Yellow":
						empty = "黄色";
						break;
					case "White":
						empty = "白色";
						break;
					case "Black":
						empty = "黑色";
						break;
					case "Green":
					case "ShadowGreen":
						empty = "绿色";
						break;
					case "YellowGreen":
						empty = "黄绿色";
						break;
					default:
						empty = "其他";
						break;
					}
					string text2 = "";
					string text3 = "";
					showVehicleNo(text + "，平台验证中！");
					byte[] array = new byte[0];
					if (IntPtr.Zero != pBuffer && dwBufSize != 0)
					{
						text2 = Path.Combine(MainData.strImageDir, now.ToString("yyyyMMddHHmmssfff") + "big.jpg");
						text3 = Path.Combine(MainData.strImageDir, now.ToString("yyyyMMddHHmmssfff") + "small.jpg");
						array = new byte[dwBufSize];
						Marshal.Copy(pBuffer, array, 0, (int)dwBufSize);
						uint dwOffSet = nET_A_DEV_EVENT_TRAFFICJUNCTION_INFO.stuObject.stPicInfo.dwOffSet;
						uint dwFileLenth = nET_A_DEV_EVENT_TRAFFICJUNCTION_INFO.stuObject.stPicInfo.dwFileLenth;
						if (dwFileLenth != 0 && dwOffSet != 0 && array.Length >= dwOffSet + dwFileLenth)
						{
							byte[] array2 = new byte[dwOffSet];
							Array.Copy(array, 0L, array2, 0L, dwOffSet - 1);
							byte[] array3 = new byte[dwFileLenth];
							Array.Copy(array, dwOffSet, array3, 0L, dwFileLenth);
							FileStream fileStream = new FileStream(text2, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
							fileStream.Write(array3, 0, array3.Length);
							fileStream.Close();
							fileStream.Dispose();
							FileStream fileStream2 = new FileStream(text3, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
							fileStream2.Write(array2, 0, array2.Length);
							fileStream2.Close();
							fileStream2.Dispose();
						}
						else
						{
							FileStream fileStream3 = new FileStream(text3, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
							fileStream3.Write(array, 0, (int)dwBufSize);
							fileStream3.Close();
							fileStream3.Dispose();
						}
					}
					bool IsRelease;
					VehicleNoInfoView vehicleNoInfoView;
					if (tb_Device.CameraType == "标准相机")
					{
						IsRelease = true;
						vehicleNoInfoView = new VehicleNoInfoView();
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
						if (!isrg)
						{
							if (seniorSet == null)
							{
								goto IL_0601;
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
								if (array5 == null || array5.Length == 0 || !array5.Contains(empty) || new DataServerContext<tb_car_info>().Current.GetModel((tb_car_info it) => it.car_no == text) != null)
								{
									goto IL_0601;
								}
								vehicleNoInfoView.ExeLog = "此车牌号不属于白名单";
								vehicleNoInfoView.TrafficStatus = "禁止通行";
							}
							goto IL_0764;
						}
						goto IL_1116;
					}
					goto end_IL_002f;
					IL_08d8:
				if (MainData.DJPT == "高凌")
				{
					string text4 = "0";
					text4 = tb_Channel.ChannelPort;
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
					if (!isBlacklisted && !CommonHelper.GLVerify(text, vehicleNoInfoView.licenseColor, text4, ref msg, ref vehicleNoInfoView))
					{
						isUpload = true;
						IsRelease = false;
						vehicleNoInfoView.ExeLog = msg;
					}
					if (!MainData.RecordSave(text2, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView, isUpload))
					{
						IsRelease = false;
						vehicleNoInfoView.ExeLog = msg + ";;保存失败";
					}
				}
				else if (MainData.DJPT == "中科九州")
					{
						string text5 = "A";
						text5 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
						string msg2 = "";
						string text6 = "";
						string text7 = "";
						if (CommonHelper.KangFengV1Verify(text, empty, tb_Channel.ChannelPort, text5, ref msg2, ref vehicleNoInfoView))
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
							vehicleNoInfoView.ExeLog = msg2;
							if (vehicleNoInfoView.serialNum == null || string.IsNullOrWhiteSpace(vehicleNoInfoView.serialNum))
							{
								text7 = "禁止重复上传";
								goto IL_0764;
							}
							text7 = ((!MainData.barriergate_upload) ? "禁止上传" : "未上传");
						}
						if (!MainData.KaiFengRecordSave(text2, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text6, text7, ref vehicleNoInfoView))
						{
							vehicleNoInfoView.ExeLog = "保存失败";
							IsRelease = false;
						}
					}
					else if (MainData.DJPT == "安车")
					{
						string msg3 = "";
						string text8 = "";
						string text9 = "";
						if (CommonHelper.AnCheVerify(text, empty, ref msg3, ref vehicleNoInfoView, tb_Channel.ChannelPort))
						{
							text9 = "未上传";
							text8 = "摆杆通行";
						}
						else
						{
							text9 = "禁止上传";
							text8 = "未摆杆";
							IsRelease = false;
							vehicleNoInfoView.ExeLog = msg3;
						}
						string text10 = "A";
						text10 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
						vehicleNoInfoView.serialNum = MainData.ACEnterpriseID + tb_Channel.ChannelPort + text10 + vehicleNoInfoView.AddTime.ToString("yyMMddHHmmss");
						if (!MainData.KaiFengRecordSave(text2, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text8, text9, ref vehicleNoInfoView))
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
							isJS = true;
						}
						else
						{
							IsRelease = false;
							vehicleNoInfoView.ExeLog = msg4;
						}
						if (!MainData.RecordSave(text2, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null, isUpload: false, "", isJS))
						{
							vehicleNoInfoView.ExeLog = "保存失败";
							IsRelease = false;
						}
					}
					else if (MainData.DJPT == "消纳场")
					{
						string text11 = "1";
						text11 = ((!(tb_Channel.ChannelType == "入口")) ? "2" : "1");
						string msg5 = "";
						if (CommonHelper.XNCVerify(text, empty, tb_Device.deviceId, text11, ref msg5))
						{
							if (MainData.RecordSave(text2, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null))
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
						string text12 = "";
						string text13 = "";
						if (CommonHelper.tdrcCheVerify(text, empty, ref msg6, ref vehicleNoInfoView))
						{
							text13 = "未上传";
							text12 = "摆杆通行";
						}
						else
						{
							text13 = "禁止上传";
							text12 = "未摆杆";
							IsRelease = false;
							vehicleNoInfoView.ExeLog = msg6;
						}
						string text14 = "A";
						text14 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
						vehicleNoInfoView.serialNum = MainData.ACorgan + tb_Channel.ChannelPort + text14 + DateTime.Now.ToString("yyMMddHHmmss");
						if (!MainData.KaiFengRecordSave(text2, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text12, text13, ref vehicleNoInfoView))
						{
							vehicleNoInfoView.ExeLog = "保存失败";
							IsRelease = false;
						}
					}
					else if (MainData.DJPT == "信阳")
					{
						string msg7 = "";
						string text15 = "";
						string text16 = "";
						if (CommonHelper.xyCheVerify(text, empty, ref msg7, ref vehicleNoInfoView))
						{
							text16 = "未上传";
							text15 = "摆杆通行";
						}
						else
						{
							text16 = "禁止上传";
							text15 = "未摆杆";
							IsRelease = false;
							vehicleNoInfoView.ExeLog = msg7;
						}
						string text17 = "A";
						text17 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
						vehicleNoInfoView.serialNum = MainData.xyOrgan + tb_Channel.ChannelPort + text17 + DateTime.Now.ToString("yyMMddHHmmss");
						if (!MainData.KaiFengRecordSave(text2, text3, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text15, text16, ref vehicleNoInfoView))
						{
							vehicleNoInfoView.ExeLog = "保存失败";
							IsRelease = false;
						}
					}
					goto IL_0764;
					IL_0764:
					if (MainData.dnyybb)
					{
						Task.Factory.StartNew(delegate
						{
							string text18 = "禁止通行";
							if (IsRelease)
							{
								text18 = "允许通行";
								SpeechSynthesizer obj = new SpeechSynthesizer
								{
									Rate = 1,
									Volume = 100
								};
								text = vehicleNoInfoView.VehicleNo + vehicleNoInfoView.emissionStandard + vehicleNoInfoView.fuelType + text18;
								obj.Speak(text);
							}
							else
							{
								text18 = "禁止通行";
								SpeechSynthesizer obj2 = new SpeechSynthesizer
								{
									Rate = 1,
									Volume = 100
								};
								text = vehicleNoInfoView.VehicleNo + text18;
								obj2.Speak(text);
							}
						});
					}
					if (MainData.scfwq && IsRelease)
					{
						CommonHelper.BstPost(new Dictionary<string, object>
						{
							["licenseColor"] = empty,
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
					showVehicleNo(text);
					LogSave.DHLog(DateTime.Now.ToString() + text + "车牌结束");
					goto IL_1116;
					IL_1116:
					if (isrg)
					{
						isrg = false;
						OutSystem.AddOut(vehicleNoInfoView);
					}
					goto end_IL_002f;
					IL_0601:
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
							goto IL_08d8;
						}
					}
					else
					{
						if (MainData.SDZK)
						{
							isrg = true;
							goto IL_1116;
						}
						if (!MainData.LSCSN)
						{
							goto IL_08d8;
						}
						vehicleNoInfoView.ExeLog = "临时车禁止通行";
						IsRelease = false;
					}
					goto IL_0764;
					end_IL_002f:;
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog(DateTime.Now.ToString() + ex.ToString());
		}
		return 0;
	}

	public void LEDPlay(bool IsRelease, VehicleNoInfoView vehicleNoInfoView)
	{
		if (!IsRelease)
		{
			Led(vehicleNoInfoView.VehicleNo, isOpen: false, vehicleNoInfoView);
			vehicleNoInfoView.TrafficStatus = "禁止通行";
			return;
		}
		if (!MainData.bxtxhw)
		{
			if (tb_Device.OpeningMethod == "0")
			{
				openType = 2;
				Open();
			}
			else if (UserControlDH.Operation != null)
			{
				UserControlDH.Operation(Convert.ToInt32(tb_Device.OpeningMethod), 2);
			}
		}
		Led(vehicleNoInfoView.VehicleNo, isOpen: true, vehicleNoInfoView);
		vehicleNoInfoView.TrafficStatus = "允许通行";
		vehicleNoInfoView.ExeLog = "允许通行";
	}

	public string storePic(IntPtr vCloseUpPicData, uint nCloseUpPicLen)
	{
		string text = DateTime.Now.ToString("yyyyMMddHHmmssfff");
		string text2 = "";
		text2 = Path.Combine(MainData.strImageDir, text + ".jpg");
		try
		{
			byte[] array = new byte[nCloseUpPicLen];
			Marshal.Copy(vCloseUpPicData, array, 0, array.Length);
			FileStream fileStream = new FileStream(text2, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
			fileStream.Write(array, 0, array.Length);
			fileStream.Close();
			fileStream.Dispose();
			return text2;
		}
		catch (Exception)
		{
			return "";
		}
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
			openType = 1;
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
			Open();
		}
		else if (UserControlDH.Operation != null)
		{
			UserControlDH.Operation(Convert.ToInt32(tb_Device.OpeningMethod), 1);
		}
	}

	private void timer1_Tick_1(object sender, EventArgs e)
	{
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		int waittime = 5000;
		NET_CTRL_OPEN_STROBE structure = new NET_CTRL_OPEN_STROBE
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_OPEN_STROBE)),
			nChannelId = 0,
			szPlateNumber = ""
		};
		IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_OPEN_STROBE)));
		Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
		NETClient.ControlDevice(_logHandle, EM_CtrlType.CLOSE_STROBE, intPtr, waittime);
		Marshal.FreeHGlobal(intPtr);
	}

	public void showVehicleNo(string vehicleNo)
	{
		lalCarNo.Invoke((Action<string>)delegate(string p)
		{
			lalCarNo.Text = p;
		}, vehicleNo);
	}

	public void Led(string VehicleNo, bool isOpen, VehicleNoInfoView vehicleNoInfoView)
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
		EM_CtrlType emType = EM_CtrlType.SET_PARK_CONTROL_INFO;
		NET_IN_SET_PARK_CONTROL_INFO structure = new NET_IN_SET_PARK_CONTROL_INFO
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_IN_SET_PARK_CONTROL_INFO)),
			stuScreenShowInfo = new NET_SCREEN_SHOW_INFO[16]
		};
		string text = "";
		if (tb_Device.motherboardType.Equals("DH-2竖屏"))
		{
			timer.Stop();
			structure.nScreenShowInfoNum = 2;
			if (isOpen)
			{
				text = "允许通行";
				structure.stuScreenShowInfo[0].nScreenNo = 0u;
				structure.stuScreenShowInfo[0].szText = VehicleNo + ":允许通行";
				structure.stuScreenShowInfo[0].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[0].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[0].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[0].nRollSpeed = 2u;
				structure.stuScreenShowInfo[0].nDisplayEffect = 2;
				structure.stuScreenShowInfo[1].nScreenNo = 1u;
				structure.stuScreenShowInfo[1].szText = "燃料类型:" + vehicleNoInfoView.fuelType + "排放阶段:" + vehicleNoInfoView.emissionStandard;
				structure.stuScreenShowInfo[1].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[1].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[1].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[1].nRollSpeed = 2u;
				structure.stuScreenShowInfo[1].nDisplayEffect = 2;
			}
			else
			{
				text = "禁止通行";
				structure.stuScreenShowInfo[0].nScreenNo = 0u;
				structure.stuScreenShowInfo[0].szText = VehicleNo + ":禁止通行";
				structure.stuScreenShowInfo[0].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[0].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[0].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[0].nRollSpeed = 2u;
				structure.stuScreenShowInfo[0].nDisplayEffect = 2;
				structure.stuScreenShowInfo[1].nScreenNo = 1u;
				structure.stuScreenShowInfo[1].szText = vehicleNoInfoView.ExeLog;
				structure.stuScreenShowInfo[1].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[1].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[1].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[1].nRollSpeed = 2u;
				structure.stuScreenShowInfo[1].nDisplayEffect = 2;
			}
			timer.Start();
		}
		else
		{
			timer.Stop();
			if (isOpen)
			{
				text = "允许通行";
				structure.nScreenShowInfoNum = 4;
				structure.stuScreenShowInfo[0].nScreenNo = 0u;
				structure.stuScreenShowInfo[0].szText = VehicleNo;
				structure.stuScreenShowInfo[0].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[0].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[0].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[0].nRollSpeed = 2u;
				structure.stuScreenShowInfo[0].nDisplayEffect = 2;
				structure.stuScreenShowInfo[1].nScreenNo = 1u;
				structure.stuScreenShowInfo[1].szText = "允许通行";
				structure.stuScreenShowInfo[1].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[1].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[1].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[1].nRollSpeed = 2u;
				structure.stuScreenShowInfo[1].nDisplayEffect = 2;
				structure.stuScreenShowInfo[2].nScreenNo = 2u;
				structure.stuScreenShowInfo[2].szText = "燃料类型:" + vehicleNoInfoView.fuelType;
				structure.stuScreenShowInfo[2].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[2].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[2].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[2].nRollSpeed = 2u;
				structure.stuScreenShowInfo[2].nDisplayEffect = 2;
				structure.stuScreenShowInfo[3].nScreenNo = 3u;
				LogSave.DHLog("排放阶段:" + vehicleNoInfoView.emissionStandard);
				structure.stuScreenShowInfo[3].szText = "排放阶段:" + vehicleNoInfoView.emissionStandard;
				structure.stuScreenShowInfo[3].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[3].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[3].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[3].nRollSpeed = 2u;
				structure.stuScreenShowInfo[3].nDisplayEffect = 2;
			}
			else
			{
				text = "禁止通行";
				structure.nScreenShowInfoNum = 4;
				structure.stuScreenShowInfo[0].nScreenNo = 0u;
				structure.stuScreenShowInfo[0].szText = VehicleNo;
				structure.stuScreenShowInfo[0].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[0].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[0].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[0].nRollSpeed = 2u;
				structure.stuScreenShowInfo[0].nDisplayEffect = 2;
				structure.stuScreenShowInfo[1].nScreenNo = 1u;
				structure.stuScreenShowInfo[1].szText = "禁止通行";
				structure.stuScreenShowInfo[1].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[1].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[1].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[1].nRollSpeed = 2u;
				structure.stuScreenShowInfo[1].nDisplayEffect = 2;
				structure.stuScreenShowInfo[2].nScreenNo = 2u;
				structure.stuScreenShowInfo[2].szText = vehicleNoInfoView.ExeLog;
				structure.stuScreenShowInfo[2].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
				structure.stuScreenShowInfo[2].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
				structure.stuScreenShowInfo[2].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
				structure.stuScreenShowInfo[2].nRollSpeed = 2u;
				structure.stuScreenShowInfo[2].nDisplayEffect = 2;
			}
			timer.Start();
		}
		structure.nBroadcastInfoNum = 1;
		structure.stuBroadcastInfo = new NET_BROADCAST_INFO[16];
		structure.stuBroadcastInfo[0].szText = VehicleNo + text;
		structure.stuBroadcastInfo[0].emTextType = EM_BROADCAST_TEXT_TYPE.PLATE_NUMBER;
		NET_OUT_SET_PARK_CONTROL_INFO structure2 = new NET_OUT_SET_PARK_CONTROL_INFO
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_SET_PARK_CONTROL_INFO))
		};
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			if (!NETClient.ControlDeviceEx(_logHandle, emType, intPtr, intPtr2, 3000))
			{
				LogSave.DHLog(DateTime.Now.ToString() + "LED播放失败：" + NETClient.GetLastError());
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			intPtr = IntPtr.Zero;
			Marshal.FreeHGlobal(intPtr2);
			intPtr2 = IntPtr.Zero;
		}
	}

	public void Send485(byte[] data)
	{
	}

	public void Close()
	{
		NETClient.StopRealPlay(m_RealPlayID);
		NETClient.Logout(_logHandle);
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		EM_CtrlType emType = EM_CtrlType.SET_PARK_CONTROL_INFO;
		NET_IN_SET_PARK_CONTROL_INFO structure = new NET_IN_SET_PARK_CONTROL_INFO
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_IN_SET_PARK_CONTROL_INFO)),
			stuScreenShowInfo = new NET_SCREEN_SHOW_INFO[16]
		};
		_ = tb_Channel.ChannelType == "出口";
		if (tb_Device.motherboardType.Equals("DH-2竖屏"))
		{
			structure.nScreenShowInfoNum = 2;
			structure.stuScreenShowInfo[0].nScreenNo = 0u;
			structure.stuScreenShowInfo[0].szText = "%Y-%M-%D-%H-%m-%S-%W";
			structure.stuScreenShowInfo[0].emTextType = EM_SCREEN_TEXT_TYPE.LOCAL_TIME;
			structure.stuScreenShowInfo[0].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
			structure.stuScreenShowInfo[0].nRollSpeed = 1u;
			structure.stuScreenShowInfo[0].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
			structure.stuScreenShowInfo[0].nDisplayEffect = 2;
			structure.stuScreenShowInfo[1].nScreenNo = 1u;
			structure.stuScreenShowInfo[1].szText = "减速慢行";
			structure.stuScreenShowInfo[1].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
			structure.stuScreenShowInfo[1].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
			structure.stuScreenShowInfo[1].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
			structure.stuScreenShowInfo[1].nRollSpeed = 1u;
			structure.stuScreenShowInfo[0].nDisplayEffect = 2;
		}
		else
		{
			structure.nScreenShowInfoNum = 4;
			structure.stuScreenShowInfo[0].nScreenNo = 0u;
			structure.stuScreenShowInfo[0].szText = "%Y-%M-%D-%H-%m-%S-%W";
			structure.stuScreenShowInfo[0].emTextType = EM_SCREEN_TEXT_TYPE.LOCAL_TIME;
			structure.stuScreenShowInfo[0].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
			structure.stuScreenShowInfo[0].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
			structure.stuScreenShowInfo[0].nRollSpeed = 1u;
			structure.stuScreenShowInfo[0].nDisplayEffect = 2;
			structure.stuScreenShowInfo[1].nScreenNo = 1u;
			structure.stuScreenShowInfo[1].szText = "一车一杆";
			structure.stuScreenShowInfo[1].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
			structure.stuScreenShowInfo[1].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
			structure.stuScreenShowInfo[1].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
			structure.stuScreenShowInfo[1].nRollSpeed = 1u;
			structure.stuScreenShowInfo[1].nDisplayEffect = 2;
			structure.stuScreenShowInfo[2].nScreenNo = 2u;
			structure.stuScreenShowInfo[2].szText = "减速慢行";
			structure.stuScreenShowInfo[2].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
			structure.stuScreenShowInfo[2].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
			structure.stuScreenShowInfo[2].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
			structure.stuScreenShowInfo[2].nRollSpeed = 1u;
			structure.stuScreenShowInfo[2].nDisplayEffect = 2;
			structure.stuScreenShowInfo[3].nScreenNo = 3u;
			structure.stuScreenShowInfo[3].szText = "请勿跟车";
			structure.stuScreenShowInfo[3].emTextType = EM_SCREEN_TEXT_TYPE.ORDINARY;
			structure.stuScreenShowInfo[3].emTextColor = EM_SCREEN_TEXT_COLOR.RED;
			structure.stuScreenShowInfo[3].emTextRollMode = EM_SCREEN_TEXT_ROLL_MODE.UP_DOWN;
			structure.stuScreenShowInfo[3].nRollSpeed = 1u;
			structure.stuScreenShowInfo[3].nDisplayEffect = 2;
		}
		structure.nBroadcastInfoNum = 0;
		NET_OUT_SET_PARK_CONTROL_INFO structure2 = new NET_OUT_SET_PARK_CONTROL_INFO
		{
			dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_SET_PARK_CONTROL_INFO))
		};
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
			Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
			if (!NETClient.ControlDeviceEx(_logHandle, emType, intPtr, intPtr2, 3000))
			{
				LogSave.DHLog(DateTime.Now.ToString() + "LED播放失败：" + NETClient.GetLastError());
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			intPtr = IntPtr.Zero;
			Marshal.FreeHGlobal(intPtr2);
			intPtr2 = IntPtr.Zero;
			timer.Stop();
		}
	}

	private void LedSetTime_Click(object sender, EventArgs e)
	{
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
		NET_MANUAL_SNAP_PARAMETER structure = new NET_MANUAL_SNAP_PARAMETER
		{
			byReserved = new byte[60],
			nChannel = 0,
			bySequence = ""
		};
		IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_MANUAL_SNAP_PARAMETER)));
		Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
		bool flag = NETClient.ControlDevice(_logHandle, EM_CtrlType.MANUAL_SNAP, intPtr, 3000);
		Marshal.FreeHGlobal(intPtr);
		if (!flag)
		{
			LogSave.DHLog(DateTime.Now.ToString() + "抬杆错误" + flag);
		}
		else
		{
			isrg = true;
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
										DateTime start = DateTime.Now.AddSeconds(-60.0);
										DateTime end = DateTime.Now.AddSeconds(60.0);
										string text = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
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
										new DHSDK().Download(now, now.AddMinutes(1.0), value, zpjList.ChannelID, logHandle);
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
						tb_videotape zpjList = MainData.tb_Videotapes.FirstOrDefault((tb_videotape it) => it.id == tb_Device.SnapId);
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
									new DHSDK().Download(now2, now2.AddMinutes(-1.0), value, zpjList.ChannelID, logHandle);
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
		this.btnOpen = new System.Windows.Forms.Button();
		this.lalCarNo = new System.Windows.Forms.Label();
		this.LedSetTime = new System.Windows.Forms.Button();
		this.btnClose = new System.Windows.Forms.Button();
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
		this.tableLayoutPanel1.Size = new System.Drawing.Size(592, 495);
		this.tableLayoutPanel1.TabIndex = 1;
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
		this.tableLayoutPanel2.Controls.Add(this.LedSetTime, 3, 0);
		this.tableLayoutPanel2.Controls.Add(this.btnClose, 2, 0);
		this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 458);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 1;
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel2.Size = new System.Drawing.Size(586, 34);
		this.tableLayoutPanel2.TabIndex = 0;
		this.btnOpen.Dock = System.Windows.Forms.DockStyle.Fill;
		this.btnOpen.Location = new System.Drawing.Point(100, 3);
		this.btnOpen.Name = "btnOpen";
		this.btnOpen.Size = new System.Drawing.Size(91, 28);
		this.btnOpen.TabIndex = 0;
		this.btnOpen.Text = "开闸";
		this.btnOpen.UseVisualStyleBackColor = true;
		this.btnOpen.Click += new System.EventHandler(btnOpen_Click);
		this.lalCarNo.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.lalCarNo.AutoSize = true;
		this.lalCarNo.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.lalCarNo.Location = new System.Drawing.Point(446, 6);
		this.lalCarNo.Name = "lalCarNo";
		this.lalCarNo.Size = new System.Drawing.Size(82, 21);
		this.lalCarNo.TabIndex = 2;
		this.lalCarNo.Text = "豫A00000";
		this.LedSetTime.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LedSetTime.Location = new System.Drawing.Point(294, 3);
		this.LedSetTime.Name = "LedSetTime";
		this.LedSetTime.Size = new System.Drawing.Size(91, 28);
		this.LedSetTime.TabIndex = 3;
		this.LedSetTime.Text = "LED同步时间";
		this.LedSetTime.UseVisualStyleBackColor = true;
		this.LedSetTime.Click += new System.EventHandler(LedSetTime_Click);
		this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
		this.btnClose.Location = new System.Drawing.Point(197, 3);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(91, 28);
		this.btnClose.TabIndex = 1;
		this.btnClose.Text = "关闸";
		this.btnClose.UseVisualStyleBackColor = true;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.gboxheader.Controls.Add(this.pboxQY);
		this.gboxheader.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gboxheader.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.gboxheader.Location = new System.Drawing.Point(3, 3);
		this.gboxheader.Name = "gboxheader";
		this.gboxheader.Size = new System.Drawing.Size(586, 449);
		this.gboxheader.TabIndex = 2;
		this.gboxheader.TabStop = false;
		this.pboxQY.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pboxQY.Location = new System.Drawing.Point(3, 25);
		this.pboxQY.Name = "pboxQY";
		this.pboxQY.Size = new System.Drawing.Size(580, 421);
		this.pboxQY.TabIndex = 1;
		this.pboxQY.TabStop = false;
		this.timer1.Enabled = true;
		this.timer1.Interval = 5000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick_1);
		this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.button1.Location = new System.Drawing.Point(3, 3);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(91, 28);
		this.button1.TabIndex = 4;
		this.button1.Text = "抓拍";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.tableLayoutPanel1);
		base.Name = "UserControlDH";
		base.Size = new System.Drawing.Size(592, 495);
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		this.gboxheader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pboxQY).EndInit();
		base.ResumeLayout(false);
	}
}
