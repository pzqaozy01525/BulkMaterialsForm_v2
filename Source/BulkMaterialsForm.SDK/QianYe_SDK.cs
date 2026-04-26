// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.QianYe_SDK

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BulkMaterialsForm.SDK;

public class QianYe_SDK
{
	public enum E_ReturnCode
	{
		DC_NO_ERROR = 0,
		DC_HANDLE_INVALID = 1,
		DC_CONN_FAIL = 2,
		DC_OBJ_BUSY = 3,
		DC_OBJ_UNEXIST = 4,
		DC_CMD_INVALID = 5,
		DC_PARA_INVALID = 6,
		DC_REQ_TIMEOUT = 7,
		DC_MEMORY_LACK = 8,
		DC_SEND_FAIL = 9,
		DC_RECV_FAIL = 10,
		DC_OPT_FAIL = 11,
		DC_NOT_CONN = 12,
		DC_BEYOND_MAX_CLIENT = 13,
		DC_CONNECT_AUTH = 18,
		DC_USER_NOT_EXIST = 19,
		DC_PASSWD_ERROR = 20,
		DC_TF_NOT_EXIST = 21,
		DC_TF_IO_ERROR = 22,
		DC_ENCPYPTION_ERR = 23,
		DC_UNDEFINED_ERROR = -1,
		DC_CONN_PORT_NEGO_FAIL = 1000,
		DC_CONN_RXQUE_CREATE_FAIL = 1001,
		DC_CONN_TXQUE_CREATE_FAIL = 1002,
		DC_CONN_REQUE_CREATE_FAIL = 1003,
		DC_CONN_30000_CONTROL_TSK_CREATE_FAIL = 1004,
		DC_CONN_40000_CONTROL_TSK_CREATE_FAIL = 1005,
		DC_CONN_SERVER_ERROR = 1006,
		DC_CONN_RESPONSE_CODE_AUTHORITY_LIMIT = 1007,
		DC_WHITE_LIST_FILE_OPEN_FAIL = 1100,
		DC_WHITE_LIST_FILE_EMPTY = 1101,
		DC_WHITE_LIST_FILE_MAPPING_FAIL = 1102,
		DC_WHITE_LIST_FILE_MAPPING_OPEN_FAIL = 1103,
		DC_WHITE_LIST_MEMORY_LACK_FAIL = 1104,
		DC_WHITE_LIST_FILE_SIZE_MORE = 1105,
		DC_WHITE_LIST_FORMAT_ERROR = 1106,
		DC_WHITE_LIST_CREATE_NEW_FILE_FAIL = 1107,
		DC_WHITE_LIST_WRITE_NEW_FILE_FAIL = 1108,
		DC_WHITE_LIST_WRITE_NEW_FILE_LENGTH_ERROR = 1109,
		DC_WHITE_LIST_MEMORY_LACK_FAIL_OLD = 1110,
		DC_WHITE_LIST_CREATE_THREAD_FAIL = 1111,
		DC_WHITE_LIST_PLATE_EMPTY = 1112,
		DC_WHITE_LIST_PLATE_LENGTH_ERROR = 1113,
		DC_WHITE_LIST_PLATE_SPECIAL_CHAR = 1114,
		DC_WHITE_LIST_TIME_YEAR_ERROR = 1115,
		DC_WHITE_LIST_TIME_MONTH_ERROR = 1117,
		DC_WHITE_LIST_TIME_BIG_MONTH_DAY_ERROR = 1118,
		DC_WHITE_LIST_TIME_SMALL_MONTH_DAY_ERROR = 1119,
		DC_WHITE_LIST_TIME_LEAP_YEAR_DAY_ERROR = 1120,
		DC_WHITE_LIST_TIME_NO_LEAP_YEAR_DAY_ERROR = 1121,
		DC_WHITE_LIST_TIME_HOUR_ERROR = 1122,
		DC_WHITE_LIST_TIME_MINUTE_ERROR = 1123,
		DC_WHITE_LIST_TIME_SECOND_ERROR = 1124,
		DC_WHITE_LIST_TIME_START_THAN_END = 1125,
		DC_WHITE_LIST_EXPORT_CSV_READ_FAIL = 1126,
		DC_WHITE_LIST_EXPORT_CSV_WRITE_FAIL = 1127,
		DC_UPLOAD_DATA_SERVER_ALLOC_FAIL = 1200,
		DC_UPLOAD_UNABLE_TO_OPEN_FILE = 1201,
		DC_UPLOAD_SOCKET_CREATE_FAIL = 1202,
		DC_UPLOAD_CONNECT_CAMERA_FAIL = 1203,
		DC_UPLOAD_READ_FILE_FAIL = 1204,
		DC_UPLOAD_SEND_FILE_NO_ALL = 1205,
		DC_UPLOAD_DATA_SERVER_ALLOC_FAIL_OLD = 1220,
		DC_UPLOAD_DATA_CREATE_THREAD_FAIL_OLD = 1221,
		DC_DOWNLOAD_DATA_SERVER_ALLOC_FAIL = 1250,
		DC_DOWNLOAD_SOCKET_CREATE_FAIL = 1251,
		DC_DOWNLOAD_CONNECT_CAMERA_FAIL = 1252,
		DC_DOWNLOAD_CREATE_FILE_FAIL = 1253,
		DC_DOWNLOAD_RECV_DATA_FAIL = 1254,
		DC_GET_PORT_SOCKET_ERROR = 1300,
		DC_GET_PORT_GET_LOCAL_IP_FAIL = 1301,
		DC_GET_PORT_FAIL = 1302,
		DC_UPDATE_FILE_TYPE_ERROR = 1400
	}

