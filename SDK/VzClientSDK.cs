using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.SDK;

public class VzClientSDK
{
	public enum VZ_InputType : uint
	{
		nWhiteList,
		nNotWhiteList,
		nNoLicence,
		nBlackList,
		nExtIoctl1,
		nExtIoctl2,
		nExtIoctl3
	}

	public struct VZ_LPRC_OutputConfig
	{
		public int switchout1;

		public int switchout2;

		public int switchout3;

		public int switchout4;

		public int levelout1;

		public int levelout2;

		public int rs485out1;

		public int rs485out2;

		private VZ_InputType eInputType;
	}

	public struct VZ_OutputConfigInfo
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
		public VZ_LPRC_OutputConfig[] oConfigInfo;
	}

	public struct VZ_EMS_INFO
	{
		public uint uId;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string sName;
	}

	public struct VZ_LPRC_ACTIVE_ENCRYPT
	{
		public uint uActiveID;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public VZ_EMS_INFO[] oEncrpty;

		public uint uSize;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string signature;
	}

	public struct VZ_SERIAL_PARAMETER
	{
		public uint uBaudRate;

		public uint uParity;

		public uint uDataBits;

		public uint uStopBit;
	}

	public enum VZ_LPRC_CALLBACK_TYPE : uint
	{
		VZ_LPRC_CALLBACK_COMMON_NOTIFY,
		VZ_LPRC_CALLBACK_PLATE_STR,
		VZ_LRPC_CALLBACK_FULL_IMAGE,
		VZ_LPRC_CALLBACK_CLIP_IMAGE,
		VZ_LPRC_CALLBACK_PLATE_RESULT,
		VZ_LPRC_CALLBACK_PLATE_RESULT_STABLE,
		VZ_LPRC_CALLBACK_PLATE_RESULT_TRIGGER,
		VZ_LPRC_CALLBACK_VIDEO
	}

	public enum VZ_LPRC_COMMON_NOTIFY : uint
	{
		VZ_LPRC_NO_ERR,
		VZ_LPRC_ACCESS_DENIED,
		VZ_LPRC_NETWORK_ERR
	}

	public enum VZ_LPRC_RESULT_TYPE : uint
	{
		VZ_LPRC_RESULT_REALTIME,
		VZ_LPRC_RESULT_STABLE,
		VZ_LPRC_RESULT_FORCE_TRIGGER,
		VZ_LPRC_RESULT_IO_TRIGGER,
		VZ_LPRC_RESULT_VLOOP_TRIGGER,
		VZ_LPRC_RESULT_MULTI_TRIGGER,
		VZ_LPRC_RESULT_TYPE_NUM
	}

	public struct VZ_LPRC_VERTEX
	{
		public uint X_1000;

		public uint Y_1000;
	}

	public struct VZ_LPRC_ROI_EX
	{
		public byte byRes1;

		public byte byEnable;

		public byte byDraw;

		public byte byRes2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
		public byte[] byRes3;

		private uint uNumVertex;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public VZ_LPRC_VERTEX[] struVertex;
	}

	public struct VZ_LPRC_VIRTUAL_LOOP
	{
		public byte byID;

		public byte byEnable;

		public byte byDraw;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.I1)]
		public byte[] byRes;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string strName;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public VZ_LPRC_VERTEX[] struVertex;

		public uint eCrossDir;

		public uint uTriggerTimeGap;

		public uint uMaxLPWidth;

		public uint uMinLPWidth;
	}

	public struct VZ_LPRC_VIRTUAL_LOOPS
	{
		public uint uNumVirtualLoop;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public VZ_LPRC_VIRTUAL_LOOP[] struLoop;
	}

	public struct VZ_LPRC_PROVINCE_INFO
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
		public char[] strProvinces;

		public int nCurrIndex;
	}

	public struct TH_RECT
	{
		public int left;

		public int top;

		public int right;

		public int bottom;
	}

	public struct VzBDTime
	{
		public byte bdt_sec;

		public byte bdt_min;

		public byte bdt_hour;

		public byte bdt_mday;

		public byte bdt_mon;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
		public byte[] res1;

		public uint bdt_year;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
		public byte[] res2;
	}

	public struct VZ_TIMEVAL
	{
		public uint uTVSec;

		public uint uTVUSec;
	}

	public struct CarBrand
	{
		public byte brand;

		public byte type;

		public short year;
	}

	public struct TH_PlateResult
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
		public char[] license;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
		public char[] color;

		public int nColor;

		public int nType;

		public int nConfidence;

		public int nBright;

		public int nDirection;

		public TH_RECT rcLocation;

		public int nTime;

		public VZ_TIMEVAL tvPTS;

		public uint uBitsTrigType;

		public byte nCarBright;

		public byte nCarColor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
		public char[] reserved0;

		public uint uId;

		public VzBDTime struBDTime;

		public byte nIsEncrypt;

		public byte nPlateTrueWidth;

		public byte nPlateDistance;

		public byte nIsFakePlate;

		private TH_RECT car_location;

		private CarBrand car_brand;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
		public char[] featureCode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
		public char[] reserved;
	}

	public struct VzYUV420P
	{
		public IntPtr pY;

		public IntPtr pU;

		public IntPtr pV;

		private int widthStepY;

		private int widthStepU;

		private int widthStepV;

		private int width;

		private int height;
	}

	public struct VZ_LPRC_IMAGE_INFO
	{
		public uint uWidth;

		public uint uHeight;

		public uint uPitch;

		public uint uPixFmt;

		public IntPtr pBuffer;
	}

	public struct VZ_LPRC_DRAWMODE
	{
		public byte byDspAddTarget;

		public byte byDspAddRule;

		public byte byDspAddTrajectory;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
		public byte[] dwRes;
	}

	public struct VZ_DEV_SERIAL_NUM
	{
		public uint uHi;

		public uint uLo;
	}

	public struct VZ_TM
	{
		public short nYear;

		public short nMonth;

		public short nMDay;

		public short nHour;

		public short nMin;

		public short nSec;
	}

	public struct VZ_TM_WEEK_DAY
	{
		public byte bSun;

		public byte bMon;

		public byte bTue;

		public byte bWed;

		public byte bThur;

		public byte bFri;

		public byte bSat;

		public byte reserved;
	}

	public struct VZ_LPRC_OSD_Param
	{
		public byte dstampenable;

		public int dateFormat;

		public int datePosX;

		public int datePosY;

		public byte tstampenable;

		public int timeFormat;

		public int timePosX;

		public int timePosY;

		public byte nLogoEnable;

		public int nLogoPositionX;

		public int nLogoPositionY;

		public byte nTextEnable;

		public int nTextPositionX;

		public int nTextPositionY;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string overlaytext;
	}

	public struct VZ_TM_DAY
	{
		public short nHour;

		public short nMin;

		public short nSec;

		public short reserved;
	}

	public struct VZ_TM_WEEK_SEGMENT
	{
		public uint uEnable;

		public VZ_TM_WEEK_DAY struDaySelect;

		public VZ_TM_DAY struDayTimeStart;

		public VZ_TM_DAY struDayTimeEnd;
	}

	public struct VZ_TM_RANGE
	{
		public VZ_TM struTimeStart;

		public VZ_TM struTimeEnd;
	}

	public struct VZ_TM_PERIOD_OR_RANGE
	{
		public uint uEnable;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.Struct)]
		public VZ_TM_WEEK_SEGMENT[] struWeekSeg;
	}

	public struct VZ_DATE_TIME_INFO
	{
		public uint uYear;

		public uint uMonth;

		public uint uMDay;

		public uint uHour;

		public uint uMin;

		public uint uSec;
	}

	public enum VZ_LPR_WLIST_ERROR
	{
		VZ_LPR_WLIST_ERROR_NO_ERROR,
		VZ_LPR_WLIST_ERROR_PLATEID_EXISTS,
		VZ_LPR_WLIST_ERROR_INSERT_CUSTOMERINFO_FAILED,
		VZ_LPR_WLIST_ERROR_INSERT_VEHICLEINFO_FAILED,
		VZ_LPR_WLIST_ERROR_UPDATE_CUSTOMERINFO_FAILED,
		VZ_LPR_WLIST_ERROR_UPDATE_VEHICLEINFO_FAILED,
		VZ_LPR_WLIST_ERROR_PLATEID_EMPTY,
		VZ_LPR_WLIST_ERROR_ROW_NOT_CHANGED,
		VZ_LPR_WLIST_ERROR_CUSTOMERINFO_NOT_CHANGED,
		VZ_LPR_WLIST_ERROR_VEHICLEINFO_NOT_CHANGED,
		VZ_LPR_WLIST_ERROR_CUSTOMER_VEHICLE_NOT_MATCH,
		VZ_LPR_WLIST_ERROR_SERVER_GONE
	}

	public struct VZ_LPR_WLIST_VEHICLE
	{
		public uint uVehicleID;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string strPlateID;

		public uint uCustomerID;

		public uint bEnable;

		public uint bEnableTMEnable;

		public uint bEnableTMOverdule;

		public VZ_TM struTMEnable;

		public VZ_TM struTMOverdule;

		public uint bUsingTimeSeg;

		public VZ_TM_PERIOD_OR_RANGE struTimeSegOrRange;

		public uint bAlarm;

		public uint iColor;

		public uint iPlateType;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string strCode;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string strComment;
	}

	public struct VZ_LPR_WLIST_CUSTOMER
	{
		public uint uCustomerID;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string strName;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string strCode;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string reserved;
	}

	public struct VZ_LPR_WLIST_ROW
	{
		public IntPtr pCustomer;

		public IntPtr pVehicle;
	}

	public struct VZ_LPR_WLIST_SEARCH_CONSTRAINT
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string key;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string search_string;
	}

	public struct VZ_LPR_MSG_PLATE_INFO
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string plate;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string img_path;
	}

	public struct VZ_LPR_DEVICE_INFO
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string device_ip;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string serial_no;
	}

	public enum VZ_LPR_WLIST_LIMIT_TYPE
	{
		VZ_LPR_WLIST_LIMIT_TYPE_ONE,
		VZ_LPR_WLIST_LIMIT_TYPE_ALL,
		VZ_LPR_WLIST_LIMIT_TYPE_RANGE
	}

	public struct VZ_LPR_WLIST_RANGE_LIMIT
	{
		public int startIndex;

		public int count;
	}

	public struct VZ_LPR_WLIST_LIMIT
	{
		public VZ_LPR_WLIST_LIMIT_TYPE limitType;

		public IntPtr pRangeLimit;
	}

	public enum VZ_LPR_WLIST_SORT_DIRECTION
	{
		VZ_LPR_WLIST_SORT_DIRECTION_DESC,
		VZ_LPR_WLIST_SORT_DIRECTION_ASC
	}

	public struct VZ_LPR_WLIST_SORT_TYPE
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string key;

		public VZ_LPR_WLIST_SORT_DIRECTION direction;
	}

	public enum VZ_LPR_WLIST_SEARCH_TYPE
	{
		VZ_LPR_WLIST_SEARCH_TYPE_LIKE,
		VZ_LPR_WLIST_SEARCH_TYPE_EQUAL
	}

	public struct VZ_LPR_WLIST_SEARCH_WHERE
	{
		public VZ_LPR_WLIST_SEARCH_TYPE searchType;

		public uint searchConstraintCount;

		public IntPtr pSearchConstraints;
	}

	public struct VZ_LPR_WLIST_LOAD_CONDITIONS
	{
		public IntPtr pSearchWhere;

		public IntPtr pLimit;

		public IntPtr pSortType;
	}

	public struct VZ_LPR_WLIST_KEY_DEFINE
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string key;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string name;
	}

	public struct VZ_LPR_WLIST_IMPORT_RESULT
	{
		public int ret;

		public int error_code;
	}

	public enum VZLPRC_WLIST_CB_TYPE
	{
		VZLPRC_WLIST_CB_TYPE_ROW,
		VZLPRC_WLIST_CB_TYPE_CUSTOMER,
		VZLPRC_WLIST_CB_TYPE_VEHICLE
	}

	public enum VZ_LED_CTRL
	{
		VZ_LED_AUTO,
		VZ_LED_MANUAL_ON,
		VZ_LED_MANUAL_OFF
	}

	public struct VZ_LPRC_CENTER_SERVER_NET
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
		public string centerServerIp;

		public ushort port;

		public byte enableSsl;

		public ushort sslPort;

		public ushort timeout;
	}

	public struct VZ_LPRC_CENTER_SERVER_DEVICE_REG
	{
		public byte type;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
		public string url;
	}

	public struct VZ_LPRC_CENTER_SERVER_PLATE
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
		public string url;

		public byte enable;

		public byte contentLevel;

		public byte sendLargeImage;

		public byte sendSmallImage;
	}

	public struct VZ_LPRC_CENTER_SERVER_GIONIN
	{
		public byte enable;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
		public string url;
	}

	public struct VZ_LPRC_CENTER_SERVER_SERIAL
	{
		public byte enable;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
		public string url;
	}

	public struct VZ_LPRC_R_ENCODE_PARAM
	{
		public int default_stream;

		public int stream_id;

		public int resolution;

		public int frame_rate;

		public int encode_type;

		public int rate_type;

		public int data_rate;

		public int video_quality;
	}

	public struct VZ_LPRC_R_RESOLUTION
	{
		public int resolution_type;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string resolution_content;
	}

	public struct VZ_LPRC_R_RATE_TYPE
	{
		public int rate_type_value;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string rate_type_content;
	}

	public struct VZ_LPRC_R_VIDEO_QUALITY
	{
		private int video_quality_type;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string video_quality_content;
	}

	public struct VZ_LPRC_R_ENCODE_PARAM_PROPERTY
	{
		public int encode_stream;

		public int resolution_cur;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.Struct)]
		public VZ_LPRC_R_RESOLUTION[] resolution;

		public int frame_rate_cur;

		public int frame_rate_min;

		public int frame_rate_max;

		public int rate_type_cur;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.Struct)]
		public VZ_LPRC_R_RATE_TYPE[] rate_type;

		public int data_rate_cur;

		public int data_rate_min;

		public int data_rate_max;

		public int video_quality_cur;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.Struct)]
		public VZ_LPRC_R_VIDEO_QUALITY[] video_quality;
	}

	public struct VZ_LPRC_R_VIDEO_PARAM
	{
		public int brightness;

		public int contrast;

		public int saturation;

		public int sharpness;

		public int hue;

		public int exposure;

		public int max_exposure;

		public int gain;

		public int max_gain;

		public int denoise;

		public int flip;

		public int frquency;

		public int night_mode;
	}

	public struct VZ_CAR_INFO
	{
		public int logo_id;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
		public char[] car_logo;

		public int series_id;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
		public char[] car_series;

		public int style_id;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
		public char[] car_style;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
		public char[] reserved;
	}

	public delegate void VZLPRC_COMMON_NOTIFY_CALLBACK(int handle, IntPtr pUserData, VZ_LPRC_COMMON_NOTIFY eNotify, string pStrDetail);

	public delegate int VZLPRC_PLATE_INFO_CALLBACK(int handle, IntPtr pUserData, IntPtr pResult, uint uNumPlates, VZ_LPRC_RESULT_TYPE eResultType, IntPtr pImgFull, IntPtr pImgPlateClip);

	public delegate void VZLPRC_VIDEO_FRAME_CALLBACK(int handle, IntPtr pUserData, ref VzYUV420P pFrame);

	public delegate int VZDEV_SERIAL_RECV_DATA_CALLBACK(int nSerialHandle, IntPtr pRecvData, int uRecvSize, IntPtr pUserData);

	public delegate void VZLPRC_WLIST_QUERY_CALLBACK(VZLPRC_WLIST_CB_TYPE type, IntPtr pLP, IntPtr pCustomer, IntPtr pUserData);

	public delegate void VZLPRC_FIND_DEVICE_CALLBACK_EX(string pStrDevName, string pStrIPAddr, ushort usPort1, ushort usPort2, uint SL, uint SH, string netmask, string gateway, IntPtr pUserData);

	public delegate void VZLPRC_VIDEO_FRAME_CALLBACK_EX(int handle, IntPtr pUserData, ref VZ_LPRC_IMAGE_INFO pFrame);

	public delegate void VZLPRC_REQUEST_TALK_CALLBACK(int handle, int state, string error_msg, IntPtr pUserData);

	public delegate void VZLPRC_GPIO_RECV_CALLBACK(int handle, int nGPIOId, int nVal, IntPtr pUserData);

	public const int VZ_LPRC_TRIG_ENABLE_STABLE = 1;

	public const int VZ_LPRC_TRIG_ENABLE_VLOOP = 2;

	public const int VZ_LPRC_TRIG_ENABLE_IO_IN1 = 16;

	public const int VZ_LPRC_TRIG_ENABLE_IO_IN2 = 32;

	public const int VZ_LPRC_TRIG_ENABLE_IO_IN3 = 64;

	public const int LT_UNKNOWN = 0;

	public const int LT_BLUE = 1;

	public const int LT_BLACK = 2;

	public const int LT_YELLOW = 3;

	public const int LT_YELLOW2 = 4;

	public const int LT_POLICE = 5;

	public const int LT_ARMPOL = 6;

	public const int LT_INDIVI = 7;

	public const int LT_ARMY = 8;

	public const int LT_ARMY2 = 9;

	public const int LT_EMBASSY = 10;

	public const int LT_HONGKONG = 11;

	public const int LT_TRACTOR = 12;

	public const int LT_COACH = 13;

	public const int LT_MACAO = 14;

	public const int LT_ARMPOL2 = 15;

	public const int LT_ARMPOL_ZONGDUI = 16;

	public const int LT_ARMPOL2_ZONGDUI = 17;

	public const int LI_AVIATION = 18;

	public const int LI_ENERGY = 19;

	public const int LI_NO_PLATE = 20;

	public const int VZ_LPRC_REC_BLUE = 2;

	public const int VZ_LPRC_REC_YELLOW = 24;

	public const int VZ_LPRC_REC_BLACK = 4;

	public const int VZ_LPRC_REC_COACH = 8192;

	public const int VZ_LPRC_REC_POLICE = 32;

	public const int VZ_LPRC_REC_AMPOL = 64;

	public const int VZ_LPRC_REC_ARMY = 768;

	public const int VZ_LPRC_REC_GANGAO = 18432;

	public const int VZ_LPRC_REC_EMBASSY = 1024;

	public const int VZ_LPRC_REC_AVIATION = 1024;

	public const int VZ_LPRC_REC_ENERGY = 524288;

	public const int VZ_LPRC_REC_NO_PLATE = 1048576;

	public const int MAX_OutputConfig_Len = 7;

	public const int ENCRYPT_NAME_LENGTH = 32;

	public const int ENCRYPT_LENGTH = 16;

	public const int SIGNATURE_LENGTH = 32;

	public const int VZ_LPRC_ROI_VERTEX_NUM_EX = 12;

	public const int VZ_LPRC_VIRTUAL_LOOP_NAME_LEN = 32;

	public const int VZ_LPRC_VIRTUAL_LOOP_VERTEX_NUM = 4;

	public const int VZ_LPRC_VIRTUAL_LOOP_MAX_NUM = 8;

	public const int VZ_LPRC_PROVINCE_STR_LEN = 128;

	public const int LPRC_CENTER_IPLEN = 200;

	public const int URLLENGTH = 1000;

	public int VZ_LPRC_MAX_RESOLUTION = 12;

	public int VZ_LPRC_MAX_RATE = 5;

	public int VZ_LPRC_MAX_VIDEO_QUALITY = 12;

	public int VZ_GET_CAR_INFO = 1201;

	[DllImport("kernel32.dll")]
	public static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_Setup();

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern void VzLPRClient_Cleanup();

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VZLPRClient_SetCommonNotifyCallBack(VZLPRC_COMMON_NOTIFY_CALLBACK func, IntPtr pUserData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_Open(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_OpenV2(string pStrIP, ushort wPort, string pStrUserName, string pStrPassword, ushort wRtspPort, int network_type, string sn);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_Close(int handle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_CloseByIP(string pStrIP);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_IsConnected(int handle, ref byte pStatus);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetDeviceIP(int handle, ref byte ip, int max_count);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_StartRealPlay(int handle, IntPtr hWnd);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_StopRealPlay(int hRealHandle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int VzLPRClient_SetPlateInfoCallBack(int handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData, int bEnableImage);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int VzLPRClient_SetVideoFrameCallBack(int handle, VZLPRC_VIDEO_FRAME_CALLBACK pFunc, IntPtr pUserData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_ForceTrigger(int handle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetVirtualLoop(int handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetVirtualLoop(int handle, ref VZ_LPRC_VIRTUAL_LOOPS pVirtualLoops);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetRegionOfInterestEx(int handle, ref VZ_LPRC_ROI_EX pROI);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetSupportedProvinces(int handle, ref VZ_LPRC_PROVINCE_INFO pProvInfo);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_PresetProvinceIndex(int handle, int nIndex);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_ImageSaveToJpeg(IntPtr pImgInfo, string pFullPathName, int nQuality);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetSerialNumber(int handle, ref VZ_DEV_SERIAL_NUM pSN);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetSnapShootToJpeg2(int nPlayHandle, string pFullPathName, int nQuality);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SerialStart(int handle, int nSerialPort, VZDEV_SERIAL_RECV_DATA_CALLBACK func, IntPtr pUserData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SerialSend(int nSerialHandle, IntPtr pData, int uSizeData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SerialStop(int nSerialHandle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetIOOutput(int handle, int uChnId, int nOutput);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetIOOutput(int handle, int uChnId, ref int pOutput);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetGPIOValue(int handle, int gpioIn, IntPtr value);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_LoadImageById(int handle, int id, IntPtr pdata, IntPtr size);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_WhiteListImportRows(int handle, uint rowcount, ref VZ_LPR_WLIST_ROW pRowDatas, ref VZ_LPR_WLIST_IMPORT_RESULT pResults);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_WhiteListDeleteVehicle(int handle, string strPlateID);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_WhiteListClearCustomersAndVehicles(int handle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_WhiteListGetVehicleCount(int handle, ref uint pCount, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_WhiteListLoadVehicle(int handle, ref VZ_LPR_WLIST_LOAD_CONDITIONS pLoadCondition);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_WhiteListSetQueryCallBack(int handle, VZLPRC_WLIST_QUERY_CALLBACK func, IntPtr pUserData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_WhiteListUpdateVehicleByID(int handle, ref VZ_LPR_WLIST_VEHICLE pVehicle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_WhiteListGetRowCount(int handle, ref int count, ref VZ_LPR_WLIST_SEARCH_WHERE pSearchWhere);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetLEDLightControlMode(int handle, VZ_LED_CTRL eCtrl);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetLEDLightStatus(int handle, ref int pLevelNow, ref int pLevelMax);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetLEDLightLevel(int handle, int nLevel);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SaveRealData(int handle, string sFileName);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_StopSaveRealData(int handle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetOfflineCheck(int handle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_CancelOfflineCheck(int handle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VZLPRClient_StartFindDeviceEx(VZLPRC_FIND_DEVICE_CALLBACK_EX func, IntPtr pUserData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VZLPRClient_StopFindDevice();

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_QueryRecordByTimeAndPlate(int handle, string pStartTime, string pEndTime, string keyword);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_QueryCountByTimeAndPlate(int handle, string pStartTime, string pEndTime, string keyword);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_QueryPageRecordByTimeAndPlate(int handle, string pStartTime, string pEndTime, string keyword, int start, int end);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetQueryPlateCallBack(int handle, VZLPRC_PLATE_INFO_CALLBACK func, IntPtr pUserData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetOsdParam(int handle, IntPtr pParam);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetOsdParam(int handle, IntPtr pParam);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetDateTime(int handle, IntPtr IntpDTInfo);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_ReadUserData(int handle, IntPtr pBuffer, uint uSizeBuf);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_WriteUserData(int handle, IntPtr pUserData, uint uSizeData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_ImageEncodeToJpeg(IntPtr pImgInfo, IntPtr pDstBuf, int uSizeBuf, int nQuality);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetIOOutputAuto(int handle, int uChnId, int nDuration);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int VzLPRClient_StartRealPlayFrameCallBack(int handle, IntPtr hWnd, VZLPRC_VIDEO_FRAME_CALLBACK_EX func, IntPtr pUserData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetPlateTrigType(int handle, ref int pBitsTrigType);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetPlateTrigType(int handle, uint uBitsTrigType);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetDrawMode(int handle, ref VZ_LPRC_DRAWMODE pDrawMode);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetDrawMode(int handle, ref VZ_LPRC_DRAWMODE pDrawMode);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetPlateRecType(int handle, ref int pBitsRecType);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetPlateRecType(int handle, uint uBitsRecType);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetOutputConfig(int handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetOutputConfig(int handle, ref VZ_OutputConfigInfo pOutputConfigInfo);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetTriggerDelay(int handle, int nDelay);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetTriggerDelay(int handle, ref int nDelay);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetWLCheckMethod(int handle, int nType);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetWLCheckMethod(int handle, ref int nType);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetWLFuzzy(int handle, int nFuzzyType, int nFuzzyLen, bool bFuzzyCC);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetWLFuzzy(int handle, ref int nFuzzyType, ref int nFuzzyLen, ref bool bFuzzyCC);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetSerialParameter(int handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetSerialParameter(int handle, int nSerialPort, ref VZ_SERIAL_PARAMETER pParameter);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetVideoFrameSizeIndex(int handle, ref int sizeval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetVideoFrameSizeIndex(int handle, int sizeval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetVideoFrameSizeIndexEx(int handle, ref int sizeval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetVideoFrameSizeIndexEx(int handle, int sizeval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetVideoFrameRate(int handle, ref int Rateval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetVideoFrameRate(int handle, int Rateval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetVideoCompressMode(int handle, ref int modeval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetVideoCompressMode(int handle, int modeval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetVideoCBR(int handle, ref int rateval, ref int ratelist);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetVideoCBR(int handle, int rateval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetVideoPara(int handle, ref int brt, ref int cst, ref int sat, ref int hue);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetVideoPara(int handle, int brt, int cst, int sat, int hue);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetVideoEncodeType(int handle, int cmd);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetVideoEncodeType(int handle, ref int pEncType);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetVideoVBR(int handle, ref int levelval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetVideoVBR(int handle, int levelval);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetFrequency(int handle, ref int frequency);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetFrequency(int handle, int frequency);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetShutter(int handle, ref int shutter);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetShutter(int handle, int shutter);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetFlip(int handle, ref int flip);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetFlip(int handle, int flip);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_UpdateNetworkParam(uint SL, uint SH, string strNewIP, string strGateway, string strNetmask);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetSerialNo(string ip, short port, ref int SerHi, ref int SerLo);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_StartRealPlayDecData(int handle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_StopRealPlayDecData(int handle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetJpegStreamFromRealPlayDec(int handle, IntPtr pDstBuf, uint uSizeBuf, int nQuality);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetIsOutputRealTimeResult(int handle, bool bOutput);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetEMS(int handle, ref VZ_LPRC_ACTIVE_ENCRYPT pData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetEncrypt(int handle, IntPtr pCurrentKey, uint nEncyptId);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_ChangeEncryptKey(int handle, IntPtr pCurrentKey, IntPtr pNewKey);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_ResetEncryptKey(int handle, IntPtr pPrimeKey, IntPtr pNewKey);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_PlayVoice(int handle, string voice, int interval, int volume, int male);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetCenterServerNet(int handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetCenterServerNet(int handle, ref VZ_LPRC_CENTER_SERVER_NET pCenterServerNet);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetCenterServerDeviceReg(int handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetCenterServerDeviceReg(int handle, ref VZ_LPRC_CENTER_SERVER_DEVICE_REG pCenterServerDeviceReg);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetCenterServerPlate(int handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetCenterServerPlate(int handle, ref VZ_LPRC_CENTER_SERVER_PLATE pCenterServerPlate);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetCenterServerGionin(int handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetCenterServerGionin(int handle, ref VZ_LPRC_CENTER_SERVER_GIONIN pCenterServerGionin);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetCenterServerSerial(int handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetCenterServerSerial(int handle, ref VZ_LPRC_CENTER_SERVER_SERIAL pCenterServerSerial);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetCenterServerHostBak(int handle, string pCenterServerHostBak);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetCenterServerHostBak(int handle, ref string pCenterServerHostBak);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetHwBoardVersion(int handle, ref int board_version, ref long exdataSize);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetHwBoardType(int handle, ref int board_type);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetAlgResultParam(int handle, ref int reco_dis);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetAlgResultParam(int handle, int reco_dis);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetDenoise(int handle, ref int mode, ref int strength);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetDenoise(int handle, int mode, int strength);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_RGet_Encode_Param(int handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_RSet_Encode_Param(int handle, int stream, ref VZ_LPRC_R_ENCODE_PARAM param);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_RGet_Encode_Param_Property(int handle, ref VZ_LPRC_R_ENCODE_PARAM_PROPERTY param);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_RGet_Video_Param(int handle, ref VZ_LPRC_R_VIDEO_PARAM param);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_RSet_Video_Param(int handle, ref VZ_LPRC_R_VIDEO_PARAM param);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_StartTalk(int handle, int client_win_size);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetRequestTalkCallBack(int handle, VZLPRC_REQUEST_TALK_CALLBACK func, IntPtr pUserData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_StopTalk(int handle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_StartRecordAudio(int handle, string file_path);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_StopRecordAudio(int handle);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetIsShowPlateRect(int handle, int bShow);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_SetGPIORecvCallBack(int handle, VZLPRC_GPIO_RECV_CALLBACK func, IntPtr pUserData);

	[DllImport(".\\ZHENSHI\\VzLPRSDK.dll")]
	public static extern int VzLPRClient_GetCameraConfig(int handle, int command, short channel, IntPtr pOutBuffer, int dwOutBufferSize);
}
