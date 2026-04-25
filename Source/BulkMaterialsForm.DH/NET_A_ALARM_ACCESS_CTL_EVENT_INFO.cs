// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_ACCESS_CTL_EVENT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_ACCESS_CTL_EVENT_INFO
{
	public uint dwSize;

	public int nDoor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDoorName;

	public NET_TIME stuTime;

	public EM_A_NET_ACCESS_CTL_EVENT_TYPE emEventType;

	public bool bStatus;

	public EM_A_NET_ACCESSCTLCARD_TYPE emCardType;

	public EM_A_NET_ACCESS_DOOROPEN_METHOD emOpenMethod;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPwd;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szReaderID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szSnapURL;

	public int nErrorCode;

	public int nPunchingRecNo;

	public int nNumbers;

	public EM_A_NET_ACCESSCTLCARD_STATE emStatus;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	public EM_ATTENDANCESTATE emAttendanceState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szQRCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szCallLiftFloor;

	public EM_CARD_STATE emCardState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szCitizenIDNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 192)]
	public string szCompanionCards;

	public int nCompanionCardCount;

	public EM_HAT_STYLE emHatStyle;

	public EM_UNIFIED_COLOR_TYPE emHatColor;

	public EM_LIFT_CALLER_TYPE emLiftCallerType;

	public bool bManTemperature;

	public NET_MAN_TEMPERATURE_INFO stuManTemperatureInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szCitizenName;

	public EM_MASK_STATE_TYPE emMask;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCardName;

	public uint nFaceIndex;

	public EM_USER_TYPE emUserType;

	public bool bRealUTC;

	public NET_TIME_EX RealUTC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
	public string szCompanyName;

	public int nScore;

	public int nLiftNo;

	public EM_QRCODE_IS_EXPIRED emQRCodeIsExpired;

	public EM_QRCODE_STATE emQRCodeState;

	public NET_TIME stuQRCodeValidTo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDynPWD;

	public uint nBlockId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szWorkClass;

	public EM_TEST_ITEMS emTestItems;

	public NET_TEST_RESULT stuTestResult;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserUniqueID;

	public bool bUseCardNameEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCardNameEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szTempPassword;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szNote;

	public int nHSJCResult;

	public NET_VACCINE_INFO stuVaccineInfo;

	public NET_TRAVEL_INFO stuTravelInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szQRCodeEx;

	public NET_HSJC_INFO stuHSJCInfo;

	public NET_ANTIGEN_INFO stuAntigenInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szHealthGreenStatus;

	public int nAge;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCheckOutType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szCheckOutCause;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1500)]
	public string szReserved;
}