	public struct T_ImageUserInfo
	{
		public ushort usWidth;

		public ushort usHeight;

		public byte ucVehicleColor;

		public byte ucVehicleBrand;

		public byte ucVehicleSize;

		public byte ucPlateColor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] szLprResult;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public ushort[] usLpBox;

		public byte ucLprType;

		public ushort usSpeed;

		public byte ucSnapType;

		public byte ucReserved;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
		public byte[] acSnapTime;

		public byte ucViolateCode;

		public byte ucLaneNo;

		public uint uiVehicleId;

		public byte ucScore;

		public byte ucDirection;

		public byte ucTotalNum;

		public byte ucSnapshotIndex;
	}

	public struct T_ImageUserInfo2
	{
		public ushort usWidth;

		public ushort usHeight;

		public byte ucVehicleColor;

		public byte ucVehicleBrand;

		public byte ucVehicleSize;

		public byte ucPlateColor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] szLprResult;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public ushort[] usLpBox;

		public byte ucLprType;

		public ushort usSpeed;

		public byte ucSnapType;

		public byte ucReserved;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
		public byte[] acSnapTime;

		public byte ucViolateCode;

		public byte ucLaneNo;

		public uint uiVehicleId;

		public byte ucScore;

		public byte ucDirection;

		public byte ucTotalNum;

		public byte ucSnapshotIndex;

		public uint uiVideoProcTime;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public byte[] strVehicleBrand;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public byte[] strConfidence;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)]
		public byte[] strSpecialCode;

		public byte ucHasCar;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] aucReserved1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
		public byte[] aucReserved2;
	}

	public struct T_PicInfo
	{
		public uint uiPanoramaPicLen;

		public uint uiVehiclePicLen;

		public IntPtr ptPanoramaPicBuff;

		public IntPtr ptVehiclePicBuff;
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public delegate int FGetImageCB(int tHandle, uint uiImageId, ref T_ImageUserInfo tImageInfo, ref T_PicInfo tPicInfo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public delegate int FGetImageCB2(int tHandle, uint uiImageId, ref T_ImageUserInfo2 tImageInfo, ref T_PicInfo tPicInfo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public delegate int FGetImageCBEx(int tHandle, uint uiImageId, ref T_ImageUserInfo tImageInfo, ref T_PicInfo tPicInfo, IntPtr obj);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public delegate int FGetImageCBEx2(int tHandle, uint uiImageId, ref T_ImageUserInfo2 tImageInfo, ref T_PicInfo tPicInfo, IntPtr obj);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public delegate int FGetOffLineImageCBEx(int tHandle, uint uiImageId, ref T_ImageUserInfo tImageInfo, ref T_PicInfo tPicInfo, IntPtr obj);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public delegate int FGetReportCBEx(int tHandle, byte ucType, IntPtr ptMessage, IntPtr pUserData);

	public struct T_FrameInfo
	{
		public uint uiFrameId;

		public uint uiTimeStamp;

		public uint uiEncSize;

		public uint uiFrameType;
	}

	public struct T_ControlGate
	{
		[MarshalAs(UnmanagedType.U1)]
		public byte ucState;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] ucReserved;
	}

	public struct T_ControlGateQueue
	{
		[MarshalAs(UnmanagedType.U1)]
		public byte ucState;

		[MarshalAs(UnmanagedType.U1)]
		public byte ucIndex;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] ucReserved;
	}

	public struct T_BlackWhiteList
	{
		public byte LprMode;

		public byte LprCode;

		public byte Lprnew;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] aucLplPath;
	}

	public struct T_GetBlackWhiteList
	{
		public byte LprMode;

		public byte LprCode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] aucLplPath;
	}

	public struct T_LprResult
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] LprResult;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] StartTime;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] EndTime;
	}

	public struct T_BlackWhiteListCount
	{
		public int uiCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] aucLplPath;
	}

	public struct T_VehPayRsp
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] acPlate;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
		public byte[] acEntryTime;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
		public byte[] acExitTime;

		public uint uiRequired;

		public uint uiPrepaid;

		public byte ucVehType;

		public byte ucUserType;

		public byte ucResultCode;

		public byte acReserved;
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public delegate int FGetOffLinePayRecordCB(int tHandle, byte ucType, ref T_VehPayRsp ptVehPayInfo, uint uiLen, ref T_PicInfo ptPicInfo, IntPtr obj);

	public struct T_NetSetup
	{
		public byte ucEth;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] aucReserved;

		public uint uiIPAddress;

		public uint uiMaskAddress;

		public uint uiGatewayAddress;

		public uint uiDNS1;

		public uint uiDNS2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] szHostName;
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public delegate int FDrawFunCallBack(int tHandle, IntPtr hdc, int width, int height, IntPtr obj);

	public struct T_TwoEncpyption
	{
		public uint uiDataLen;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] aucDataBuff;
	}

	public struct T_TwoEncpyptionSet
	{
		public byte switchflag;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] aucReserved;

		public T_TwoEncpyption Encpyptioninfo;
	}

	public struct T_Point
	{
		public short sX;

		public short sY;
	}

	public struct T_Line
	{
		public T_Point tStartPoint;

		public T_Point tEndPoint;
	}

	public struct T_Rect
	{
		public T_Point tLefTop;

		public T_Point tRightBottom;
	}

	public struct T_DivisionLine
	{
		public byte ucDashedLine;

		public byte ucReserved;

		public T_Line tLine;
	}

	public struct T_VideoDetectParamSetup
	{
		public byte ucLanes;

		public byte ucSnapAutoBike;

		public ushort usBanTime;

		public byte ucVirLoopNum;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] aucReserved;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
		public T_Point[] atPlateRegion;

		public T_Line aStopLine;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
		public T_Point[] atSpeedRegion;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.Struct)]
		public T_Line[] atOccupCheckLine;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.Struct)]
		public T_DivisionLine[] atDivisionLine;

		public T_Line tPrefixLine;

		public T_Line tLeftBorderLine;

		public T_Line tRightBorderLine;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.Struct)]
		public T_Point[] atVirLoop;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
		public T_Point[] atBanRegion;

		public ushort usCameraHeight;

		public ushort usRectLength;

		public ushort usRectWidth;

		public ushort usTotalDis;
	}

	public struct T_RS485Data
	{
		public byte rs485Id;

		public byte ucReserved;

		public ushort dataLen;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
		public byte[] data;
	}

	public struct T_DCTimeSetup
	{
		public ushort usYear;

		public byte ucMonth;

		public byte ucDay;

		public byte ucHour;

		public byte ucMinute;

		public byte ucSecond;

		public byte ucDayFmt;

		public byte ucTimeFmt;

		public byte ucTimeZone;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] aucReserved;
	}

	public struct T_VehicleVAFunSetup
	{
		public byte ucPlateRecogEn;

		public byte ucVehicleSizeRecogEn;

		public byte ucVehicleColorRecogEn;

		public byte ucVehicleBrandRecogEn;

		public byte ucVehicleSizeClassify;

		public byte ucLocalCity;

		public byte ucPlateDirection;

		public byte ucCpTimeInterval;

		public uint uiPlateDefaultWord;

		public ushort usMinPlateW;

		public ushort usMaxPlateW;

		public byte ucDoubleYellowPlate;

		public byte ucDoubleArmyPlate;

		public byte ucPolicePlate;

		public byte ucPlateFeature;
	}

	public struct T_MACSetup
	{
		public byte ucEth;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] aucReserved;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public byte[] aucMACAddresss;
	}

	public struct T_RcvMsg
	{
		public uint uiFlag;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public byte[] aucDstMACAdd;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] aucAdapterName;

		public uint uiAdapterSubMask;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] ancDevType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] ancSerialNum;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] ancAppVersion;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] ancDSPVersion;

		public T_NetSetup tNetSetup;

		public T_MACSetup tMacSetup;
	}

	public struct T_IOStateRsp
	{
		public byte ucIndex;

		public byte ucLState;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] aucReserved;
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public delegate int FNetFindDeviceCallback(ref T_RcvMsg ptFindDevice, IntPtr obj);

	public struct T_QueVersionRsp
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] szKernelVersion;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] szFileSystemVersion;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] szAppVersion;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] szWebVersion;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] szHardwareVersion;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] szDevType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] szSerialNum;

		public uint uiDateOfExpiry;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] szDSPVersion;
	}

	public enum E_BaudRate
	{
		BAUD_RATE_1200,
		BAUD_RATE_2400,
		BAUD_RATE_4800,
		BAUD_RATE_9600,
		BAUD_RATE_19200,
		BAUD_RATE_38400,
		BAUD_RATE_57600,
		BAUD_RATE_115200,
		BAUD_RATE_ALL
	}

	public enum E_CheckType
	{
		CHECK_TYPE_NONE,
		CHECK_TYPE_ODD,
		CHECK_TYPE_EVEN,
		CHECK_TYPE_FLAG,
		CHECK_TYPE_EMPTY,
		CHECK_TYPE_ALL
	}

	public struct T_RS485Setup
	{
		public byte ucIndex;

		public byte ucFunction;

		public byte ucBaudRate;

		public byte ucDataBits;

		public byte ucStopBits;

		public byte ucCheckOut;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] ucReserved;
	}

	public const string SdkDLLName = "\\SDK_QianYe\\NetSDK.dll";

	public const int MAX_HOST_LEN = 16;

	public const int ONE_DIRECTION_LANES = 5;

	public const int VERSION_NAME_LEN = 64;

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_Init();

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern void Net_UNinit();

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_AddCamera(string ptIp);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_DelCamera(int tHandle);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_QueryConnState(int tHandle);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_ConnCamera(int tHandle, ushort usPort, ushort usTimeout);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_DisConnCamera(int tHandle);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_StartVideo(int tHandle, int niStreamType, IntPtr hWnd);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_StopVideo(int tHandle);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_GetSdkVersion([MarshalAs(UnmanagedType.LPStr)] StringBuilder szVersion, ref int ptLen);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern float Net_MatchSpecialCode2(float[] fSpecialCode1, float[] fSpecialCode2);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_RegImageRecv(FGetImageCB fCb);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_RegImageRecv2(FGetImageCB2 fCb);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_RegImageRecvEx(int tHandle, FGetImageCBEx fCb, IntPtr obj);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_RegImageRecvEx2(int tHandle, FGetImageCBEx2 fCb, IntPtr obj);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_RegOffLineImageRecvEx(int tHandle, FGetOffLineImageCBEx fCb, IntPtr obj);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_RegReportMessEx(int tHandle, FGetReportCBEx fCb, IntPtr obj);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_DeleteAllBlackWhiteList(int tHandle);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_ImageSnap(int tHandle, ref T_FrameInfo ptImageSnap);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_GateSetup(int tHandle, ref T_ControlGate ptControlGate);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_QueryControlGateQueue(int tHandle, ref T_ControlGateQueue ptControlGateQueue);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int Net_ControlGateQueue(int tHandle, ref T_ControlGateQueue ptControlGateQueue);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_RegOffLineClient(int tHandle);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_BlackWhiteListSend(int tHandle, ref T_BlackWhiteList ptBalckWhiteList);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_GetBlackWhiteList(int tHandle, ref T_GetBlackWhiteList ptGetBalckWhiteList);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_GetBlackWhiteListAsCSV(int tHandle, ref T_GetBlackWhiteList ptGetBalckWhiteList);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_BlackWhiteListSetup(ref T_LprResult ptLprResult, ref T_BlackWhiteListCount ptBlackWhiteListCount);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_BlackWhiteListSetup(IntPtr ptLprResult, ref T_BlackWhiteListCount ptBlackWhiteListCount);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_SaveImageToJpeg(int tHandle, string ucPathNmme);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_GetJpgBuffer(int tHandle, ref IntPtr ucJpgBuffer, ref ulong ulSize);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_FreeBuffer(IntPtr pJpgBuffer);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_SaveJpgFile(int tHandle, string strJpgFile);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_SaveBmpFile(int tHandle, string strBmpFile);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_StartRecord(int tHandle, string strFile);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_StopRecord(int tHandle);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_ShowPlateRegion(int tHandle, int niShowMode);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_UpdatePlateRegion(int tHandle);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_RegOffLinePayRecord(int tHandle, FGetOffLinePayRecordCB fCb, IntPtr obj);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_NETSetup(int tHandle, ref T_NetSetup ptNetSetup);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_QueryNETSetup(int tHandle, ref T_NetSetup ptNetSetup);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_SetDrawFunCallBack(int tHandle, FDrawFunCallBack fCb, IntPtr obj);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_ReadTwoEncpyption(int tHandle, [MarshalAs(UnmanagedType.LPStr)] StringBuilder pBuff, uint uiSizeBuff);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_WriteTwoEncpyption(int tHandle, string pUserData, uint uiDataLen);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_WriteGPIOState(int tHandle, byte ucIndex, byte ucValue);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_SetDecPwd(int tHandle, string password);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_EnableEnc(int tHandle, byte ucEncId, string password);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_ModifyEncPwd(int tHandle, string OldPassword, string NewPassword);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_TwoEncpyptionSet(int tHandle, ref T_TwoEncpyptionSet ptTwoEncpyptionSet);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_VideoDetectSetup(int tHandle, ref T_VideoDetectParamSetup ptVideoDetectParamSetup);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_QueryVideoDetectSetup(int tHandle, ref T_VideoDetectParamSetup ptVideoDetectParamSetup);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_SendRS485Data(int tHandle, ref T_RS485Data ptRS485Data);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_TimeSetup(int tHandle, ref T_DCTimeSetup ptTimeSetup);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_QueryTimeSetup(int tHandle, ref T_DCTimeSetup ptTimeSetup);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_VehicleVAFunSetup(int tHandle, ref T_VehicleVAFunSetup ptVehicleVAFunSetup);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_QueryVehicleVAFunSetup(int tHandle, ref T_VehicleVAFunSetup ptVehicleVAFunSetup);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_FindDevice(FNetFindDeviceCallback fCb, IntPtr obj);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_StartTalk(int tHandle);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_StopTalk(int tHandle);

	[DllImport("\\SDK_QianYe\\NetSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int Net_RS485Setup(int tHandle, ref T_RS485Setup ptRs485Setup);

	public static int WhiteListOperate(int tHandle, ref T_LprResult ptLprResult, int optID)
	{
		lock ("WhiteListOperateSingle")
		{
			T_BlackWhiteListCount ptBlackWhiteListCount = new T_BlackWhiteListCount
			{
				uiCount = 1
			};
			string text = Path.Combine(Application.StartupPath, tHandle + "_lpr_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".ini");
			byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(text);
			ptBlackWhiteListCount.aucLplPath = new byte[256];
			bytes.CopyTo(ptBlackWhiteListCount.aucLplPath, 0);
			if (Net_BlackWhiteListSetup(ref ptLprResult, ref ptBlackWhiteListCount) != 0)
			{
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				return -1;
			}
			T_BlackWhiteList ptBalckWhiteList = new T_BlackWhiteList
			{
				LprMode = 1,
				Lprnew = (byte)optID,
				aucLplPath = new byte[256]
			};
			Array.Copy(ptBlackWhiteListCount.aucLplPath, 0, ptBalckWhiteList.aucLplPath, 0, 256);
			int result = Net_BlackWhiteListSend(tHandle, ref ptBalckWhiteList);
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			return result;
		}
	}

	public static int WhiteListOperate(int tHandle, IntPtr ptLprResult, int Count, int optID)
	{
		lock ("WhiteListOperateBatch")
		{
			T_BlackWhiteListCount ptBlackWhiteListCount = new T_BlackWhiteListCount
			{
				uiCount = Count
			};
			string text = Path.Combine(Application.StartupPath, tHandle + "_lpr_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".ini");
			byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(text);
			ptBlackWhiteListCount.aucLplPath = new byte[256];
			bytes.CopyTo(ptBlackWhiteListCount.aucLplPath, 0);
			if (Net_BlackWhiteListSetup(ptLprResult, ref ptBlackWhiteListCount) != 0)
			{
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				return -1;
			}
			T_BlackWhiteList ptBalckWhiteList = new T_BlackWhiteList
			{
				LprMode = 1,
				Lprnew = (byte)optID,
				aucLplPath = new byte[256]
			};
			Array.Copy(ptBlackWhiteListCount.aucLplPath, 0, ptBalckWhiteList.aucLplPath, 0, 256);
			int result = Net_BlackWhiteListSend(tHandle, ref ptBalckWhiteList);
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			return result;
		}
	}

	public static string IntToIp(uint ipInt)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append((ipInt >> 24) & 0xFF).Append(".");
		stringBuilder.Append((ipInt >> 16) & 0xFF).Append(".");
		stringBuilder.Append((ipInt >> 8) & 0xFF).Append(".");
		stringBuilder.Append(ipInt & 0xFF);
		return stringBuilder.ToString();
	}

	public static uint Reverse_uint(uint uiNum)
	{
		return ((uiNum & 0xFF) << 24) | ((uiNum & 0xFF00) << 8) | ((uiNum & 0xFF0000) >> 8) | ((uiNum & 0xFF000000u) >> 24);
	}

	public static bool CheckCameraL_Mac(string CameraMac, int tHandle)
	{
		if (CameraMac.Length == 0)
		{
			return true;
		}
		bool result = false;
		_ = new byte[256];
		StringBuilder stringBuilder = new StringBuilder(256);
		if (Net_ReadTwoEncpyption(tHandle, stringBuilder, 256u) > 0 && stringBuilder.ToString().IndexOf(CameraMac) >= 0)
		{
			result = true;
		}
		return result;
	}
}
