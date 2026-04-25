// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OPENDOOR_MATCHINFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OPENDOOR_MATCHINFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserName;

	public EM_USER_TYPE emUserType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	public uint nMatchRate;

	public EM_FACE_OPEN_DOOR_TYPE emOpenDoorType;

	public NET_TIME stuActivationTime;

	public NET_TIME stuExpiryTime;

	public int nScore;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
	public string szCompanyName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 120)]
	public string szCompanionName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
	public string szCompanionCompany;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPermissibleArea;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
	public string szSection;

	public IntPtr pstuCustomEducationInfo;

	public IntPtr pstuHealthCodeInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRoomNo;

	public IntPtr pstuIDCardInfo;

	public IntPtr pstuBusStationInfo;

	public IntPtr pstuCustomWorkerInfo;

	public bool bUseMatchInfoEx;

	public IntPtr pstuMatchInfoEx;

	public IntPtr pstuHSJCInfo;

	public IntPtr pstuVaccineInfo;

	public IntPtr pstuTravelInfo;

	public IntPtr pstuCustomVisitorInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] byReserved;
}
