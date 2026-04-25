// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.UserControlQY

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
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

public class UserControlQY : UserControl, IVideoMngInterface
{
	public delegate void OpeningOperation(int msg, byte type, int SnapId, tb_Channel currentChannel, string car_no);

	public delegate void CarRecord(VehicleNoInfoView vehicleNoInfoView);

	private delegate void SetButtonEnableThread();

	public int _logHandle = -1;

	private Thread videoNetThread;

	private bool isClose;

	private DateTime lastDateTime = DateTime.Now.AddSeconds(-31.0);

	public string IP = "";

	public tb_Channel tb_Channel;

	public tb_Device tb_Device;

	public tb_videotape tb_Videotape;

	private static QianYe_SDK.FGetImageCB2 fGetImageCB2;

	private XNCResultModel xNCResultModel = new XNCResultModel();

	public int SnapId;

	public tb_Channel currentChannel;

	private string car_no = "";

	public byte openType;

	private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

	private static QianYe_SDK.FGetReportCBEx fGetReportCBEx;

	public bool IsEnd;

	private IntPtr videoHandle;

	private string id = Guid.NewGuid().ToString("N");

	private int ID;

	private bool isrg;

	public tb_large_screen Tb_Large_Screen;

	public tb_ChannelSeniorSet seniorSet;

	private object QianYe_lock = new object();

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

	public UserControlQY()
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
			xNCResultModel = CommonHelper.PoleXNCResultModel("http://42.236.61.105:8686/approval/county/inoutDevice", MainData.XNCKEY, MainData.XNCSecret, list);
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
		Control.CheckForIllegalCrossThreadCalls = false;
		videoHandle = pboxQY.Handle;
		gboxheader.Text = tb_Device.CameraName;
		Operation += UserControlQY_Operation;
		fGetImageCB2 = MainData.video_QianYe_FGetImageCB2;
		fGetReportCBEx = MainData.video_QianYe_FGetImageIO;
		timer1.Interval = 3000;
		timer1.Tick += Timer1_Tick;
		timer2.Start();
		seniorSet = new DataServerContext<tb_ChannelSeniorSet>().Current.GetModel((tb_ChannelSeniorSet it) => it.ChannelId == tb_Channel.id);
		DataServerContext<tb_large_screen> dataServerContext = new DataServerContext<tb_large_screen>();
		Tb_Large_Screen = dataServerContext.Current.GetList((tb_large_screen it) => it.id == tb_Device.bigScreenId).FirstOrDefault();
		OutSystem.carOutRecord += OutSystem_carOutRecord;
		MqttClientService.openMessage += MqttClientService_openMessage;
		TCPSeerver.carTcpRecord += TCPSeerver_carTcpRecord;
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
			if (!CommonHelper.GLVerify(text, licenseColor, text3, ref msg2, ref vehicleNoInfoView))
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

	private void TCPSeerver_carTcpRecord(string ip, byte type)
	{
		if (tb_Device.bjip.Equals(ip))
		{
			barrierGate(type);
		}
	}

	private void MqttClientService_openMessage(string channelId)
	{
		if (tb_Channel.id == Convert.ToInt32(channelId))
		{
			if (tb_Device.OpeningMethod == "0")
			{
				openType = 1;
				Open();
			}
			else if (UserControlQY.Operation != null)
			{
				UserControlQY.Operation(Convert.ToInt32(tb_Device.OpeningMethod), 1, tb_Device.SnapId, tb_Channel, "");
			}
		}
	}

