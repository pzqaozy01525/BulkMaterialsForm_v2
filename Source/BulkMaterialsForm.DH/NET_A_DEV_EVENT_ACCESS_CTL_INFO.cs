// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_ACCESS_CTL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_ACCESS_CTL_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public EM_ACCESS_CTL_EVENT_TYPE emEventType;

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

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSnapURL;

	public int nErrorCode;

	public int nPunchingRecNo;

	public int nNumbers;

	public byte byImageIndex;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved;

	public uint dwSnapFlagMask;

	public EM_ATTENDANCESTATE emAttendanceState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szClassNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szPhoneNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCardName;

	public uint uSimilarity;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public NET_DEV_ACCESS_CTL_IMAGE_INFO[] stuImageInfo;

	public int nImageInfoCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szCitizenIDNo;

	public uint nGroupID;

	public int nCompanionCardCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 192)]
	public string szCompanionCards;

	public NET_DEV_ACCESS_CTL_CUSTOM_WORKER_INFO stuCustomWorkerInfo;

	public EM_CARD_STATE emCardState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	public EM_HAT_STYLE emHatStyle;

	public EM_UNIFIED_COLOR_TYPE emHatColor;

	public EM_LIFT_CALLER_TYPE emLiftCallerType;

	public bool bManTemperature;

	public NET_MAN_TEMPERATURE_INFO stuManTemperatureInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szCitizenName;

	public int nCompanionInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	public NET_COMPANION_INFO[] stuCompanionInfo;

	public EM_MASK_STATE_TYPE emMask;

	public uint nFaceIndex;

	public bool bClassNumberEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szClassNumberEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDormitoryNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szStudentNo;

	public EM_USER_TYPE emUserType;

	public bool bRealUTC;

	public NET_TIME_EX RealUTC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szQRCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
	public string szCompanyName;

	public int nScore;

	public EM_FACE_CHECK emFaceCheck;

	public EM_QRCODE_IS_EXPIRED emQRCodeIsExpired;

	public EM_QRCODE_STATE emQRCodeState;

	public NET_TIME stuQRCodeValidTo;

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

	public int nHSJCResult;

	public NET_VACCINE_INFO stuVaccineInfo;

	public NET_TRAVEL_INFO stuTravelInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szTrafficPlate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szQRCodeEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRecordUrl;

	public NET_HSJC_INFO stuHSJCInfo;

	public NET_ANTIGEN_INFO stuAntigenInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szHealthGreenStatus;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 108)]
	public string szCitizenIDAddress;

	public uint nCitizenIDEC;

	public NET_TIME stuCitizenIDBirth;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	public int nAge;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 400)]
	public byte[] szReversed;
}
