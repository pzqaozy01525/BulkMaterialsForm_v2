// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CTRL_SET_PARK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CTRL_SET_PARK_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPlateNumber;

	public uint nParkTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szMasterofCar;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserType;

	public uint nRemainDay;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szParkCharge;

	public uint nRemainSpace;

	public uint nPassEnable;

	public NET_TIME stuInTime;

	public NET_TIME stuOutTime;

	public EM_CARPASS_STATUS emCarStatus;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCustom;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSubUserType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRemarks;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szResource;

	public uint nParkTimeout;
}
