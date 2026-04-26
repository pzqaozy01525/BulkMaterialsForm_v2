// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Help
// Type: BulkMaterialsForm.Help.MainData

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using BulkMaterialsForm.DH;
using BulkMaterialsForm.Manager;
using BulkMaterialsForm.Model;
using BulkMaterialsForm.Model.View;
using BulkMaterialsForm.SDK;
using BulkMaterialsForm.SDK.DH;

namespace BulkMaterialsForm.Help;

public class MainData
{
	public delegate int video_QianYe_FGetImageCB2Delegate(int tHandle, uint uiImageId, ref QianYe_SDK.T_ImageUserInfo2 tImageInfo, ref QianYe_SDK.T_PicInfo tPicInfo);

	public delegate int video_QianYe_FGetImageIODelegate(int tHandle, byte ucType, IntPtr ptMessage, IntPtr pUserData);

	public delegate int video_ZhenShi_VZLPRC_PLATE_INFO_CALLBACK(int handle, IntPtr pUserData, IntPtr pResult, uint uNumPlates, VzClientSDK.VZ_LPRC_RESULT_TYPE eResultType, IntPtr pImgFull, IntPtr pImgPlateClip);

	public delegate void video_VZLPRC_GPIO_RECV_CALLBACK(int handle, int nGPIOId, int nVal, IntPtr pUserData);

	public delegate void SDK_OnPlate(IntPtr pvParam, [In][MarshalAs(UnmanagedType.LPStr)] string pcIP, [In][MarshalAs(UnmanagedType.LPStr)] string pcNumber, [In][MarshalAs(UnmanagedType.LPStr)] string pcColor, IntPtr pcPicData, uint u32PicLen, IntPtr pcCloseUpPicData, uint u32CloseUpPicLen, short nSpeed, short nVehicleType, short nReserved1, short nReserved2, float fPlateConfidence, uint u32VehicleColor, uint u32PlateType, uint u32VehicleDir, uint u32AlarmType, uint u32SerialNum, uint uCapTime, uint u32ResultHigh, uint u32ResultLow);

	public delegate void SDK_OnIOEvent(IntPtr pvParam, [In][MarshalAs(UnmanagedType.LPStr)] string pcIP, uint u32EventType, uint u32IOData1, uint u32IOData2, uint u32IOData3, uint u32IOData4);

	public delegate bool video_HaiKang_MsgCallback_V31(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser);

	public delegate void CameraSnap(cmdModel msg);

	public static string Spath;

	public static bool IsInit;

	public static string server;

	public static string database;

	public static string uid;

	public static string pwd;

	private static DateTime? _expTime;

	public static bool IsBecomeDue;

	public static string ServerIP;

	public static bool IOSwitch;

	public static bool YZTZ;

	public static bool gsxxyc;

	public static bool sdtgqy;

	public static bool InitGuo4;

	public static bool Guo4;

	public static bool InitGuo5;

	public static bool Guo5;

	public static bool InitGuo6;

	public static bool Guo6;

	public static string strImageDir;

	public static string YXMS;

	public static string M_str_sqlcon;

	public static bool LSCSN;

	public static bool BMDSC;

	public static bool SDZK;

	public static string DJPT;

	public static string XMMC;

	public static string isInst;

	public static bool barriergate_upload;

	public static List<HKOperate> ListVideo;

	public static List<DHOperate> ListdhVideo;

	public static ExchangeBoard exchangeBoard;

	public static string jhjIp;

	public static string jhjzh;

	public static string jhjmm;

	public static string jhjtype;

	public static HKLXJ hKLXJ;

	public static int ldiody;

	public static bool bxtxhw;

	public static bool scfwq;

	public static string khdId;

	public static string bstIP;

	public static string bstPort;

	public static bool dnyybb;

	public static bool kqsplx;

	public static bool kqykjbd;

	public static string DPLX;

	public static int gkpf;

	public static string disposalsiteId;

	public static string XNCKEY;

	public static string XNCSecret;

	public static string XNCServerUrl = "http://42.236.61.123:8802";

	public static string XNCPoleEndpoint = "/translator/api/disposalInOutVehicle/pole";

	public static string XNCInOutServerUrl = "http://42.236.61.105:8686";

	public static string XNCInOutEndpoint = "/approval/county/inoutDevice";

	public static string WYYServerUrl = "http://fskbtz.weiyouyuan.com.cn";

	public static string companyCodeV1;

	public static string companynumV1;

	public static string companypasswordV1;

	public static string KFV1Token;

	public static DateTime KFV1ServerTime;

	public static string KFV1ServerIP;

	public static string DBDJ;

	public static string DBServer;

	public static string GLEnterPort;

	public static string GLExitPort;

	public static string GLcompanyCode;

	public static string localhostIP;

	public static string cdpfType;

	public static string cdpfUrl;

	public static string cdpfIISImageUrl;

	public static string cdpfQYId;

	public static string cdpfGTBM;

	public static string cdpfXSZUrl;

	public static string GLIISUrl;

	public static string GLcompanyName;

	public static string GLcontrolRunTime;

	public static string GLcontrolEndTime;

	public static string GLcontrolStrategy;

	public static string GLresponseLevel;

	public static string GLcontrolLevel;

	public static string GLcontrolUpdateTime;

	public static List<tb_videotape> tb_Videotapes;

	public static string TYcode;

	public static string TYDeviceId;

