// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.Led5kSDK

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.SDK;

public class Led5kSDK
{
	public class bx5k_err
	{
		public const int ERR_NO = 0;

		public const int ERR_OUTOFGROUP = 1;

		public const int ERR_NOCMD = 2;

		public const int ERR_BUSY = 3;

		public const int ERR_MEMORYVOLUME = 4;

		public const int ERR_CHECKSUM = 5;

		public const int ERR_FILENOTEXIST = 6;

		public const int ERR_FLASH = 7;

		public const int ERR_FILE_DOWNLOAD = 8;

		public const int ERR_FILE_NAME = 9;

		public const int ERR_FILE_TYPE = 10;

		public const int ERR_FILE_CRC16 = 11;

		public const int ERR_FONT_NOT_EXIST = 12;

		public const int ERR_FIRMWARE_TYPE = 13;

		public const int ERR_DATE_TIME_FORMAT = 14;

		public const int ERR_FILE_EXIST = 15;

		public const int ERR_FILE_BLOCK_NUM = 16;

		public const int ERR_COMMUNICATE = 100;

		public const int ERR_PROTOCOL = 101;

		public const int ERR_TIMEOUT = 102;

		public const int ERR_NETCLOSE = 103;

		public const int ERR_INVALID_HAND = 104;

		public const int ERR_PARAMETER = 105;

		public const int ERR_SHOULDREPEAT = 106;

		public const int ERR_FILE = 107;
	}

	public enum serial_stopbits : byte
	{
		COM_ONESTOPBIT,
		COM_ONE5STOPBITS,
		COM_TWOSTOPBITS
	}

	public enum serial_parity : byte
	{
		COM_NOPARITY,
		COM_ODDPARITY,
		COM_EVENPARITY,
		COM_MARKPARITY,
		COM_SPACEPARITY
	}

	public enum serial_databits : byte
	{
		COM_4BITS = 4,
		COM_5BITS,
		COM_6BITS,
		COM_7BITS,
		COM_8BITS
	}