	private void timer2_Tick(object sender, EventArgs e)
	{
		if (MainData.DJPT == "天地人车")
		{
			CommonHelper.tdrcGateStatusReport(tb_Channel.ChannelPort, "1");
		}
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
				videoClientOpen_QianYe();
				lastDateTime = DateTime.Now;
				if (isClose)
				{
					break;
				}
			}
			Thread.Sleep(50);
		}
	}

	public void videoClientOpen_QianYe()
	{
		lock (QianYe_lock)
		{
			if (_logHandle >= 0)
			{
				if (QianYe_SDK.Net_QueryConnState(_logHandle) != 0)
				{
					setButtonEnable(btEnable: false);
				}
			}
			else
			{
				try
				{
					_logHandle = QianYe_SDK.Net_AddCamera(tb_Device.CameraIP);
					LogSave.QYLog(DateTime.Now.ToString() + "芊熠登录返回：" + _logHandle);
					if (_logHandle == -1)
					{
						setButtonEnable(btEnable: false);
					}
					int num = QianYe_SDK.Net_ConnCamera(_logHandle, 30000, 1);
					LogSave.QYLog(DateTime.Now.ToString() + "芊熠连接：" + num);
					num = QianYe_SDK.Net_StartVideo(_logHandle, 0, videoHandle);
					LogSave.QYLog(DateTime.Now.ToString() + "芊熠播放：" + num);
					if (num == 0 && tb_Device.CameraType == "标准相机")
					{
						MainData.HtQianYeCallBackDel[_logHandle] = new MainData.video_QianYe_FGetImageCB2Delegate(video_QianYe_FGetImageCB2);
						MainData.HtQianYeCallBackIO[_logHandle] = new MainData.video_QianYe_FGetImageIODelegate(FGetReportCBEx);
						QianYe_SDK.Net_RegReportMessEx(_logHandle, fGetReportCBEx, IntPtr.Zero);
						QianYe_SDK.Net_RegImageRecv2(fGetImageCB2);
						setButtonEnable(btEnable: true);
					}
				}
				catch (Exception)
				{
				}
			}
		}
		IsEnd = false;
	}

	public static object BytesToStruct(byte[] bytes, Type strcutType)
	{
		int num = Marshal.SizeOf(strcutType);
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		try
		{
			Marshal.Copy(bytes, 0, intPtr, num);
			return Marshal.PtrToStructure(intPtr, strcutType);
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	private int FGetReportCBEx(int tHandle, byte ucType, IntPtr ptMessage, IntPtr pUserData)
	{
		if (ucType == 7)
		{
			Marshal.SizeOf(default(QianYe_SDK.T_IOStateRsp));
			QianYe_SDK.T_IOStateRsp t_IOStateRsp = (QianYe_SDK.T_IOStateRsp)Marshal.PtrToStructure(ptMessage, typeof(QianYe_SDK.T_IOStateRsp));
			LogSave.QYLog(DateTime.Now.ToString() + ";;IP=" + tb_Device.CameraIP + "ucType=" + ucType + ";;t_IOStateRsp=" + t_IOStateRsp.ucLState + "openType=" + openType);
			barrierGate(t_IOStateRsp.ucLState);
		}
		return 0;
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
		else if (UserControlQY.Operation != null)
		{
			UserControlQY.Operation(Convert.ToInt32(tb_Device.OpeningMethod), 1, tb_Device.SnapId, tb_Channel, "");
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		QianYe_SDK.T_ControlGate ptControlGate = new QianYe_SDK.T_ControlGate
		{
			ucState = 2,
			ucReserved = new byte[3]
		};
		QianYe_SDK.Net_GateSetup(_logHandle, ref ptControlGate);
		string text = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
		string sVideoFileName = "E:\\Download\\" + text + ".mp4";
		DateTime now = DateTime.Now;
		MainData.hKLXJ.Add(now.AddMinutes(-5.0), now.AddMinutes(-4.0), 1, 1, sVideoFileName);
	}

	public void Open()
	{
		LogSave.QYLog(DateTime.Now.ToString() + "开闸");
		QianYe_SDK.T_ControlGate ptControlGate = new QianYe_SDK.T_ControlGate
		{
			ucState = 1,
			ucReserved = new byte[3]
		};
		QianYe_SDK.Net_GateSetup(_logHandle, ref ptControlGate);
		LogSave.QYLog(DateTime.Now.ToString() + "开闸结束");
	}

	private int video_QianYe_FGetImageCB2(int tHandle, uint uiImageId, ref QianYe_SDK.T_ImageUserInfo2 tImageInfo, ref QianYe_SDK.T_PicInfo tPicInfo)
	{
		try
		{
			if (MainData.IsBecomeDue)
			{
				return 0;
			}
			if (tHandle != _logHandle)
			{
				return -1;
			}
			if (tImageInfo.ucViolateCode != 0)
			{
				return -1;
			}
			if (tPicInfo.ptPanoramaPicBuff == IntPtr.Zero || tPicInfo.uiPanoramaPicLen == 0)
			{
				return -1;
			}
			if (!Directory.Exists(MainData.strImageDir))
			{
				Directory.CreateDirectory(MainData.strImageDir);
			}
			lock ("video_QianYe_FGetImageCB2")
			{
				string text = Encoding.Default.GetString(tImageInfo.szLprResult).Replace("\0", "");
				LedPrompt(text);
				LogSave.QYLog(DateTime.Now.ToString() + text + "车牌开始");
				if (text.IndexOf("加密") >= 0)
				{
					showVehicleNo(text);
					return -1;
				}
				showVehicleNo(text + "，平台验证中！");
				DateTime now = DateTime.Now;
				string empty = string.Empty;
				empty = tImageInfo.ucPlateColor switch
				{
					0 => "蓝色", 
					1 => "黄色", 
					2 => "白色", 
					3 => "黑色", 
					5 => "绿色", 
					6 => "黄绿色", 
					_ => "未识别", 
				};
				LogSave.QYLog(DateTime.Now.ToString() + text + empty);
				string text2 = "";
				try
				{
					byte[] array = new byte[tPicInfo.uiPanoramaPicLen];
					Marshal.Copy(tPicInfo.ptPanoramaPicBuff, array, 0, (int)tPicInfo.uiPanoramaPicLen);
					text2 = string.Format("{0}\\{1}.jpg", MainData.strImageDir, now.ToLocalTime().ToString("yyyyMMddHHmmssfff"));
					FileStream fileStream = new FileStream(text2, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
					fileStream.Write(array, 0, (int)tPicInfo.uiPanoramaPicLen);
					fileStream.Close();
					fileStream.Dispose();
				}
				catch (Exception)
				{
				}
				if (!(tb_Device.CameraType == "标准相机"))
				{
					goto IL_063b;
				}
				bool IsRelease = true;
				VehicleNoInfoView vehicleNoInfoView = new VehicleNoInfoView();
				vehicleNoInfoView.VehicleNo = text;
				vehicleNoInfoView.AddTime = DateTime.Now;
				vehicleNoInfoView.ChannelName = tb_Channel.ChannelName;
				vehicleNoInfoView.DeviceName = tb_Device.CameraName;
				vehicleNoInfoView.ChannelType = tb_Channel.ChannelType;
				vehicleNoInfoView.ImagePath = text2;
				vehicleNoInfoView.largeId = tb_Device.bigScreenId;
				vehicleNoInfoView.licenseColor = empty;
				vehicleNoInfoView.ChannelId = tb_Device.ChannelNo;
				vehicleNoInfoView.devId = tb_Device.id;
				if (!isrg)
				{
					if (seniorSet == null)
					{
						goto IL_0459;
					}
					string[] array2 = seniorSet.transitColour.Split(',');
					if (array2 != null && array2.Length != 0 && !array2.Contains(empty))
					{
						vehicleNoInfoView.ExeLog = "此通道禁止此车牌颜色通行";
						vehicleNoInfoView.TrafficStatus = "禁止通行";
						IsRelease = false;
					}
					else
					{
						string[] array3 = seniorSet.ColourWhiteList.Split(',');
						if (array3 == null || array3.Length == 0 || !array3.Contains(empty) || new DataServerContext<tb_car_info>().Current.GetModel((tb_car_info it) => it.car_no == text) != null)
						{
							goto IL_0459;
						}
						vehicleNoInfoView.ExeLog = "此车牌号不属于白名单";
						vehicleNoInfoView.TrafficStatus = "禁止通行";
						IsRelease = false;
					}
					goto IL_0663;
				}
				goto IL_106a;
				IL_063b:
				LogSave.QYLog(DateTime.Now.ToString() + text + "车牌结束");
				goto end_IL_006f;
				IL_0663:
				if (MainData.dnyybb)
				{
					Task.Factory.StartNew(delegate
					{
						string text17 = "禁止通行";
						if (IsRelease)
						{
							text17 = "允许通行";
							SpeechSynthesizer obj = new SpeechSynthesizer
							{
								Rate = 1,
								Volume = 100
							};
							text = vehicleNoInfoView.VehicleNo + vehicleNoInfoView.emissionStandard + vehicleNoInfoView.fuelType + text17;
							obj.Speak(text);
						}
						else
						{
							text17 = "禁止通行";
							SpeechSynthesizer obj2 = new SpeechSynthesizer
							{
								Rate = 1,
								Volume = 100
							};
							text = vehicleNoInfoView.VehicleNo + text17;
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
				LEDPlay(IsRelease, vehicleNoInfoView);
				if (this.carRecord != null)
				{
					this.carRecord(vehicleNoInfoView);
				}
				showVehicleNo(text + vehicleNoInfoView.TrafficStatus);
				if (IsRelease)
				{
					if (MainData.TXIsOpen)
					{
						CommonHelper.TXHGInOutUpLoad(tb_Channel.guid, vehicleNoInfoView.AddTime, vehicleNoInfoView.VehicleNo, tb_Channel.ChannelName, tb_Channel.ChannelType, vehicleNoInfoView.ImagePath);
					}
					CommonHelper.UploadThirdParty(vehicleNoInfoView);
				}
				goto IL_106a;
				IL_07d2:
				if (MainData.DJPT == "消纳场")
				{
					string text3 = "1";
					text3 = ((!(tb_Channel.ChannelType == "入口")) ? "2" : "1");
					string msg = "";
					if (CommonHelper.XNCVerify(text, empty, tb_Device.deviceId, text3, ref msg))
					{
						if (MainData.RecordSave(QYSmallSaveImage(tPicInfo), text2, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null))
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
					string text4 = "0";
					text4 = tb_Channel.ChannelPort;
					string msg2 = "";
					bool isUpload = false;
					if (!CommonHelper.GLVerify(text, vehicleNoInfoView.licenseColor, text4, ref msg2, ref vehicleNoInfoView))
					{
						IsRelease = false;
						isUpload = true;
						vehicleNoInfoView.ExeLog = msg2;
					}
					if (!MainData.RecordSave(QYSmallSaveImage(tPicInfo), text2, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView, isUpload))
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
					if (CommonHelper.TYVerify(text, empty, num, text2, ref msg3))
					{
						isJS = true;
						IsRelease = true;
					}
					else
					{
						IsRelease = false;
						vehicleNoInfoView.ExeLog = msg3;
					}
					if (!MainData.RecordSave(QYSmallSaveImage(tPicInfo), text2, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, null, isUpload: false, "", isJS))
					{
						vehicleNoInfoView.ExeLog = "保存失败";
						IsRelease = false;
					}
				}
				else if (MainData.DJPT == "中科九州")
				{
					string text5 = "A";
					text5 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
					string msg4 = "";
					string text6 = "";
					string text7 = "";
					if (CommonHelper.KangFengV1Verify(text, empty, tb_Channel.ChannelPort, text5, ref msg4, ref vehicleNoInfoView))
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
								vehicleNoInfoView.ExeLog = "未补台账，禁止通行";
								IsRelease = false;
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
						vehicleNoInfoView.ExeLog = msg4;
						if (vehicleNoInfoView.serialNum == null || string.IsNullOrWhiteSpace(vehicleNoInfoView.serialNum))
						{
							text7 = "禁止重复上传";
							goto IL_0663;
						}
						text7 = ((!MainData.barriergate_upload) ? "禁止上传" : "未上传");
					}
					if (!MainData.KaiFengRecordSave(QYSmallSaveImage(tPicInfo), text2, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text6, text7, ref vehicleNoInfoView))
					{
						vehicleNoInfoView.ExeLog = "保存失败";
						IsRelease = false;
					}
				}
				else if (MainData.DJPT == "安车")
				{
					string msg5 = "";
					string text8 = "";
					string text9 = "";
					if (CommonHelper.AnCheVerify(text, empty, ref msg5, ref vehicleNoInfoView, tb_Channel.ChannelPort))
					{
						text9 = "未上传";
						text8 = "摆杆通行";
					}
					else
					{
						text9 = "禁止上传";
						text8 = "未摆杆";
						IsRelease = false;
						vehicleNoInfoView.ExeLog = msg5;
					}
					string text10 = "A";
					text10 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
					vehicleNoInfoView.serialNum = MainData.ACEnterpriseID + tb_Channel.ChannelPort + text10 + vehicleNoInfoView.AddTime.ToString("yyMMddHHmmss");
					if (!MainData.KaiFengRecordSave(QYSmallSaveImage(tPicInfo), text2, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text8, text9, ref vehicleNoInfoView))
					{
						vehicleNoInfoView.ExeLog = "保存失败";
						IsRelease = false;
					}
				}
				else if (MainData.DJPT == "天地人车")
				{
					string msg6 = "";
					string text11 = "";
					string text12 = "";
					if (CommonHelper.tdrcCheVerify(text, empty, ref msg6, ref vehicleNoInfoView, tb_Channel.ChannelPort))
					{
						text12 = "未上传";
						text11 = "摆杆通行";
					}
					else
					{
						text12 = "禁止上传";
						text11 = "未摆杆";
						IsRelease = false;
						vehicleNoInfoView.ExeLog = msg6;
					}
					string text13 = "A";
					text13 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
					vehicleNoInfoView.serialNum = MainData.tdrcEnterpriseID + tb_Channel.ChannelPort + text13 + DateTime.Now.ToString("yyMMddHHmmss");
					if (!MainData.KaiFengRecordSave(QYSmallSaveImage(tPicInfo), text2, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text11, text12, ref vehicleNoInfoView))
					{
						vehicleNoInfoView.ExeLog = "保存失败";
						IsRelease = false;
					}
				}
				else if (MainData.DJPT == "信阳")
				{
					string msg7 = "";
					string text14 = "";
					string text15 = "";
					if (CommonHelper.xyCheVerify(text, empty, ref msg7, ref vehicleNoInfoView))
					{
						text15 = "未上传";
						text14 = "摆杆通行";
					}
					else
					{
						text15 = "禁止上传";
						text14 = "未摆杆";
						IsRelease = false;
						vehicleNoInfoView.ExeLog = msg7;
					}
					string text16 = "A";
					text16 = ((!(tb_Channel.ChannelType == "入口")) ? "B" : "A");
					vehicleNoInfoView.serialNum = MainData.xyOrgan + tb_Channel.ChannelPort + text16 + DateTime.Now.ToString("yyMMddHHmmss");
					if (!MainData.KaiFengRecordSave(QYSmallSaveImage(tPicInfo), text2, text, empty, tb_Channel.ChannelType, tb_Channel.id, tb_Device.id, tb_Channel.ChannelPort, vehicleNoInfoView.serialNum, text14, text15, ref vehicleNoInfoView))
					{
						vehicleNoInfoView.ExeLog = "保存失败";
						IsRelease = false;
					}
				}
				goto IL_0663;
				IL_0459:
				List<tb_car_info> list = new DataServerContext<tb_car_info>().Current.GetList((tb_car_info it) => it.car_no == text);
				if (list != null && list.Count > 0)
				{
					if (list[0].bz == "黑名单")
					{
						vehicleNoInfoView.TrafficStatus = "禁止通行";
						vehicleNoInfoView.ExeLog = "黑名单禁止通行";
						IsRelease = false;
					}
					else if (!(vehicleNoInfoView.AddTime >= list[0].startTime) || !(vehicleNoInfoView.AddTime <= list[0].endTime))
					{
						vehicleNoInfoView.TrafficStatus = "禁止通行";
						vehicleNoInfoView.ExeLog = "未在有效期以内";
					}
					else if (MainData.BMDSC)
					{
						goto IL_07d2;
					}
				}
				else
				{
					new DataServerContext<tb_vehicleInfoV2>().Current.GetModel((tb_vehicleInfoV2 it) => it.vehicleNo == text);
					if (MainData.SDZK)
					{
						isrg = true;
						goto IL_106a;
					}
					if (!MainData.LSCSN)
					{
						goto IL_07d2;
					}
					vehicleNoInfoView.ExeLog = "临时车禁止通行";
					IsRelease = false;
				}
				goto IL_0663;
				IL_106a:
				if (isrg)
				{
					isrg = false;
					OutSystem.AddOut(vehicleNoInfoView);
				}
				goto IL_063b;
				end_IL_006f:;
			}
			Thread.Sleep(30);
		}
		catch (Exception)
		{
		}
		return 0;
	}

	public void LEDPlay(bool IsRelease, VehicleNoInfoView vehicleNoInfoView)
	{
		if (!IsRelease)
		{
			vehicleNoInfoView.TrafficStatus = "禁止通行";
			Led(vehicleNoInfoView.VehicleNo, isOpen: false);
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
			else if (UserControlQY.Operation != null)
			{
				UserControlQY.Operation(Convert.ToInt32(tb_Device.OpeningMethod), 2, tb_Device.SnapId, tb_Channel, vehicleNoInfoView.VehicleNo);
			}
		}
		car_no = vehicleNoInfoView.VehicleNo;
		vehicleNoInfoView.TrafficStatus = "允许通行";
		vehicleNoInfoView.ExeLog = "允许通行";
		Led(vehicleNoInfoView.VehicleNo, isOpen: true);
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
		LogSave.QYLog(VehicleNo);
		if (tb_Device.motherboardType == "FK")
		{
			if (isOpen)
			{
				List<int> list = new List<int>();
				list.Add(40);
				byte[] array = BulkMaterialsForm.LED.LED.FangKongStandardVoiceByte(VehicleNo, list);
				string text = "";
				byte[] array2 = array;
				foreach (byte b in array2)
				{
					text += b.ToString("X2");
				}
				Send485(array);
			}
			else
			{
				List<int> list2 = new List<int>();
				list2.Add(43);
				byte[] data = BulkMaterialsForm.LED.LED.FangKongStandardVoiceByte(VehicleNo, list2);
				Send485(data);
			}
		}
		else if (tb_Device.motherboardType == "KF")
		{
			if (isOpen)
			{
				byte[] data2 = BulkMaterialsForm.LED.LED.KeFa_SoundPlay(0, VehicleNo + "欢迎光临");
				Send485(data2);
				Thread.Sleep(50);
				data2 = BulkMaterialsForm.LED.LED.KeFa_LedLampLan(0);
				Send485(data2);
				Thread.Sleep(50);
				data2 = BulkMaterialsForm.LED.LED.KeFa_LedLampLv(0);
				Send485(data2);
			}
			else
			{
				byte[] data3 = BulkMaterialsForm.LED.LED.KeFa_SoundPlay(0, VehicleNo + "禁止通行");
				Send485(data3);
			}
		}
	}

	public void Send485(byte[] data)
	{
		QianYe_SDK.T_RS485Data ptRS485Data = new QianYe_SDK.T_RS485Data
		{
			data = new byte[1024]
		};
		Buffer.BlockCopy(data, 0, ptRS485Data.data, 0, data.Length);
		ptRS485Data.dataLen = (ushort)ptRS485Data.data.Length;
		QianYe_SDK.Net_SendRS485Data(_logHandle, ref ptRS485Data);
	}

	public string QYSmallSaveImage(QianYe_SDK.T_PicInfo tPicInfo)
	{
		string text = "";
		string text2 = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
		if (tPicInfo.ptVehiclePicBuff != IntPtr.Zero && tPicInfo.uiVehiclePicLen != 0)
		{
			byte[] array = new byte[tPicInfo.uiVehiclePicLen];
			Marshal.Copy(tPicInfo.ptVehiclePicBuff, array, 0, (int)tPicInfo.uiVehiclePicLen);
			text = MainData.strImageDir + "\\" + text2 + ".jpg";
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
			DateTime now = DateTime.Now;
			string text = string.Format("{0}\\{1}.jpg", MainData.strImageDir, now.ToLocalTime().ToString("yyyyMMddHHmmssfff"));
			if (QianYe_SDK.Net_SaveImageToJpeg(_logHandle, text) == 0)
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
		QianYe_SDK.Net_StopVideo(_logHandle);
		QianYe_SDK.Net_DisConnCamera(_logHandle);
		QianYe_SDK.Net_DelCamera(_logHandle);
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

	private void button1_Click(object sender, EventArgs e)
	{
		QianYe_SDK.T_FrameInfo ptImageSnap = default(QianYe_SDK.T_FrameInfo);
		QianYe_SDK.Net_ImageSnap(_logHandle, ref ptImageSnap);
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
							tb_exceptional2.gateName = tb_Device.CameraName;
							DataServerContext<tb_exceptional> dataServerContext = new DataServerContext<tb_exceptional>();
							int value = dataServerContext.Current.AddReturnIdentity(tb_exceptional2);
							if (value > 0)
							{
								tb_videotape zpjList = MainData.tb_Videotapes.FirstOrDefault((tb_videotape it) => it.id == sId);
								Task.Factory.StartNew(delegate
								{
									LogSave.DHLog(DateTime.Now.ToString() + "MainData.jhjtype=" + MainData.jhjtype);
									if (MainData.jhjtype == "hk")
									{
										LogSave.HKLog(DateTime.Now.ToString() + "HK开始录像");
										DateTime start = DateTime.Now.AddSeconds(-30.0);
										DateTime end = DateTime.Now.AddSeconds(30.0);
										string text = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
										string sVideoFileName = MainData.strImageDir + "\\" + text + ".mp4";
										Thread.Sleep(120000);
										MainData.hKLXJ.Add(start, end, zpjList.ChannelID, value, sVideoFileName);
										LogSave.HKLog(DateTime.Now.ToString() + "HK结束录像");
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
							tb_videotape zpjList = MainData.tb_Videotapes.FirstOrDefault((tb_videotape it) => it.id == tb_Device.SnapId);
							Task.Factory.StartNew(delegate
							{
								if (MainData.jhjtype == "hk")
								{
									DateTime start = DateTime.Now.AddSeconds(-60.0);
									DateTime end = DateTime.Now.AddSeconds(60.0);
									string text = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
									string sVideoFileName = MainData.strImageDir + "\\" + text + ".mp4";
									_ = DateTime.Now;
									Thread.Sleep(120000);
									MainData.hKLXJ.Add(start, end, Convert.ToInt32(zpjList.ChannelID), value, sVideoFileName);
								}
								else
								{
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
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.btnClose = new System.Windows.Forms.Button();
		this.btnOpen = new System.Windows.Forms.Button();
		this.lalCarNo = new System.Windows.Forms.Label();
		this.LedSetTime = new System.Windows.Forms.Button();
		this.gboxheader = new System.Windows.Forms.GroupBox();
		this.pboxQY = new System.Windows.Forms.PictureBox();
		this.timer2 = new System.Windows.Forms.Timer();
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
		this.tableLayoutPanel1.Size = new System.Drawing.Size(729, 418);
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
		this.tableLayoutPanel2.Controls.Add(this.btnClose, 2, 0);
		this.tableLayoutPanel2.Controls.Add(this.btnOpen, 1, 0);
		this.tableLayoutPanel2.Controls.Add(this.lalCarNo, 4, 0);
		this.tableLayoutPanel2.Controls.Add(this.LedSetTime, 3, 0);
		this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 381);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 1;
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel2.Size = new System.Drawing.Size(723, 34);
		this.tableLayoutPanel2.TabIndex = 0;
		this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
		this.btnClose.Location = new System.Drawing.Point(243, 3);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(114, 28);
		this.btnClose.TabIndex = 1;
		this.btnClose.Text = "关闸";
		this.btnClose.UseVisualStyleBackColor = true;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.btnOpen.Dock = System.Windows.Forms.DockStyle.Fill;
		this.btnOpen.Location = new System.Drawing.Point(123, 3);
		this.btnOpen.Name = "btnOpen";
		this.btnOpen.Size = new System.Drawing.Size(114, 28);
		this.btnOpen.TabIndex = 0;
		this.btnOpen.Text = "开闸";
		this.btnOpen.UseVisualStyleBackColor = true;
		this.btnOpen.Click += new System.EventHandler(btnOpen_Click);
		this.lalCarNo.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.lalCarNo.AutoSize = true;
		this.lalCarNo.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.lalCarNo.Location = new System.Drawing.Point(560, 6);
		this.lalCarNo.Name = "lalCarNo";
		this.lalCarNo.Size = new System.Drawing.Size(82, 21);
		this.lalCarNo.TabIndex = 2;
		this.lalCarNo.Text = "豫A00000";
		this.LedSetTime.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LedSetTime.Location = new System.Drawing.Point(363, 3);
		this.LedSetTime.Name = "LedSetTime";
		this.LedSetTime.Size = new System.Drawing.Size(114, 28);
		this.LedSetTime.TabIndex = 6;
		this.LedSetTime.Text = "LED同步时间";
		this.LedSetTime.UseVisualStyleBackColor = true;
		this.LedSetTime.Click += new System.EventHandler(LedSetTime_Click);
		this.gboxheader.Controls.Add(this.pboxQY);
		this.gboxheader.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gboxheader.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.gboxheader.Location = new System.Drawing.Point(3, 3);
		this.gboxheader.Name = "gboxheader";
		this.gboxheader.Size = new System.Drawing.Size(723, 372);
		this.gboxheader.TabIndex = 2;
		this.gboxheader.TabStop = false;
		this.pboxQY.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pboxQY.Location = new System.Drawing.Point(3, 25);
		this.pboxQY.Name = "pboxQY";
		this.pboxQY.Size = new System.Drawing.Size(717, 344);
		this.pboxQY.TabIndex = 1;
		this.pboxQY.TabStop = false;
		this.timer2.Enabled = true;
		this.timer2.Interval = 3600000;
		this.timer2.Tick += new System.EventHandler(timer2_Tick);
		this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.button1.Location = new System.Drawing.Point(3, 3);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(114, 28);
		this.button1.TabIndex = 7;
		this.button1.Text = "抓怕";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.tableLayoutPanel1);
		base.Name = "UserControlQY";
		base.Size = new System.Drawing.Size(729, 418);
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		this.gboxheader.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pboxQY).EndInit();
		base.ResumeLayout(false);
	}
}
