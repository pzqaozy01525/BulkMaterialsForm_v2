// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORDSET_ACCESS_CTL_CARD

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RECORDSET_ACCESS_CTL_CARD
{
	public uint dwSize;

	public int nRecNo;

	public NET_TIME stuCreateTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public EM_A_NET_ACCESSCTLCARD_STATE emStatus;

	public EM_ACCESSCTLCARD_TYPE emType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPsw;

	public int nDoorNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] sznDoors;

	public int nTimeSectionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] sznTimeSectionNo;

	public int nUseTime;

	public NET_TIME stuValidStartTime;

	public NET_TIME stuValidEndTime;

	public bool bIsValid;

	public NET_ACCESSCTLCARD_FINGERPRINT_PACKET stuFingerPrintInfo;

	public bool bFirstEnter;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCardName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szVTOPosition;

	public bool bHandicap;

	public bool bEnableExtended;

	public NET_ACCESSCTLCARD_FINGERPRINT_PACKET_EX stuFingerPrintInfoEx;

	public int nFaceDataNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40960)]
	public byte[] szFaceData;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szDynamicCheckCode;

	public int nRepeatEnterRouteNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	public int[] arRepeatEnterRoute;

	public int nRepeatEnterRouteTimeout;

	public bool bNewDoor;

	public int nNewDoorNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] nNewDoors;

	public int nNewTimeSectionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] nNewTimeSectionNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCitizenIDNo;

	public int nSpecialDaysScheduleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] arSpecialDaysSchedule;

	public uint nUserType;

	public int nFloorNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szFloorNo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szSection;

	public int nScore;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
	public byte[] szCompanyName;

	public uint nSectionID;

	public EM_ACCESSCTLCARD_SEX emSex;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szRole;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szProjectNo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szProjectName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szBuilderName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szBuilderID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szBuilderType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] szBuilderTypeID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szPictureID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szContractID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] szWorkerTypeID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szWorkerTypeName;

	public bool bPersonStatus;

	public EM_ACCESSCTLCARD_AUTHORITY emAuthority;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
	public byte[] szCompanionName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
	public byte[] szCompanionCompany;

	public NET_TIME stuTmpAuthBeginTime;

	public NET_TIME stuTmpAuthEndTime;

	public bool bFloorNoExValid;

	public int nFloorNumEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szFloorNoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSubUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPhoneNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPhotoPath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCause;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCompanionCard;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCitizenAddress;

	public NET_TIME stuBirthDay;

	public bool bFloorNoEx2Valid;

	public IntPtr pstuFloorsEx2;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szDefaultFloor;

	public int nUserTimeSectionNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 120)]
	public string szUserTimeSections;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szWorkClass;

	public NET_TIME stuStartTimeInPeriodOfValidity;

	public EM_TEST_ITEMS emTestItems;

	public uint nAuthOverdueTime;

	public EM_GREENCNHEALTH_STATUS emGreenCNHealthStatus;

	public EM_ALLOW_PERMIT_FLAG emAllowPermitFlag;

	public EM_RENT_STATE emRentState;

	public int nConsumptionTimeSectionsNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1428)]
	public string szConsumptionTimeSections;
}
