// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORDSET_ACCESS_CTL_CARDREC

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RECORDSET_ACCESS_CTL_CARDREC
{
	public uint dwSize;

	public int nRecNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPwd;

	public NET_TIME stuTime;

	public bool bStatus;

	public EM_A_NET_ACCESS_DOOROPEN_METHOD emMethod;

	public int nDoor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public int nReaderID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szSnapFtpUrl;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szReaderID;

	public EM_A_NET_ACCESSCTLCARD_TYPE emCardType;

	public int nErrorCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRecordURL;

	public int nNumbers;

	public EM_ATTENDANCESTATE emAttendanceState;

	public EM_DIRECTION_ACCESS_CTL emDirection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szClassNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szPhoneNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCardName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	public bool bCitizenIDResult;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
	public string szCitizenIDName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved1;

	public EM_CITIZENIDCARD_SEX_TYPE emCitizenIDSex;

	public EM_CITIZENIDCARD_EC_TYPE emCitizenIDEC;

	public NET_TIME stuCitizenIDBirth;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 108)]
	public string szCitizenIDAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szCitizenIDAuthority;

	public NET_TIME stuCitizenIDStart;

	public NET_TIME stuCitizenIDEnd;

	public bool bIsEndless;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSnapFaceURL;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCitizenPictureURL;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szCitizenIDNo;

	public NET_ACCESSCTLCARD_SEX emSex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRole;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szProjectNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szProjectName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szBuilderName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szBuilderID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szBuilderType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szBuilderTypeID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPictureID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szContractID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szWorkerTypeID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szWorkerTypeName;

	public bool bPersonStatus;

	public EM_HAT_STYLE emHatStyle;

	public EM_UNIFIED_COLOR_TYPE emHatColor;

	public NET_MAN_TEMPERATURE_INFO stuManTemperatureInfo;

	public int nCompanionInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	public NET_COMPANION_INFO[] stuCompanionInfo;

	public EM_MASK_STATE_TYPE emMask;

	public uint nFaceIndex;

	public int nScore;

	public int nLiftNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szQRCode;

	public EM_FACE_CHECK emFaceCheck;

	public EM_QRCODE_IS_EXPIRED emQRCodeIsExpired;

	public EM_QRCODE_STATE emQRCodeState;

	public NET_TIME stuQRCodeValidTo;

	public EM_LIFT_CALLER_TYPE emLiftCallerType;

	public uint nBlockId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szWorkClass;

	public EM_TEST_ITEMS emTestItems;

	public NET_TEST_RESULT stuTestResult;

	public bool bUseCardNameEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCardNameEx;

	public int nHSJCResult;

	public int nVaccinateFlag;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szVaccineName;

	public int nDateCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szVaccinateDate;

	public EM_TRAVEL_CODE_COLOR emTravelCodeColor;

	public int nCityCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szPassingCity;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szTrafficPlate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRecordLocalUrl;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szHSJCReportDate;

	public int nHSJCExpiresIn;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szAntigenReportDate;

	public int nAntigenStatus;

	public int nAntigenExpiresIn;
}
