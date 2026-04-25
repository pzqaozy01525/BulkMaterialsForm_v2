// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.bxdualsdk

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.SDK;

public class bxdualsdk
{
	public enum E_ScreenColor_G56
	{
		eSCREEN_COLOR_SINGLE = 1,
		eSCREEN_COLOR_DOUBLE,
		eSCREEN_COLOR_THREE,
		eSCREEN_COLOR_FULLCOLOR
	}

	public enum E_DoubleColorPixel_G56
	{
		eDOUBLE_COLOR_PIXTYPE_1 = 1,
		eDOUBLE_COLOR_PIXTYPE_2
	}

	public enum E_arrMode
	{
		eSINGLELINE,
		eMULTILINE
	}

	public enum E_DateStyle
	{
		eYYYY_MM_DD_MINUS,
		eYYYY_MM_DD_VIRGURE,
		eDD_MM_YYYY_MINUS,
		eDD_MM_YYYY_VIRGURE,
		eMM_DD_MINUS,
		eMM_DD_VIRGURE,
		eMM_DD_CHS,
		eYYYY_MM_DD_CHS
	}

	public enum E_TimeStyle
	{
		eHH_MM_SS_COLON,
		eHH_MM_SS_CHS,
		eHH_MM_COLON,
		eHH_MM_CHS,
		eAM_HH_MM,
		eHH_MM_AM
	}

	public enum E_WeekStyle
	{
		eMonday = 1,
		eMon,
		eMonday_CHS
	}

	public enum E_Color_G56
	{
		eBLACK,
		eRED,
		eGREEN,
		eYELLOW,
		eBLUE,
		eMAGENTA,
		eCYAN,
		eWHITE
	}

	public enum E_ClockStyle
	{
		eLINE,
		eSQUARE,
		eCIRCLE
	}

	public enum E_txtDirection
	{
		pNORMAL,
		pROTATERIGHT,
		pMIRROR,
		pROTATELEFT
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ConfigFile
	{
		public byte FileType;

		public byte[] ControllerName;

		private ushort Address;

		public byte Baudrate;

		private ushort ScreenWidth;

		private ushort ScreenHeight;

		public byte Color;

		public byte MirrorMode;

		public byte OEPol;

		public byte DAPol;

		public byte RowOrder;

		public byte FreqPar;

		public byte OEWidth;

		public byte OEAngle;

		public byte FaultProcessMode;

		public byte CommTimeoutValue;

		public byte RunningMode;

		public byte LoggingMode;

		public byte GrayFlag;

		public byte CascadeMode;

		public byte Default_brightness;

		public byte HUBConfig;

		public byte Language;

		public byte Backup;

		private ushort CRC16;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ConfigFile_G6
	{
		public byte FileType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] ControllerName;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
		private byte[] ScreenAddress;

		private ushort Address;

		public byte Baudrate;

		private ushort ScreenWidth;

		private ushort ScreenHeight;

		public byte Color;

		public byte modeofdisp;

		public byte TipLanguage;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
		public byte[] Reserved;

		public byte FaultProcessMode;

		public byte CommTimeoutValue;

		public byte RunningMode;

		public byte LoggingMode;

		public byte DevideScreenMode;

		public byte Reserved2;

		public byte Default_brightness;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
		public byte[] Backup;

		public ushort CRC16;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Ping_data
	{
		public ushort ControllerType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public byte[] FirmwareVersion;

		public byte ScreenParaStatus;

		public ushort uAddress;

		public byte Baudrate;

		public ushort ScreenWidth;

		public ushort ScreenHeight;

		public byte Color;

		public byte CurrentBrigtness;

		public byte CurrentOnOffStatus;

		public ushort ScanConfNumber;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
		public byte[] reversed;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] ipAdder;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct heartbeatData
	{
		public string password;

		public string ip;

		public string subNetMask;

		public string gate;

		public short port;

		public string mac;

		public string netID;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct NetSearchCmdRet
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public byte[] Mac;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] IP;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] SubNetMask;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] Gate;

		public ushort Port;

		public byte IPMode;

		public byte IPStatus;