	public static int TYEnterChannel;

	public static int TYExitChannel;

	public static int Sdk_QianYe_init;

	public static Hashtable HtQianYeCallBackDel;

	private static object QianYeCallBack_Lock;

	public static Hashtable HtQianYeCallBackIO;

	private static object QianYeCallBack_IO;

	public static string xyOrgan;

	public static string xyUsername;

	public static string xyPassword;

	public static string xyToken;

	public static string xyUrl;

	public static DateTime xyServerTime;

	public static string ACorgan;

	public static string ACusername;

	public static string ACpassword;

	public static string ACEnterpriseID;

	public static string ACToken;

	public static DateTime ACServerTime;

	public static string ACServerUrl;

	public static string TXServer;

	public static string TXappKey;

	public static string TXappSecret;

	public static bool TXIsOpen;

	public static string TXToken;

	public static string tdrcOrgan;

	public static string tdrcUsername;

	public static string tdrcPassword;

	public static string tdrcToken;

	public static string tdrcUrl;

	public static string tdrcEnterpriseID;

	public static DateTime tdrcServerTime;

	public static VzClientSDK.VZLPRC_PLATE_INFO_CALLBACK m_PlateResultCB;

	public static int Sdk_ZhenShi_init;

	public static Hashtable HtZhenShiCallBackDel;

	private static object ZhenShiCallBack_Lock;

	public static Hashtable HtZhenShiCallBackIO;

	private static object ZhenShiCallBackIO_Lock;

	public static VzClientSDK.VZLPRC_GPIO_RECV_CALLBACK m_gpio_recvCB;

	public static int Sdk_HuaXia_init;

	public static Hashtable HtHuaXiaCallBackDel;

	public static Hashtable HtHuaXiaCallBackDelIO;

	private static object HuaXiaCallBack_LockIO;

	public static string DHUserName;

	public static string DHPassword;

	public static int Sdk_DaHua_init;

	public static string HKUserName;

	public static string HKPassword;

	private static CHCNetSDK.MSGCallBack_V31 m_falarmData_V31;

	public static bool Sdk_HaiKang_init;

	private static object HaiKangCallBack_Lock;

	public static Hashtable HtHaiKangCallBackDel;

	private static byte[] KeFa_CRCHi;

	private static byte[] KeFa_CRCLo;

	public static DateTime ExpTime
	{
		get
		{
			if (!_expTime.HasValue)
			{
				_expTime = ReadDateTime("窗体框架配制", "系统到期时间", DateTime.Now.AddDays(365.0));
				if (_expTime == default(DateTime) || _expTime == DateTime.Now.AddDays(365.0))
				{
					_expTime = DateTime.Now.AddDays(365.0);
					SaveExpTime(_expTime ?? DateTime.Now.AddDays(365.0));
				}
			}
			return _expTime ?? DateTime.Now.AddDays(365.0);
		}
		set
		{
			_expTime = value;
		}
	}

	public static event CameraSnap cameraSnap;

