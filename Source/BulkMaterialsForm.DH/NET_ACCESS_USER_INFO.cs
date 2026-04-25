// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESS_USER_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESS_USER_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szName;

	public EM_A_NET_ENUM_USER_TYPE emUserType;

	public uint nUserStatus;

	public int nUserTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCitizenIDNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPsw;

	public int nDoorNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nDoors;

	public int nTimeSectionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nTimeSectionNo;

	public int nSpecialDaysScheduleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] nSpecialDaysSchedule;

	public NET_TIME stuValidBeginTime;

	public NET_TIME stuValidEndTime;

	public bool bFirstEnter;

	public int nFirstEnterDoorsNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nFirstEnterDoors;

	public EM_ATTENDANCE_AUTHORITY emAuthority;

	public int nRepeatEnterRouteTimeout;

	public int nFloorNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szFloorNo;

	public int nRoom;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szRoomNo;

	public bool bFloorNoExValid;

	public int nFloorNumEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szFloorNoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szClassInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szStudentNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCitizenAddress;

	public NET_TIME stuBirthDay;

	public NET_ACCESSCTLCARD_SEX emSex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDepartment;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSiteCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPhoneNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szDefaultFloor;

	public bool bFloorNoEx2Valid;

	public IntPtr pstuFloorsEx2;

	public bool bHealthStatus;

	public int nUserTimeSectionsNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 120)]
	public string szUserTimeSections;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szECType;

	public EM_TYPE_OF_CERTIFICATE emTypeOfCertificate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szCountryOrAreaCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCountryOrAreaName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCertificateVersionNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szApplicationAgencyCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szIssuingAuthority;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szStartTimeOfCertificateValidity;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szEndTimeOfCertificateValidity;

	public int nSignNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 108)]
	public string szActualResidentialAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szWorkClass;

	public NET_TIME stuStartTimeInPeriodOfValidity;

	public EM_TEST_ITEMS emTestItems;

	public bool bUseNameEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szNameEx;

	public bool bUserInfoExValid;

	public IntPtr pstuUserInfoEx;

	public uint nAuthOverdueTime;

	public EM_GREENCNHEALTH_STATUS emGreenCNHealthStatus;

	public EM_ALLOW_PERMIT_FLAG emAllowPermitFlag;

	public int nHolidayGroupIndex;

	public NET_TIME stuUpdateTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 192)]
	public string szValidFroms;

	public int nValidFromsNum;

	public int nValidTosNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 192)]
	public string szValidTos;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserIDEx;

	public bool bUserIDEx;

	public int nFinancialUserType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 740)]
	public byte[] byReserved;
}