	public enum bx_5k_card_type : byte
	{
		BX_5K1 = 81,
		BX_5K2 = 88,
		BX_5MK2 = 83,
		BX_5MK1 = 84,
		BX_5K1Q_YY = 92,
		BX_Any = 254,
		BX_6K1 = 97,
		BX_6K2 = 98,
		BX_6K3 = 99,
		BX_6K1_YY = 100,
		BX_6K2_YY = 101,
		BX_6K3_YY = 102,
		BX_6K1_4G = 103,
		BX_6K2_4G = 104
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct bx_5k_area_header
	{
		public byte AreaType;

		public ushort AreaX;

		public ushort AreaY;

		public ushort AreaWidth;

		public ushort AreaHeight;

		public byte DynamicAreaLoc;

		public byte Lines_sizes;

		public byte RunMode;

		public short Timeout;

		public byte Reserved1;

		public byte Reserved2;

		public byte Reserved3;

		public byte SingleLine;

		public byte NewLine;

		public byte DisplayMode;

		public byte ExitMode;

		public byte Speed;

		public byte StayTime;

		public int DataLen;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct bx_5k_sound
	{
		public byte StoreFlag;

		public byte SoundPerson;

		public byte SoundVolum;

		public byte SoundSpeed;

		public byte SoundDataMode;

		public int SoundReplayTimes;

		public int SoundReplayDelay;

		public byte SoundReservedParaLen;

		public int SoundDataLen;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct bx_k_IO
	{
		public byte TestPin;

		public byte IrPin;

		public byte HumPin;

		public byte TempPin;

		public byte LightClkPin;

		public byte LightDataPin;

		public byte EXP01;

		public byte EXP02;

		public byte EXTEN;
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void CallBackClientClose(uint hand, int err);

	public delegate void CloseFunc(int total, int sendlen);

	public delegate void CallBackCon(uint dwHand, string pid);

	public delegate void CallBackLedClose(uint dwHand, string pid, int err_code);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern void InitSdk(byte minorVer, byte majorVer);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern void ReleaseSdk();

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern uint CreateBroadCast(byte[] broad_ip, uint broad_port, bx_5k_card_type card_type, byte[] barcode, byte Option, int mode);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern uint CreateClient(byte[] led_ip, uint led_port, bx_5k_card_type card_type, int tmout_sec, int mode, CallBackClientClose pCloseFunc);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern uint CreateTcpModbus(byte[] led_ip, bx_5k_card_type card_type, CallBackClientClose pCloseFunc);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern uint CreateComClient(byte com, uint baudrate, bx_5k_card_type card_type, int mode, ushort ScreenID);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern uint CreateComModbus(byte com, uint baudrate, serial_parity Parity, serial_databits DataBits, serial_stopbits StopBits, bx_5k_card_type card_type, ushort ScreenID);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern void Destroy(uint dwHand);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern void SetTimeout(uint dwHand, uint nSec);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_PING(uint dwHand);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_Reset(uint dwHand);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_ControllerStatus(uint dwHand, byte[] pStatus, ref ushort len);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_CheckCurrentFont(uint dwHand, byte[] fontStatus, ref ushort len);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_CheckCurrentCustomer(uint dwHand, byte[] CustomerStatus, ref ushort len);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_ReadScreen(uint dwHand, byte[] ScreenStatus, ref ushort len);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_SytemClockCorrect(uint dwHand);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_CheckCurrentFirmware(uint dwHand, byte[] FirmwareName, byte[] FirmwareVersion, byte[] FirmwareDateTime);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_SendFirmWareData(uint dwHand, byte overwrite, byte[] pFileName, byte[] FirmWareData, int FirmWareDataLen, CloseFunc pCloseFunc);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_FirmwareActivate(uint dwHand, byte[] FirmwareName);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_SetScreenID(uint dwHand, ushort newScreenID);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_ReadScreenID(uint dwHand, ref ushort pScreenID);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_ForceOnOff(uint dwHand, byte OnOffFlag);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_TimeTurnOnOff(uint dwHand, byte[] pTimer, int nGroup);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_SetBrightness(uint dwHand, byte BrightnessType, byte CurrentBrightness, byte[] BrightnessValue);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_SetWaitTime(uint dwHand, byte WaitTime);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_LockProgram(uint dwHand, byte LockFlag, byte StoreMode, byte[] ProgramFileName);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_DelDynamicArea(uint dwHand, byte DeleteAreaId);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_SendDynamicArea(uint dwHand, bx_5k_area_header header, ushort TextLen, byte[] AreaText);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_SendSound(uint dwHand, bx_5k_sound sound, int TextLen, byte[] AreaText);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_SendSoundDynamicArea(uint dwHand, bx_5k_area_header header, ushort TextLen, byte[] AreaText, byte SoundMode, byte SoundPerson, byte SoundVolume, byte SoundSpeed, int sound_len, byte[] sounddata);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_Test(uint dwHand, byte TestTime);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_CancelTimeOnOff(uint dwHand);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int BX5MK_SetSpecialAppDynamic(uint dwHand, ushort AreaX, ushort AreaY, ushort AreaW, ushort AreaH, byte DataType, byte Pagetotal, byte RunState, ushort Timeout, byte SingleLine, byte Lines_sizes, byte NewLine, ushort StayTime);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int BX5MK_SendPageData(uint dwHand, byte PageNum, ushort PageDataLen, byte[] PageData);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int BX5MK_SendLatticeMessage(uint dwHand, byte BlockFlag, ushort BlockAddr, byte[] BlockData, ushort BlockDataLen);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int BX5MK_DelSpecialAppDynamic(uint dwHand);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int BX5MK_SetIPAddress(uint dwHand, byte ConnnectMode, byte[] ip, byte[] SubnetMask, byte[] Gateway, ushort port, byte ServerMode, byte[] ServerIPAddress, ushort ServerPort, byte[] ServerAccessPassword, ushort HeartBeatInterval, byte[] NetID);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int BX5MK_SetMACAddress(uint dwHand, byte[] MAC);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int BX5MK_SetSpecialAppDynamic(int dwHand, ushort AreaX, ushort AreaY, ushort AreaW, ushort AreaH, byte DataType, byte Pagetotal, byte RunState, ushort Timeout, byte SingleLine, byte Lines_sizes, byte NewLine, ushort StayTime);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int BX5MK_WebSearch(uint dwHand, ref ushort Status, ref ushort Error, byte[] IP, byte[] SubNetMask, byte[] Gate, ref ushort Port, byte[] Mac, byte[] NetID);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int BX5MK_DelPageData(uint dwHand, byte PageLog);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_Formatting(uint dwHand);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_DeleteFile(uint dwHand, ushort FileNumber, byte[] pFileNameList);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_BeginSendMultiFiles(uint dwHand);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_SendFile(uint dwHand, byte overwrite, byte[] pFilePath);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_SendFileData(uint dwHand, byte overwrite, byte[] pFileName, ushort DisplayType, byte PlayTimes, byte[] ProgramLife, byte ProgramWeek, byte ProgramTime, byte[] Period, byte AreaNum, byte[] AreaDataList, int AreaDataListLen);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_SendScanData(uint dwHand, byte overwrite, byte[] pFileName, byte[] ScanData, int ScanDataLen);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_SendFontData(uint dwHand, byte overwrite, byte[] pFileName, byte FontWidth, byte FontHeight, byte[] LibData, int LibData_len, byte FontEncode, CloseFunc pCloseFunc);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_SendScreenData(uint dwHand, byte overwrite, byte[] pFileName, ushort Address, byte Baudrate, ushort ScreenWith, ushort ScreenHeight, byte Color, byte MirrorMode, byte OE, byte DA, byte RowOrder, byte FreqPar, byte OEAngle, byte CommTimeout, byte TipLanguage, byte LatticeMode);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_EndSendMultiFiles(uint dwHand);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_SetDispInfo(uint dwHand, byte DispInfo);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int OFS_SetFontInformation(uint dwHand, byte OverWrite, byte[] ClientMsg);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern bool StartGprsServer(uint port, CallBackCon pCallBackCon, CallBackLedClose pCallBackLedClose);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern void CloseGprsServer();

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern void SetGprsAliveTick(uint dwHand, int time_sec);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SendAndRecvBuff(uint dwHand, byte cmd_group, byte cmd, byte[] cmd_data, ushort data_len, byte[] recv_data, ref short p_recv_len);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SendBuff(uint dwHand, byte cmd_group, byte cmd, byte[] cmd_data, ushort data_len);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int BX5MK_WebSearch(uint dwHand, byte[] recv_buff, ushort[] recv_len);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_SendIO(uint dwHand, bx_k_IO header);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int SCREEN_Send_one_IO(uint dwHand, byte Pin, byte PIN_state);

	[DllImport("YB\\Led5kSDK.dll", CharSet = CharSet.Unicode)]
	public static extern int CON_ReadIO(uint dwHand, byte[] IOStatus, ref ushort len);
}