	static MainData()
	{
		Spath = Application.StartupPath + "\\formRKpz.ini";
		IsInit = false;
		server = New_IniFile.ReadContentValue("数据库连接", "server", Spath);
		database = New_IniFile.ReadContentValue("数据库连接", "database", Spath);
		uid = New_IniFile.ReadContentValue("数据库连接", "uid", Spath);
		pwd = New_IniFile.ReadContentValue("数据库连接", "pwd", Spath);
		IsBecomeDue = false;
		ServerIP = New_IniFile.ReadContentValue("窗体框架配制", "ServerIP", Spath);
		IOSwitch = New_IniFile.ReadBoolean("窗体框架配制", "IO开关", Spath);
		YZTZ = New_IniFile.ReadBoolean("窗体框架配制", "验证台账", Spath);
		gsxxyc = New_IniFile.ReadBoolean("窗体框架配制", "公司信息隐藏", Spath);
		sdtgqy = New_IniFile.ReadBoolean("窗体框架配制", "手动抬杆是否启用", Spath);
		InitGuo4 = false;
		Guo4 = false;
		InitGuo5 = false;
		Guo5 = false;
		InitGuo6 = false;
		Guo6 = false;
		strImageDir = New_IniFile.ReadContentValue("窗体框架配制", "图片保存路径", Spath);
		YXMS = New_IniFile.ReadContentValue("窗体框架配制", "运行模式", Spath);
		M_str_sqlcon = "server=" + server + ";database=" + database + ";uid=" + uid + ";pwd=" + pwd;
		LSCSN = New_IniFile.ReadBoolean("窗体框架配制", "临时车使能", Spath);
		BMDSC = New_IniFile.ReadBoolean("窗体框架配制", "白名单验证平台", Spath);
		SDZK = New_IniFile.ReadBoolean("窗体框架配制", "手动开闸", Spath);
		DJPT = New_IniFile.ReadContentValue("窗体框架配制", "platFormType", Spath);
		XMMC = New_IniFile.ReadContentValue("窗体框架配制", "项目名称", Spath);
		isInst = New_IniFile.ReadContentValue("窗体框架配制", "isInst", Spath);
		barriergate_upload = New_IniFile.ReadBoolean("窗体框架配制", "barriergate_upload", Spath);
		ListVideo = new List<HKOperate>();
		ListdhVideo = new List<DHOperate>();
		exchangeBoard = new ExchangeBoard();
		jhjIp = New_IniFile.ReadContentValue("窗体框架配制", "录像机IP", Spath);
		jhjzh = New_IniFile.ReadContentValue("窗体框架配制", "录像机账号", Spath);
		jhjmm = New_IniFile.ReadContentValue("窗体框架配制", "录像机密码", Spath);
		jhjtype = New_IniFile.ReadContentValue("窗体框架配制", "录像机类型", Spath);
		hKLXJ = new HKLXJ();
		ldiody = New_IniFile.ReadInt("窗体框架配制", "联动IO定义", Spath);
		bxtxhw = New_IniFile.ReadBoolean("窗体框架配制", "必须填写货物开闸", Spath);
		scfwq = New_IniFile.ReadBoolean("窗体框架配制", "上传服务器", Spath);
		khdId = New_IniFile.ReadContentValue("窗体框架配制", "客户端ID", Spath);
		bstIP = New_IniFile.ReadContentValue("窗体框架配制", "bstIP", Spath);
		bstPort = New_IniFile.ReadContentValue("窗体框架配制", "bstPort", Spath);
		dnyybb = New_IniFile.ReadBoolean("窗体框架配制", "开启电脑语音播报", Spath);
		kqsplx = New_IniFile.ReadBoolean("窗体框架配制", "开启视频录像", Spath);
		kqykjbd = New_IniFile.ReadBoolean("窗体框架配制", "开启遥控警报灯", Spath);
		DPLX = New_IniFile.ReadContentValue("窗体框架配制", "大屏类型", Spath);
		gkpf = 0;
		disposalsiteId = New_IniFile.ReadContentValue("窗体框架配制", "disposalsiteId", Spath);
		XNCKEY = New_IniFile.ReadContentValue("窗体框架配制", "key", Spath);
		XNCSecret = New_IniFile.ReadContentValue("窗体框架配制", "secret", Spath);
		companyCodeV1 = New_IniFile.ReadContentValue("窗体框架配制", "开封V1companyCode", Spath);
		companynumV1 = New_IniFile.ReadContentValue("窗体框架配制", "开封V1companynum", Spath);
		companypasswordV1 = New_IniFile.ReadContentValue("窗体框架配制", "开封V1companypassword", Spath);
		KFV1Token = "";
		KFV1ServerTime = DateTime.Now;
		KFV1ServerIP = New_IniFile.ReadContentValue("窗体框架配制", "开封V1ServerIP", Spath);
		DBDJ = New_IniFile.ReadContentValue("窗体框架配制", "对接地磅", Spath);
		DBServer = New_IniFile.ReadContentValue("窗体框架配制", "地磅数据库地址", Spath);
		GLEnterPort = New_IniFile.ReadContentValue("窗体框架配制", "高凌进口端口", Spath);
		GLExitPort = New_IniFile.ReadContentValue("窗体框架配制", "高凌出口端口", Spath);
		GLcompanyCode = New_IniFile.ReadContentValue("窗体框架配制", "高凌企业编号", Spath);
		localhostIP = New_IniFile.ReadContentValue("窗体框架配制", "本机IP", Spath);
		cdpfType = New_IniFile.ReadContentValue("窗体框架配制", "超低排放接口平台", Spath);
		cdpfUrl = New_IniFile.ReadContentValue("窗体框架配制", "超低排放接口地址", Spath);
		cdpfIISImageUrl = New_IniFile.ReadContentValue("窗体框架配制", "超低排放IIS图片地址", Spath);
		cdpfQYId = New_IniFile.ReadContentValue("窗体框架配制", "企业ID", Spath);
		cdpfGTBM = New_IniFile.ReadContentValue("窗体框架配制", "岗亭编码", Spath);
		cdpfXSZUrl = New_IniFile.ReadContentValue("窗体框架配制", "行驶证服务地址", Spath);
		GLIISUrl = New_IniFile.ReadContentValue("窗体框架配制", "高陵IIS地址", Spath);
		GLcompanyName = New_IniFile.ReadContentValue("窗体框架配制", "高陵企业名称", Spath);
		GLcontrolRunTime = New_IniFile.ReadContentValue("窗体框架配制", "高陵管控开始时间", Spath);
		GLcontrolEndTime = New_IniFile.ReadContentValue("窗体框架配制", "高陵管控结束时间", Spath);
		GLcontrolStrategy = New_IniFile.ReadContentValue("窗体框架配制", "高陵管控策略", Spath);
		GLresponseLevel = New_IniFile.ReadContentValue("窗体框架配制", "高陵响应等级", Spath);
		GLcontrolLevel = New_IniFile.ReadContentValue("窗体框架配制", "高陵预警等级", Spath);
		GLcontrolUpdateTime = New_IniFile.ReadContentValue("窗体框架配制", "高陵管控更新时间", Spath);
		TYcode = New_IniFile.ReadContentValue("窗体框架配制", "腾跃信用代码", Spath);
		TYDeviceId = New_IniFile.ReadContentValue("窗体框架配制", "设备ID", Spath);
		TYEnterChannel = New_IniFile.ReadInt("窗体框架配制", "进口通道ID", Spath);
		TYExitChannel = New_IniFile.ReadInt("窗体框架配制", "出口通道ID", Spath);
		Sdk_QianYe_init = -1;
		HtQianYeCallBackDel = new Hashtable();
		QianYeCallBack_Lock = new object();
		HtQianYeCallBackIO = new Hashtable();
		QianYeCallBack_IO = new object();
		xyOrgan = New_IniFile.ReadContentValue("窗体框架配制", "信阳企业编码", Spath);
		xyUsername = New_IniFile.ReadContentValue("窗体框架配制", "信阳账号", Spath);
		xyPassword = New_IniFile.ReadContentValue("窗体框架配制", "信阳密码", Spath);
		xyToken = "";
		xyUrl = New_IniFile.ReadContentValue("窗体框架配制", "信阳服务地址", Spath);
		xyServerTime = DateTime.Now;
		ACorgan = New_IniFile.ReadContentValue("窗体框架配制", "安车编码标识", Spath);
		ACusername = New_IniFile.ReadContentValue("窗体框架配制", "安车账号", Spath);
		ACpassword = New_IniFile.ReadContentValue("窗体框架配制", "安车密码", Spath);
		ACEnterpriseID = New_IniFile.ReadContentValue("窗体框架配制", "安车排污许可证编号", Spath);
		ACToken = "";
		ACServerTime = DateTime.Now;
		ACServerUrl = New_IniFile.ReadContentValue("窗体框架配制", "安车服务地址", Spath);
		TXServer = New_IniFile.ReadContentValue("窗体框架配制", "图讯化工园区服务地址", Spath);
		TXappKey = New_IniFile.ReadContentValue("窗体框架配制", "图讯化工园区appKey", Spath);
		TXappSecret = New_IniFile.ReadContentValue("窗体框架配制", "图讯化工园区appSecret", Spath);
		TXIsOpen = New_IniFile.ReadBoolean("窗体框架配制", "图讯化工园区是否开启", Spath);
		TXToken = "";
		tdrcOrgan = New_IniFile.ReadContentValue("窗体框架配制", "天地人车企业编码", Spath);
		tdrcUsername = New_IniFile.ReadContentValue("窗体框架配制", "天地人车账号", Spath);
		tdrcPassword = New_IniFile.ReadContentValue("窗体框架配制", "天地人车密码", Spath);
		tdrcToken = "";
		tdrcUrl = New_IniFile.ReadContentValue("窗体框架配制", "天地人车服务地址", Spath);
		tdrcEnterpriseID = New_IniFile.ReadContentValue("窗体框架配制", "天地人车排污许可证编号", Spath);
		tdrcServerTime = DateTime.Now;
		m_PlateResultCB = null;
		Sdk_ZhenShi_init = -1;
		HtZhenShiCallBackDel = new Hashtable();
		ZhenShiCallBack_Lock = new object();
		HtZhenShiCallBackIO = new Hashtable();
		ZhenShiCallBackIO_Lock = new object();
		m_gpio_recvCB = null;
		Sdk_HuaXia_init = -1;
		HtHuaXiaCallBackDel = new Hashtable();
		HtHuaXiaCallBackDelIO = new Hashtable();
		HuaXiaCallBack_LockIO = new object();
		DHUserName = New_IniFile.ReadContentValue("窗体框架配制", "大华账号", Spath);
		DHPassword = New_IniFile.ReadContentValue("窗体框架配制", "大华密码", Spath);
		Sdk_DaHua_init = -1;
		HKUserName = New_IniFile.ReadContentValue("窗体框架配制", "海康账号", Spath);
		HKPassword = New_IniFile.ReadContentValue("窗体框架配制", "海康密码", Spath);
		m_falarmData_V31 = null;
		Sdk_HaiKang_init = false;
		HaiKangCallBack_Lock = new object();
		HtHaiKangCallBackDel = new Hashtable();
		KeFa_CRCHi = new byte[256]
		{
			0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
			128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
			0, 193, 129, 64, 0, 193, 129, 64, 1, 192,
			128, 65, 1, 192, 128, 65, 0, 193, 129, 64,
			0, 193, 129, 64, 1, 192, 128, 65, 0, 193,
			129, 64, 1, 192, 128, 65, 1, 192, 128, 65,
			0, 193, 129, 64, 1, 192, 128, 65, 0, 193,
			129, 64, 0, 193, 129, 64, 1, 192, 128, 65,
			0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
			128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
			1, 192, 128, 65, 1, 192, 128, 65, 0, 193,
			129, 64, 1, 192, 128, 65, 0, 193, 129, 64,
			0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
			128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
			1, 192, 128, 65, 0, 193, 129, 64, 1, 192,
			128, 65, 1, 192, 128, 65, 0, 193, 129, 64,
			0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
			128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
			0, 193, 129, 64, 0, 193, 129, 64, 1, 192,
			128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
			1, 192, 128, 65, 0, 193, 129, 64, 1, 192,
			128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
			1, 192, 128, 65, 1, 192, 128, 65, 0, 193,
			129, 64, 0, 193, 129, 64, 1, 192, 128, 65,
			0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
			128, 65, 0, 193, 129, 64
		};
		KeFa_CRCLo = new byte[256]
		{
			0, 192, 193, 1, 195, 3, 2, 194, 198, 6,
			7, 199, 5, 197, 196, 4, 204, 12, 13, 205,
			15, 207, 206, 14, 10, 202, 203, 11, 201, 9,
			8, 200, 216, 24, 25, 217, 27, 219, 218, 26,
			30, 222, 223, 31, 221, 29, 28, 220, 20, 212,
			213, 21, 215, 23, 22, 214, 210, 18, 19, 211,
			17, 209, 208, 16, 240, 48, 49, 241, 51, 243,
			242, 50, 54, 246, 247, 55, 245, 53, 52, 244,
			60, 252, 253, 61, 255, 63, 62, 254, 250, 58,
			59, 251, 57, 249, 248, 56, 40, 232, 233, 41,
			235, 43, 42, 234, 238, 46, 47, 239, 45, 237,
			236, 44, 228, 36, 37, 229, 39, 231, 230, 38,
			34, 226, 227, 35, 225, 33, 32, 224, 160, 96,
			97, 161, 99, 163, 162, 98, 102, 166, 167, 103,
			165, 101, 100, 164, 108, 172, 173, 109, 175, 111,
			110, 174, 170, 106, 107, 171, 105, 169, 168, 104,
			120, 184, 185, 121, 187, 123, 122, 186, 190, 126,
			127, 191, 125, 189, 188, 124, 180, 116, 117, 181,
			119, 183, 182, 118, 114, 178, 179, 115, 177, 113,
			112, 176, 80, 144, 145, 81, 147, 83, 82, 146,
			150, 86, 87, 151, 85, 149, 148, 84, 156, 92,
			93, 157, 95, 159, 158, 94, 90, 154, 155, 91,
			153, 89, 88, 152, 136, 72, 73, 137, 75, 139,
			138, 74, 78, 142, 143, 79, 141, 77, 76, 140,
			68, 132, 133, 69, 135, 71, 70, 134, 130, 66,
			67, 131, 65, 129, 128, 64
		};
		LogSave.SaveExeLog("[MainData] INI路径: " + Spath + ", ServerIP值: " + ServerIP);
	}