		public byte ServerMode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] ServerIPAddress;

		public ushort ServerPort;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public byte[] ServerAccessPassword;

		public ushort HeartBeatInterval;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public byte[] CustomID;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] BarCode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] ControllerType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public byte[] FirmwareVersion;

		public byte ScreenParaStatus;

		public ushort Address;

		public byte Baudrate;

		public ushort ScreenWidth;

		public ushort ScreenHeight;

		public byte Color;

		public byte BrightnessAdjMode;

		public byte CurrentBrigtness;

		public byte TimingOnOff;

		public byte CurrentOnOffStatus;

		public ushort ScanConfNumber;

		public byte RowsPerChanel;

		public byte GrayFlag;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] UnitWidth;

		public byte modeofdisp;

		public byte NetTranMode;

		public byte PackageMode;

		public byte BarcodeFlag;

		public ushort ProgramNumber;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] CurrentProgram;

		public byte ScreenLockStatus;

		public byte ProgramLockStatus;

		public byte RunningMode;

		public byte RTCStatus;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] RTCYear;

		public byte RTCMonth;

		public byte RTCDate;

		public byte RTCHour;

		public byte RTCMinute;

		public byte RTCSecond;

		public byte RTCWeek;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] Temperature1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] Temperature2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] Humidity;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] Noise;

		public byte Reserved;

		public byte LogoFlag;

		public ushort PowerOnDelay;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] WindSpeed;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] WindDirction;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] PM2_5;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] PM10;

		public ushort ExtendParaLen;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] ControllerName;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
		public byte[] ScreenLocation;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] NameLocalationCRC32;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] PM100;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] AtmosphericPressure;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] illumination;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct NetSearchCmdRet_Web
	{
		private byte CmdGroup;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		private byte Mac;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		private byte IP;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		private byte SubNetMask;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		private byte Gate;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		private byte Port;

		private byte IPMode;

		private byte IPStatus;

		private byte ServerMode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		private byte ServerIPAddress;

		private ushort ServerPort;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		private byte ServerAccessPassword;

		public ushort HeartBeatInterval;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		private byte CustomID;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte WebUserID;

		public int GroupNum;

		private byte DomainFlag;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte DomainName;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte WebControllerName;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		private byte BarCode;

		private ushort ControllerType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		private byte FirmwareVersion;

		private byte ScreenParaStatus;

		private ushort Address;

		private byte Baudrate;

		private ushort ScreenWidth;

		private ushort ScreenHeight;

		private byte Color;

		private byte BrightnessAdjMode;

		private byte CurrentBrigtness;

		private byte TimingOnOff;

		private byte CurrentOnOffStatus;

		private ushort ScanConfNumber;

		private byte RowsPerChanel;

		private byte GrayFlag;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		private byte UnitWidth;

		private byte modeofdisp;

		private byte NetTranMode;

		private byte PackageMode;

		private byte BarcodeFlag;

		private ushort ProgramNumber;

		private int CurrentProgram;

		private byte ScreenLockStatus;

		private byte ProgramLockStatus;

		private byte RunningMode;

		private byte RTCStatus;

		private ushort RTCYear;

		private byte RTCMonth;

		private byte RTCDate;

		private byte RTCHour;

		private byte RTCMinute;

		private byte RTCSecond;

		private byte RTCWeek;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		private byte Temperature1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		private byte Temperature2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		private byte Humidity;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		private byte Noise;

		private byte Reserved;

		private byte LogoFlag;

		private ushort PowerOnDelay;

		private ushort WindSpeed;

		private ushort WindDirction;

		private ushort PM2_5;

		private ushort PM10;

		private ushort ExtendParaLen;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		private byte ControllerName;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
		private byte ScreenLocation;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		private byte NameLocalationCRC32;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TimingOnOff
	{
		public byte onHour;

		public byte onMinute;

		public byte offHour;

		public byte offMinute;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Brightness
	{
		public byte BrightnessMode;

		public byte HalfHourValue0;

		public byte HalfHourValue1;

		public byte HalfHourValue2;

		public byte HalfHourValue3;

		public byte HalfHourValue4;

		public byte HalfHourValue5;

		public byte HalfHourValue6;

		public byte HalfHourValue7;

		public byte HalfHourValue8;

		public byte HalfHourValue9;

		public byte HalfHourValue10;

		public byte HalfHourValue11;

		public byte HalfHourValue12;

		public byte HalfHourValue13;

		public byte HalfHourValue14;

		public byte HalfHourValue15;

		public byte HalfHourValue16;

		public byte HalfHourValue17;

		public byte HalfHourValue18;

		public byte HalfHourValue19;

		public byte HalfHourValue20;

		public byte HalfHourValue21;

		public byte HalfHourValue22;

		public byte HalfHourValue23;

		public byte HalfHourValue24;

		public byte HalfHourValue25;

		public byte HalfHourValue26;

		public byte HalfHourValue27;

		public byte HalfHourValue28;

		public byte HalfHourValue29;

		public byte HalfHourValue30;

		public byte HalfHourValue31;

		public byte HalfHourValue32;

		public byte HalfHourValue33;

		public byte HalfHourValue34;

		public byte HalfHourValue35;

		public byte HalfHourValue36;

		public byte HalfHourValue37;

		public byte HalfHourValue38;

		public byte HalfHourValue39;

		public byte HalfHourValue40;

		public byte HalfHourValue41;

		public byte HalfHourValue42;

		public byte HalfHourValue43;

		public byte HalfHourValue44;

		public byte HalfHourValue45;

		public byte HalfHourValue46;

		public byte HalfHourValue47;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ControllerStatus_G56
	{
		public byte onoffStatus;

		public byte timingOnOff;

		public byte brightnessAdjMode;

		public byte brightness;

		public short programeNumber;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] currentProgram;

		public byte screenLockStatus;

		public byte programLockStatus;

		public byte runningMode;

		public byte RTCStatus;

		public short RTCYear;

		public byte RTCMonth;

		public byte RTCDate;

		public byte RTCHour;

		public byte RTCMinute;

		public byte RTCSecond;

		public byte RTCWeek;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] temperature1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] temperature2;

		public short humidity;

		public short noise;

		public byte switchStatus;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public byte[] CustomID;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] BarCode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TimingReset
	{
		public byte rstMode;

		public uint RstInterval;

		public byte rstHour1;

		public byte rstMin1;

		public byte rstHour2;

		public byte rstMin2;

		public byte rstHour3;

		public byte rstMin3;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BattleTime
	{
		public short BattleRTCYear;

		public byte BattleRTCMonth;

		public byte BattleRTCDate;

		public byte BattleRTCHour;

		public byte BattleRTCMinute;

		public byte BattleRTCSecond;

		public byte BattleRTCWeek;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQprogrampTime_G56
	{
		public byte StartHour;

		public byte StartMinute;

		public byte StartSecond;

		public byte EndHour;

		public byte EndMinute;

		public byte EndSecond;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQprogramppGrp_G56
	{
		public byte playTimeGrpNum;

		public EQprogrampTime_G56 timeGrp0;

		public EQprogrampTime_G56 timeGrp1;

		public EQprogrampTime_G56 timeGrp2;

		public EQprogrampTime_G56 timeGrp3;

		public EQprogrampTime_G56 timeGrp4;

		public EQprogrampTime_G56 timeGrp5;

		public EQprogrampTime_G56 timeGrp6;

		public EQprogrampTime_G56 timeGrp7;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQprogramHeader
	{
		public byte FileType;

		public uint ProgramID;

		public byte ProgramStyle;

		public byte ProgramPriority;

		public byte ProgramPlayTimes;

		public ushort ProgramTimeSpan;

		public byte ProgramWeek;

		public ushort ProgramLifeSpan_sy;

		public byte ProgramLifeSpan_sm;

		public byte ProgramLifeSpan_sd;

		public ushort ProgramLifeSpan_ey;

		public byte ProgramLifeSpan_em;

		public byte ProgramLifeSpan_ed;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQscreenframeHeader
	{
		public byte FrameDispFlag;

		public byte FrameDispStyle;

		public byte FrameDispSpeed;

		public byte FrameMoveStep;

		public byte FrameWidth;

		public ushort FrameBackup;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQareaframeHeader
	{
		public byte AreaFFlag;

		public byte AreaFDispStyle;

		public byte AreaFDispSpeed;

		public byte AreaFMoveStep;

		public byte AreaFWidth;

		public ushort AreaFBackup;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQareaHeader
	{
		public byte AreaType;

		public ushort AreaX;

		public ushort AreaY;

		public ushort AreaWidth;

		public ushort AreaHeight;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQpageHeader
	{
		public byte PageStyle;

		public byte DisplayMode;

		public byte ClearMode;

		public byte Speed;

		public ushort StayTime;

		public byte RepeatTime;

		public ushort ValidLen;

		public E_arrMode arrMode;

		public ushort fontSize;

		public uint color;

		public byte fontBold;

		public byte fontItalic;

		public E_txtDirection tdirection;

		public ushort txtSpace;

		public byte Valign;

		public byte Halign;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQprogram
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] fileName;

		public byte fileType;

		public uint fileLen;

		public IntPtr fileAddre;

		public uint fileCRC32;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct getPageData
	{
		private ushort allPageNub;

		private uint pageLen;

		public byte[] fileAddre;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQunitHeader
	{
		private ushort UnitX;

		private ushort UnitY;

		public byte UnitType;

		public byte Align;

		public byte UnitColor;

		public byte UnitMode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQtimeAreaData_G56
	{
		public E_arrMode linestyle;

		public uint color;

		public string fontName;

		public ushort fontSize;

		public byte fontBold;

		public byte fontItalic;

		public byte fontUnderline;

		public byte fontAlign;

		public byte date_enable;

		public E_DateStyle datestyle;

		public byte time_enable;

		public E_TimeStyle timestyle;

		public byte week_enable;

		public E_WeekStyle weekstyle;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQAnalogClockHeader_G56
	{
		public ushort OrignPointX;

		public ushort OrignPointY;

		public byte UnitMode;

		public byte HourHandWidth;

		public byte HourHandLen;

		public uint HourHandColor;

		public byte MinHandWidth;

		public byte MinHandLen;

		public uint MinHandColor;

		public byte SecHandWidth;

		public byte SecHandLen;

		public uint SecHandColor;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQprogramHeader_G6
	{
		public byte FileType;

		public uint ProgramID;

		public byte ProgramStyle;

		public byte ProgramPriority;

		public byte ProgramPlayTimes;

		public ushort ProgramTimeSpan;

		public byte SpecialFlag;

		public byte CommExtendParaLen;

		public ushort ScheduNum;

		public ushort LoopValue;

		public byte Intergrate;

		public byte TimeAttributeNum;

		public ushort TimeAttribute0Offset;

		public byte ProgramWeek;

		public ushort ProgramLifeSpan_sy;

		public byte ProgramLifeSpan_sm;

		public byte ProgramLifeSpan_sd;

		public ushort ProgramLifeSpan_ey;

		public byte ProgramLifeSpan_em;

		public byte ProgramLifeSpan_ed;

		public byte PlayPeriodGrpNum;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQscreenframeHeader_G6
	{
		public byte FrameDispStype;

		public byte FrameDispSpeed;

		public byte FrameMoveStep;

		public byte FrameUnitLength;

		public byte FrameUnitWidth;

		public byte FrameDirectDispBit;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQSound_6G
	{
		public byte SoundFlag;

		public byte SoundPerson;

		public byte SoundVolum;

		public byte SoundSpeed;

		public byte SoundDataMode;

		public int SoundReplayTimes;

		public int SoundReplayDelay;

		public byte SoundReservedParaLen;

		public byte Soundnumdeal;

		public byte Soundlanguages;

		public byte Soundwordstyle;

		public int SoundDataLen;

		public IntPtr SoundData;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ClockColor_G56
	{
		public uint Color369;

		public uint ColorDot;

		public uint ColorBG;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQareaHeader_G6
	{
		public byte AreaType;

		public ushort AreaX;

		public ushort AreaY;

		public ushort AreaWidth;

		public ushort AreaHeight;

		public byte BackGroundFlag;

		public byte Transparency;

		public byte AreaEqual;

		public EQSound_6G stSoundData;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQPicAreaSoundHeader_G6
	{
		public byte SoundPerson;

		public byte SoundVolum;

		public byte SoundSpeed;

		public byte SoundDataMode;

		public uint SoundReplayTimes;

		public uint SoundReplayDelay;

		public byte SoundReservedParaLen;

		public byte Soundnumdeal;

		public byte Soundlanguages;

		public byte Soundwordstyle;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQTimeAreaBattle_G6
	{
		public ushort BattleStartYear;

		public byte BattleStartMonth;

		public byte BattleStartDate;

		public byte BattleStartHour;

		public byte BattleStartMinute;

		public byte BattleStartSecond;

		public byte BattleStartWeek;

		public byte StartUpMode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQpageHeader_G6
	{
		public byte PageStyle;

		public byte DisplayMode;

		public byte ClearMode;

		public byte Speed;

		public ushort StayTime;

		public byte RepeatTime;

		public ushort ValidLen;

		public byte CartoonFrameRate;

		public byte BackNotValidFlag;

		public E_arrMode arrMode;

		public ushort fontSize;

		public uint color;

		public byte fontBold;

		public byte fontItalic;

		public E_txtDirection tdirection;

		public ushort txtSpace;

		public byte Valign;

		public byte Halign;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQprogram_G6
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] fileName;

		public byte fileType;

		public uint fileLen;

		public IntPtr fileAddre;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] dfileName;

		public byte dfileType;

		public uint dfileLen;

		public IntPtr dfileAddre;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GetDirBlock_G56
	{
		public byte fileType;

		public ushort fileNumber;

		public IntPtr dataAddre;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct FileAttribute_G56
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] fileName;

		public byte fileType;

		public int fileLen;

		public int fileCRC;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQdynamicHeader
	{
		public byte RunMode;

		private ushort Timeout;

		public byte ImmePlay;

		public byte AreaType;

		private ushort AreaX;

		private ushort AreaY;

		private ushort AreaWidth;

		private ushort AreaHeight;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQSoundDepend_6G
	{
		public byte VoiceID;

		public EQSound_6G stSound;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct FileCRC16_G56
	{
		private IntPtr fileAddre;

		private ushort fileLen;

		private ushort fileCRC16;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct FileCRC32_G56
	{
		private IntPtr fileAddre;

		private ushort fileLen;

		private ushort fileCRC32;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct DynamicAreaParams
	{
		public byte uAreaId;

		public EQareaHeader_G6 oAreaHeader_G6;

		public EQpageHeader_G6 stPageHeader;

		public IntPtr fontName;

		public IntPtr strAreaTxtContent;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BxAreaFrmae_Dynamic_G6
	{
		public byte AreaFFlag;

		public EQscreenframeHeader_G6 oAreaFrame;

		public byte[] pStrFramePathFile;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BXSound_6G
	{
		public byte SoundFlag;

		public byte SoundPerson;

		public byte SoundVolum;

		public byte SoundSpeed;

		public byte SoundDataMode;

		public int SoundReplayTimes;

		public int SoundReplayDelay;

		public byte SoundReservedParaLen;

		public byte Soundnumdeal;

		public byte Soundlanguages;

		public byte Soundwordstyle;

		public int SoundDataLen;

		public IntPtr SoundData;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct DynamicAreaBaseInfo_5G
	{
		public byte nType;

		public byte DisplayMode;

		public byte ClearMode;

		public byte Speed;

		public ushort StayTime;

		public byte RepeatTime;

		public EQfontData oFont;

		public IntPtr fontName;

		public IntPtr strAreaTxtContent;

		public IntPtr filePath;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct EQfontData
	{
		public E_arrMode arrMode;

		public ushort fontSize;

		public uint color;

		public byte fontBold;

		public byte fontItalic;

		public E_txtDirection tdirection;

		public ushort txtSpace;

		public byte Halign;

		public byte Valign;
	}

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_InitSdk();

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern void bxDual_ReleaseSdk();

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_set_screenNum_G56(ushort usDstAddr);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_set_packetLen(ushort packetLen);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_searchController(ref Ping_data retData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_searchController(ref Ping_data retData, byte[] uartPort);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_search_Net_6G(ref NetSearchCmdRet retData, byte[] uartPort, ushort nBaudRateType);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_search_Net_6G_Web(ref NetSearchCmdRet_Web retData, byte[] uartPort, ushort nBaudRateType);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsFormat(byte[] uartPort, byte baudRate);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsStartFileTransf(byte[] uartPort, byte baudRate);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsEndFileTransf(byte[] uartPort, byte baudRate);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsDeleteFormatFile(byte[] uartPort, byte baudRate, short fileNub, byte[] fileName);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_confDeleteFormatFile(byte[] uartPort, byte baudRate, short fileNub, byte[] fileName);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsGetMemoryVolume(byte[] uartPort, byte baudRate, ref int totalMemVolume, ref int availableMemVolume);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_confWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsStartReedFile(byte[] uartPort, byte baudRate, byte[] fileName, int[] fileSize, int[] fileCrc);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_confStartReedFile(byte[] uartPort, byte baudRate, byte[] fileName, int[] fileSize, int[] fileCrc);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_confReedFileBlock(byte[] uartPort, byte baudRate, byte[] fileName, byte[] fileAddre);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsReedDirBlock(byte[] uartPort, byte baudRate, ref GetDirBlock_G56 dirBlock);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsFreeDirBlock(ref GetDirBlock_G56 dirBlock);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_ofsGetTransStatus(byte[] uartPort, byte baudRate, byte[] r_w, byte[] fileName, int[] fileCrc, int[] fileOffset);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_sendConfigFile(byte[] uartPort, byte baudRate, ref ConfigFile configData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_programLock(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, uint lockDuration);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_uart_programLock_6G(byte[] uartPort, byte baudRate, byte nonvolatile, byte locked, byte[] name, int lockDuration);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_AT_setWifiSsidPwd(byte[] ssid, byte[] pwd);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_AT_getWifiSsidPwd(byte[] ssid, byte[] pwd);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_udpNetworkSearch(ref heartbeatData retData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_udpNetworkSearch_6G(ref NetSearchCmdRet retData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_udpNetworkSearch_6G_Web(ref NetSearchCmdRet_Web retData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_udpPing(ref Ping_data retData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_udpSetMac(byte[] mac);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_udpSetIP(byte mode, byte[] ip, byte[] subnetMask, byte[] gateway, short port, byte serverMode, byte[] serverIP, short serverPort, byte[] password, short heartbeat, byte[] netID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_sysReset(byte[] ip, ushort port);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_tcpPing(byte[] ip, ushort port, ref Ping_data retData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_check_time(byte[] ip, ushort port);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_check_time_uart(byte[] uartPort, byte baudRate);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_tcpNetworkSearch_6G(byte[] ip, ushort port, ref NetSearchCmdRet retData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_tcpNetworkSearch_6G_Web(byte[] ip, ushort port, ref NetSearchCmdRet_Web retData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_coerceOnOff(byte[] ip, ushort port, byte onOff);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_coerceOnOff_uart(byte[] sPortName, byte nBaudRateIndex, byte nOnOff);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_timingOnOff(byte[] ip, ushort port, byte groupNum, byte[] data);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_cancelTimingOnOff(byte[] ip, ushort port);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_setBrightness(byte[] ip, ushort port, ref Brightness brightness);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_setBrightness_uart(byte[] sPortName, byte nBaudRateIndex, ref Brightness brightness);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_readControllerID(byte[] ip, ushort port, byte[] ControllerID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_screenLock(byte[] ip, ushort port, byte nonvolatile, byte locked);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_programLock(byte[] ip, ushort port, byte nonvolatile, byte locked, byte[] name, uint lockDuration);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_check_controllerStatus(byte[] ip, ushort port, ref ControllerStatus_G56 controllerStatus);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_setPassword(byte[] ip, ushort port, byte[] oldPassword, byte[] newPassword);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_deletePassword(byte[] ip, ushort port, byte[] password);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_setDelayTime(byte[] ip, ushort port, short delayTime);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_setBtnFunc(byte[] ip, ushort port, byte btnMode);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_setTimingReset(byte[] ip, ushort port, ref TimingReset cmdData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_setDispMode(byte[] ip, ushort port, byte dispMode);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_battieTime(byte[] ip, ushort port, byte mode, ref BattleTime battieData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_getStopwatch(byte[] ip, ushort port, byte mode, ref int timeValue);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_getSensorBrightnessValue(byte[] ip, ushort port, ref int brightnessValue);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_setSpeedAdjust(byte[] ip, ushort port, short speed);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_setScreenAddress(byte[] ip, ushort port, short address);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofsFormat(byte[] ip, ushort port);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofsStartFileTransf(byte[] ip, ushort port);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofsEndFileTransf(byte[] ip, ushort port);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofsDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_confDeleteFormatFile(byte[] ip, ushort port, short fileNub, byte[] fileName);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofsGetMemoryVolume(byte[] ip, ushort port, ref int totalMemVolume, ref int availableMemVolume);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofsWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_confWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, int fileLen, byte overwrite, byte[] fileAddre);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofsStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_confStartReedFile(byte[] ip, ushort port, byte[] fileName, ref uint fileSize, ref uint fileCrc);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofsReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_confReedFileBlock(byte[] ip, ushort port, byte[] fileName, byte[] fileAddre);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofsReedDirBlock(byte[] ip, ushort port, ref GetDirBlock_G56 dirBlock);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_getFileAttr(ref GetDirBlock_G56 dirBlock, ushort number, ref FileAttribute_G56 fileAttr);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofs_freeDirBlock(ref GetDirBlock_G56 dirBlock);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_ofsGetTransStatus(byte[] ip, ushort port, byte[] r_w, byte[] fileName, int[] fileCrc, int[] fileOffset);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_firmwareActivate(byte[] ip, ushort port, byte[] firmwareFileName);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_sendConfigFile(byte[] ip, ushort port, ref ConfigFile configData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_cmd_sendConfigFile_G6(byte[] ip, ushort port, ref ConfigFile_G6 configData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_get_crc16(ref FileCRC16_G56 crc16);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_get_crc32(ref FileCRC32_G56 crc32);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_deleteProgram();

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_freeBuffer(ref EQprogram program);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_pictureArea(int programID, byte[] ip, ushort port);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_setScreenParams_G56(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_addProgram(ref EQprogramHeader programH);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_changeProgramParams(ref EQprogramHeader programH);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_addPlayPeriodGrp(ref EQprogramppGrp_G56 header);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_AddArea(ushort areaID, ref EQareaHeader aheader);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_deleteArea(ushort areaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader pheader);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_fontPath_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader pheader);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_fontPath_picturesAreaChangeTxt(ushort areaID, byte[] str, ref EQpageHeader pheader);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_IntegrateProgramFile(ref EQprogram program);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_picturesAreaAddFrame(ushort areaID, ref EQareaframeHeader afHeader, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_picturesAreaAddFrame_G6(ushort areaID, ref EQscreenframeHeader_G6 afHeader, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_pictureAreaGetOnePage(ushort areaID, int pageNum, ref getPageData pageData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_pictureAreaAddPic(ushort areaID, ushort picID, ref EQpageHeader pheader, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_addFrame(ref EQscreenframeHeader sfHeader, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_changeFrame(ref EQscreenframeHeader sfHeader, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_removeFrame();

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_pictureAreaRemoveFrame(ushort areaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_MoveArea(ushort areaID, int x, int y, int width, int height);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_fontPath_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaChangeContent(ushort areaID, ref EQtimeAreaData_G56 timeData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaGetOnePage(ushort areaID, ref getPageData pageData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaAddAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaChangeAnalogClock(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaChangeDialPic(ushort areaID, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaChangeDialPicAdd_G56(ushort areaID, byte[] picAdd, int picLen);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaRemoveDialPic(ushort areaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56 ePixelRGorGR);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaTxt_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, IntPtr fontName, byte nFontSize, IntPtr strAreaTxtContent);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ref EQareaHeader_G6 oAreaHeader_G6, ref EQpageHeader_G6 stPageHeader, IntPtr fontName, IntPtr strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY, ushort AreaWidth, ushort AreaHeight, ref EQpageHeader_G6 pheader, IntPtr picPath, ushort RelateProNum, ushort[] RelateProSerial);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicAreaS_AddTxtDetails_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicAreaS_AddTxtDetails_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicAreaS_AddAreaPic_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicAreaS_AddAreaPic_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaCount, DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaInfos_6G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, ref DynamicAreaBaseInfo_5G[] pInfo);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaInfos_G6_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, ref DynamicAreaBaseInfo_5G[] pInfo);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaInfos_6G_V2(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, BxAreaFrmae_Dynamic_G6 oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo, ref EQSound_6G pSoundData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial(byte[] pSerialName, byte nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_DelArea_6G(byte[] pIP, int nPort, byte uAreaId);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_DelAreas_6G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_DelArea_G6_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_DelAreas_G6_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_InsertSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, byte VoiceFlg, byte StoreFlag);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_UpdateSoundIndepend(byte[] pIP, int nPort, ref EQSoundDepend_6G stSoundData, ushort nSoundDataCount, byte StoreFlag);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaWithTxt_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaWithTxt_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaWithTxt_Point_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, ref EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, ref EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial(byte[] pSerialName, int nBaundRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, ref EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, ref EQfontData oFont, byte[] fontName, byte[] strAreaTxtContent);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaWithPic_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, byte[] filePath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaWithPic_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte DisplayMode, byte ClearMode, byte Speed, ushort StayTime, byte RepeatTime, byte[] filePath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaInfos_5G(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, [In][Out] DynamicAreaBaseInfo_5G[] pInfo);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaInfos_5G_Point(byte[] pIP, int nPort, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_AddAreaInfos_5G_Serial(byte[] pSerialName, int nBaudRateIndex, E_ScreenColor_G56 color, byte uAreaId, byte RunMode, ushort Timeout, byte RelateAllPro, ushort RelateProNum, ushort[] RelateProSerial, byte ImmePlay, ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame, byte nInfoCount, DynamicAreaBaseInfo_5G[] pInfo);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_DelArea_5G(byte[] pIP, int nPort, byte uAreaId);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_DelAreaS_5G(byte[] pIP, int nPort, byte uAreaCount, byte[] pAreaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_DelArea_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaId);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_dynamicArea_DelAreaS_G5_Serial(byte[] pSerialName, byte nBaudRateIndex, byte uAreaCount, byte[] pAreaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_addProgram_G6(ref EQprogramHeader_G6 programH);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_addPlayPeriodGrp_G6(ref EQprogramppGrp_G56 header);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_deleteProgram_G6();

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_freeBuffer_G6(ref EQprogram_G6 program);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_changeProgramParams_G6(ref EQprogramHeader_G6 programH);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_addFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_changeFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_removeFrame_G6();

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_addArea_G6(ushort areaID, ref EQareaHeader_G6 aheader);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_deleteArea_G6(ushort areaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_MoveArea_G6(ushort areaID, int x, int y, int width, int height);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontName, ref EQpageHeader_G6 pheader);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_picturesAreaChangeTxt_G6(ushort areaID, IntPtr str, ref EQpageHeader_G6 pheader);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_fontPath_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontPathName, ref EQpageHeader_G6 pheader);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_fontPath_picturesAreaChangeTxt_G6(ushort areaID, byte[] str, ref EQpageHeader_G6 pheader);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_pictureAreaAddPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_backGroundPic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_backGroundColor_G6(ushort areaID, ref EQpageHeader_G6 pheader, int BGColor);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_pictureAreaChangePic_G6(ushort areaID, ushort picID, ref EQpageHeader_G6 pheader, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_pictureAreaEnableSound_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_pictureAreaChangeSoundSettings_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_pictureAreaDisableSound_G6(ushort areaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaSetBattleTime_G6(ushort areaID, ref EQTimeAreaBattle_G6 header);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaCancleBattleTime_G6(ushort areaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaChangeContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_fontPath_timeAreaAddContent_G6(ushort areaID, ref EQtimeAreaData_G56 timeData);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaAddAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaChangeAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref ClockColor_G56 cColor);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaChangeDialPic_G6(ushort areaID, byte[] picPath);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_timeAreaRemoveDialPic_G6(ushort areaID);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_IntegrateProgramFile_G6(ref EQprogram_G6 program);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_Start_Server(int port);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_Stop_Server(int pServer);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_Get_Port_Barcode(byte[] barcode);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_Get_CardList(byte[] cards);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_SetSensorArea_G6(ushort nAreaID, byte nSensorMode, byte nSensorType, byte nSensorUnit, byte[] pFixedTxt, byte[] pFontName, byte nFontSize, byte nSensorColor, byte SensorErrColor1, int nAlarmValue, byte nSensorThreshPol, byte nDisplayUnitFlag, byte nSensorModeDispType, byte nSensorCorrectionPol, int nSensorCorrection, byte nRatioValue);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_SetSensorAreaTemperature_G5(ushort nAreaID, byte nSensorType, byte nTemperatureUnit, byte nTermperatureMode, byte nTemperatureCorrectionPol, byte nTemperatureCorrection, byte nTemperatureThreshPol, byte nTemperatureThresh, byte nTemperatureColor, byte nTemperatureErrColor, byte[] pstrFixTxt, byte nFontSize, byte[] pstrFontNameFile, byte nUnitShowRation);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_SetSensorAreaHumidity_G5(ushort nAreaID, byte nSensorType, byte nHumidityMode, byte nHumidityCorrectionPol, byte nHumidityCorrection, byte nHumidityThresh, byte nHumidityColor, byte nHumidityErrColor, byte[] pstrFixTxt, byte nFontSize, byte[] pstrFontNameFile, byte nUnitShowRation);

	[DllImport("YB\\bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
	public static extern int bxDual_program_SetSensorAreaNoise_G5(ushort nAreaID, byte nSensorType, byte nNoiseMode, byte nNoiseCorrectionPol, byte nNoiseCorrection, byte nNoiseThresh, byte nNoiseColor, byte nNoiseErrColor, byte[] pstrFixTxt, byte nFontSize, byte[] pstrFontNameFile, byte nUnitShowRation);
}