	public static void Init()
	{
		string text = New_IniFile.ReadContentValue("窗体框架配制", "管控排放", Spath);
		if (text == "")
		{
			gkpf = 0;
		}
		else
		{
			gkpf = Convert.ToInt32(text);
		}
		new DataServerContext<tb_car_info>().Current.GetList();
		new DataServerContext<tb_Channel>().Current.GetList();
		new DataServerContext<tb_CarRecord>().Current.GetList();
		new DataServerContext<tb_ChannelSeniorSet>().Current.GetList();
		new DataServerContext<tb_Device>().Current.GetList();
		new DataServerContext<tb_large_screen_detaile>().Current.GetList();
		new DataServerContext<tb_large_screen>().Current.GetList();
		new DataServerContext<tb_tempVehicle>().Current.GetList();
		new DataServerContext<tb_vehicleInfoV2>().Current.GetList();
		tb_Videotapes = new DataServerContext<tb_videotape>().Current.GetList();
	}

	public static void init_Sdk_QY()
	{
		try
		{
			if (Sdk_QianYe_init < 0)
			{
				Sdk_QianYe_init = QianYe_SDK.Net_Init();
			}
		}
		catch (Exception)
		{
		}
	}

	public static int video_QianYe_FGetImageCB2(int tHandle, uint uiImageId, ref QianYe_SDK.T_ImageUserInfo2 tImageInfo, ref QianYe_SDK.T_PicInfo tPicInfo)
	{
		try
		{
			video_QianYe_FGetImageCB2Delegate video_QianYe_FGetImageCB2Delegate2 = null;
			video_QianYe_FGetImageCB2Delegate2 = (video_QianYe_FGetImageCB2Delegate)HtQianYeCallBackDel[tHandle];
			if (video_QianYe_FGetImageCB2Delegate2 != null)
			{
				lock (QianYeCallBack_Lock)
				{
					video_QianYe_FGetImageCB2Delegate2(tHandle, uiImageId, ref tImageInfo, ref tPicInfo);
				}
			}
		}
		catch (Exception)
		{
			return -1;
		}
		Thread.Sleep(10);
		return 0;
	}

	public static int video_QianYe_FGetImageIO(int tHandle, byte ucType, IntPtr ptMessage, IntPtr pUserData)
	{
		try
		{
			video_QianYe_FGetImageIODelegate video_QianYe_FGetImageIODelegate2 = null;
			video_QianYe_FGetImageIODelegate2 = (video_QianYe_FGetImageIODelegate)HtQianYeCallBackIO[tHandle];
			if (video_QianYe_FGetImageIODelegate2 != null)
			{
				lock (QianYeCallBack_IO)
				{
					video_QianYe_FGetImageIODelegate2(tHandle, ucType, ptMessage, pUserData);
				}
			}
		}
		catch (Exception)
		{
			return -1;
		}
		Thread.Sleep(10);
		return 0;
	}

	public static void init_Sdk_ZS()
	{
		try
		{
			if (Sdk_ZhenShi_init < 0)
			{
				Sdk_ZhenShi_init = VzClientSDK.VzLPRClient_Setup();
				m_PlateResultCB = video_ZhenShi_CALLBACK;
				m_gpio_recvCB = video_ZhenShi_CALLBACKIO;
			}
		}
		catch (Exception)
		{
		}
	}

	public static int video_ZhenShi_CALLBACK(int handle, IntPtr pUserData, IntPtr pResult, uint uNumPlates, VzClientSDK.VZ_LPRC_RESULT_TYPE eResultType, IntPtr pImgFull, IntPtr pImgPlateClip)
	{
		try
		{
			video_ZhenShi_VZLPRC_PLATE_INFO_CALLBACK video_ZhenShi_VZLPRC_PLATE_INFO_CALLBACK2 = null;
			video_ZhenShi_VZLPRC_PLATE_INFO_CALLBACK2 = (video_ZhenShi_VZLPRC_PLATE_INFO_CALLBACK)HtZhenShiCallBackDel[handle];
			if (video_ZhenShi_VZLPRC_PLATE_INFO_CALLBACK2 != null && eResultType != VzClientSDK.VZ_LPRC_RESULT_TYPE.VZ_LPRC_RESULT_REALTIME)
			{
				lock (ZhenShiCallBack_Lock)
				{
					video_ZhenShi_VZLPRC_PLATE_INFO_CALLBACK2(handle, pUserData, pResult, uNumPlates, eResultType, pImgFull, pImgPlateClip);
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.ZSLog("臻识车牌识别异常: " + ex.Message);
			return 0;
		}
		Thread.Sleep(10);
		return 0;
	}

	public static void video_ZhenShi_CALLBACKIO(int handle, int nGPIOId, int nVal, IntPtr pUserData)
	{
		try
		{
			LogSave.ZSLog(DateTime.Now.ToString() + "IO触发");
			video_VZLPRC_GPIO_RECV_CALLBACK video_VZLPRC_GPIO_RECV_CALLBACK2 = null;
			video_VZLPRC_GPIO_RECV_CALLBACK2 = (video_VZLPRC_GPIO_RECV_CALLBACK)HtZhenShiCallBackIO[handle];
			if (video_VZLPRC_GPIO_RECV_CALLBACK2 != null)
			{
				lock (ZhenShiCallBackIO_Lock)
				{
					video_VZLPRC_GPIO_RECV_CALLBACK2(handle, nGPIOId, nVal, pUserData);
				}
			}
		}
		catch (Exception ex)
		{
			LogSave.ZSLog(DateTime.Now.ToString() + "臻识车牌识别异常" + ex.ToString());
			return;
		}
		Thread.Sleep(10);
	}

	public static void init_Sdk_HX()
	{
		try
		{
			if (Sdk_HuaXia_init < 0)
			{
				ipcsdk.ICE_IPCSDK_Init();
				Sdk_HuaXia_init = 1;
			}
		}
		catch (Exception)
		{
		}
	}

	public static void video_HuaXia_CALLBACK(IntPtr pvParam, [In][MarshalAs(UnmanagedType.LPStr)] string pcIP, [In][MarshalAs(UnmanagedType.LPStr)] string pcNumber, [In][MarshalAs(UnmanagedType.LPStr)] string pcColor, IntPtr pcPicData, uint u32PicLen, IntPtr pcCloseUpPicData, uint u32CloseUpPicLen, short nSpeed, short nVehicleType, short nReserved1, short nReserved2, float fPlateConfidence, uint u32VehicleColor, uint u32PlateType, uint u32VehicleDir, uint u32AlarmType, uint u32SerialNum, uint uCapTime, uint u32ResultHigh, uint u32ResultLow)
	{
		try
		{
			SDK_OnPlate sDK_OnPlate = null;
			sDK_OnPlate = (SDK_OnPlate)HtHuaXiaCallBackDel[pcIP];
			if (sDK_OnPlate != null)
			{
				lock (QianYeCallBack_Lock)
				{
					sDK_OnPlate(pvParam, pcIP, pcNumber, pcColor, pcPicData, u32PicLen, pcCloseUpPicData, u32CloseUpPicLen, nSpeed, nVehicleType, nReserved1, nReserved2, fPlateConfidence, u32VehicleColor, u32PlateType, u32VehicleDir, u32AlarmType, u32SerialNum, uCapTime, u32ResultHigh, u32ResultLow);
				}
			}
		}
		catch (Exception)
		{
			return;
		}
		Thread.Sleep(10);
	}

	public static void video_HuaXia_OnIOEvent(IntPtr pvParam, [In][MarshalAs(UnmanagedType.LPStr)] string pcIP, uint u32EventType, uint u32IOData1, uint u32IOData2, uint u32IOData3, uint u32IOData4)
	{
		try
		{
			SDK_OnIOEvent sDK_OnIOEvent = null;
			sDK_OnIOEvent = (SDK_OnIOEvent)HtHuaXiaCallBackDelIO[pcIP];
			if (sDK_OnIOEvent != null)
			{
				lock (HuaXiaCallBack_LockIO)
				{
					sDK_OnIOEvent(pvParam, pcIP, u32EventType, u32IOData1, u32IOData2, u32IOData3, u32IOData4);
				}
			}
		}
		catch (Exception)
		{
			return;
		}
		Thread.Sleep(10);
	}

	public static void init_Sdk_DH()
	{
		try
		{
			if (Sdk_DaHua_init < 0)
			{
				Sdk_DaHua_init = Convert.ToInt32(NETClient.Init(null, IntPtr.Zero, null));
				NETClient.SetAutoReconnect(null, IntPtr.Zero);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void init_Sdk_HaiKang()
	{
		try
		{
			if (!Sdk_HaiKang_init)
			{
				Sdk_HaiKang_init = CHCNetSDK.NET_DVR_Init();
				LogSave.HKLog("海康初始化:" + Sdk_HaiKang_init);
				if (m_falarmData_V31 == null)
				{
					m_falarmData_V31 = MsgCallback_V31;
				}
				CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V31(m_falarmData_V31, IntPtr.Zero);
			}
		}
		catch (Exception)
		{
		}
	}

	public static bool MsgCallback_V31(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
	{
		try
		{
			video_HaiKang_MsgCallback_V31 video_HaiKang_MsgCallback_V32 = null;
			video_HaiKang_MsgCallback_V32 = (video_HaiKang_MsgCallback_V31)HtHaiKangCallBackDel[pAlarmer.lUserID];
			if (video_HaiKang_MsgCallback_V32 != null)
			{
				lock (HaiKangCallBack_Lock)
				{
					video_HaiKang_MsgCallback_V32(lCommand, ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
				}
			}
		}
		catch (Exception)
		{
			return false;
		}
		Thread.Sleep(10);
		return true;
	}

	public static bool RecordSave(string car_image, string front_image, string szLprResult, string PlateColor, string out_type, int ChannelNo, int DeviceId, string ChannelPort, VehicleNoInfoView vehicleNoInfoView, bool isUpload = false, string serialNum = "", bool isJS = false)
	{
		tb_CarRecord tb_CarRecord2 = new tb_CarRecord();
		tb_CarRecord2.add_time = DateTime.Now;
		tb_CarRecord2.car_no = szLprResult;
		tb_CarRecord2.out_type = out_type;
		tb_CarRecord2.car_color = PlateColor;
		tb_CarRecord2.car_image = car_image;
		tb_CarRecord2.front_image = front_image;
		tb_CarRecord2.ChannelPort = ChannelPort;
		tb_CarRecord2.serialNum = serialNum;
		if (vehicleNoInfoView != null)
		{
			tb_CarRecord2.fuelType = vehicleNoInfoView.fuelType;
			tb_CarRecord2.emissionStandard = vehicleNoInfoView.emissionStandard;
		}
		DataServerContext<tb_CarRecord> dataServerContext = new DataServerContext<tb_CarRecord>();
		if (isUpload)
		{
			if (IOSwitch)
			{
				tb_CarRecord2.upload_status = "";
				tb_CarRecord2.gateSignal = "";
			}
			else
			{
				tb_CarRecord2.upload_status = "禁止上传";
				tb_CarRecord2.gateSignal = "未摆杆";
			}
			if (DJPT == "腾跃")
			{
				if (dataServerContext.Current.GetList((tb_CarRecord it) => it.add_time.AddMinutes(1.0) >= DateTime.Now).FirstOrDefault() != null)
				{
					LogSave.TYLog(DateTime.Now.ToString() + "upload_status:上传成功");
					tb_CarRecord2.upload_status = "上传成功";
				}
				else
				{
					tb_CarRecord2.upload_status = "腾跃2";
				}
			}
		}
		else if (DJPT == "高凌")
		{
			tb_CarRecord2.upload_status = "";
		}
		else if (DJPT == "腾跃")
		{
			if (isJS)
			{
				tb_CarRecord2.upload_status = "腾跃2";
			}
			else
			{
				tb_CarRecord2.upload_status = "禁止上传";
			}
		}
		else
		{
			tb_CarRecord2.upload_status = "";
		}
		int num = dataServerContext.Current.AddReturnIdentity(tb_CarRecord2);
		if (num > 0)
		{
			if (MainData.cameraSnap != null)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				cmdModel cmdModel2 = new cmdModel();
				cmdModel2.cmd = "抓拍";
				dictionary.Add("id", num);
				dictionary.Add("ChannelNo", ChannelNo);
				dictionary.Add("DeviceId", DeviceId);
				cmdModel2.data = dictionary;
				MainData.cameraSnap(cmdModel2);
			}
			return true;
		}
		return false;
	}

	public static bool KaiFengRecordSave(string car_image, string front_image, string szLprResult, string PlateColor, string out_type, int ChannelNo, int DeviceId, string ChannelPort, string serialNum, string gateSignal, string upload_status, ref VehicleNoInfoView vehicleNoInfoView)
	{
		tb_CarRecord tb_CarRecord2 = new tb_CarRecord();
		tb_CarRecord2.add_time = vehicleNoInfoView.AddTime;
		tb_CarRecord2.car_no = szLprResult;
		tb_CarRecord2.out_type = out_type;
		tb_CarRecord2.car_color = PlateColor;
		tb_CarRecord2.car_image = car_image;
		tb_CarRecord2.front_image = front_image;
		tb_CarRecord2.ChannelPort = ChannelPort;
		tb_CarRecord2.serialNum = vehicleNoInfoView.serialNum;
		tb_CarRecord2.gateSignal = gateSignal;
		tb_CarRecord2.upload_status = upload_status;
		tb_CarRecord2.fuelType = vehicleNoInfoView.fuelType;
		tb_CarRecord2.emissionStandard = vehicleNoInfoView.emissionStandard;
		int num = new DataServerContext<tb_CarRecord>().Current.AddReturnIdentity(tb_CarRecord2);
		if (num > 0)
		{
			vehicleNoInfoView.id = num;
			if (MainData.cameraSnap != null)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				cmdModel cmdModel2 = new cmdModel();
				cmdModel2.cmd = "抓拍";
				dictionary.Add("id", num);
				dictionary.Add("ChannelNo", ChannelNo);
				dictionary.Add("DeviceId", DeviceId);
				cmdModel2.data = dictionary;
				MainData.cameraSnap(cmdModel2);
			}
			return true;
		}
		return false;
	}

	public static byte[] KFSynTime()
	{
		try
		{
			byte[] array = new byte[16]
			{
				0, 100, 255, 255, 5, 8, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0
			};
			DateTime now = DateTime.Now;
			byte[] bytes = BitConverter.GetBytes((short)now.Year);
			array[6] = bytes[0];
			array[7] = bytes[1];
			array[8] = Convert.ToByte(now.Month);
			array[9] = Convert.ToByte(now.Day);
			if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
			{
				array[10] = 1;
			}
			else
			{
				array[10] = Convert.ToByte(now.DayOfWeek + 1);
			}
			array[11] = Convert.ToByte(now.Hour);
			array[12] = Convert.ToByte(now.Minute);
			array[13] = Convert.ToByte(now.Second);
			GetKaFaDataCRC(array, 2).CopyTo(array, 14);
			return array;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return null;
		}
	}

	public static byte[] FKSynTime()
	{
		try
		{
			string text = DateTime.Now.ToString("yyMMddHHmmss");
			string text2 = "";
			byte[] array = new byte[6];
			int num = 0;
			string text3 = text;
			for (int i = 0; i < text3.Length; i++)
			{
				text2 += text3[i];
				if (text2.Length == 2)
				{
					array[num] = Convert.ToByte(text2);
					num++;
					text2 = "";
				}
			}
			byte[] obj = new byte[14]
			{
				5, 100, 0, 16, 0, 6, 0, 0, 0, 0,
				0, 0, 0, 0
			};
			obj[6] = array[0];
			obj[7] = array[1];
			obj[8] = array[2];
			obj[9] = array[3];
			obj[10] = array[4];
			obj[11] = array[5];
			byte[] array2 = CRC16(obj);
			byte[] obj2 = new byte[17]
			{
				170, 85, 5, 100, 0, 16, 0, 6, 0, 0,
				0, 0, 0, 0, 0, 0, 175
			};
			obj2[8] = array[0];
			obj2[9] = array[1];
			obj2[10] = array[2];
			obj2[11] = array[3];
			obj2[12] = array[4];
			obj2[13] = array[5];
			obj2[14] = array2[1];
			obj2[15] = array2[0];
			return obj2;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return null;
		}
	}

	public static byte[] CRC16(byte[] data)
	{
		int num = 65535;
		for (int i = 0; i < data.Length; i++)
		{
			num ^= data[i];
			for (int j = 0; j < 8; j++)
			{
				int num2 = num & 1;
				num >>= 1;
				num &= 0x7FFF;
				if (num2 == 1)
				{
					num ^= 0xA001;
				}
				num &= 0xFFFF;
			}
		}
		byte[] array = new byte[2];
		array[1] = (byte)((num >> 8) & 0xFF);
		array[0] = (byte)(num & 0xFF);
		return array;
	}

	private static byte[] GetKaFaDataCRC(byte[] CRCDataByte, byte UnSumNum)
	{
		byte[] array = new byte[CRCDataByte.Length - UnSumNum];
		Array.Copy(CRCDataByte, 0, array, 0, CRCDataByte.Length - UnSumNum);
		return GetKeFa_CRC16(array, array.Length);
	}

	public static byte[] GetKeFa_CRC16(byte[] puchMsg, int usDataLen)
	{
		byte b = byte.MaxValue;
		byte b2 = byte.MaxValue;
		for (int i = 0; i < usDataLen; i++)
		{
			int num = b ^ puchMsg[i];
			b = (byte)(b2 ^ KeFa_CRCHi[num]);
			b2 = KeFa_CRCLo[num];
		}
		return BitConverter.GetBytes((ushort)((b2 << 8) | b));
	}

	public static void WriteString(string section, string key, string value)
	{
		try
		{
			string value2 = value ?? string.Empty;
			New_IniFile.WriteContentValue(section, key, value2, Spath);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("更新配置失败: " + section + "." + key + " -> " + value + " (" + ex.Message + ")");
		}
	}

	public static void SaveExpTime(DateTime expTime)
	{
		try
		{
			_expTime = expTime;
			New_IniFile.WriteContentValue("窗体框架配制", "系统到期时间", expTime.ToString("yyyy-MM-dd HH:mm:ss"), Spath);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("保存系统到期时间失败: " + ex.Message);
		}
	}

	public static void SaveActivationTime(DateTime activationTime)
	{
		try
		{
			New_IniFile.WriteContentValue("窗体框架配制", "系统激活时间", activationTime.ToString("yyyy-MM-dd HH:mm:ss"), Spath);
		}
		catch (Exception ex)
		{
			LogSave.SaveExeLog("保存系统激活时间失败: " + ex.Message);
		}
	}

	public static DateTime GetActivationTime()
	{
		return ReadDateTime("窗体框架配制", "系统激活时间", DateTime.Now);
	}

	public static void RefreshExpTime()
	{
		_expTime = null;
		_ = ExpTime;
	}

	private static DateTime ReadDateTime(string section, string key, DateTime defaultValue)
	{
		try
		{
			string text = New_IniFile.ReadContentValue(section, key, Spath);
			if (string.IsNullOrWhiteSpace(text))
			{
				return defaultValue;
			}
			if (DateTime.TryParse(text.Trim(), out var result))
			{
				return result;
			}
			return defaultValue;
		}
		catch
		{
			return defaultValue;
		}
	}
}
