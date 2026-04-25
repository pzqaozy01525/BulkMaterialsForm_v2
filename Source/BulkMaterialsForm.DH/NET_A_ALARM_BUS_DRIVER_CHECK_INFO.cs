// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BUS_DRIVER_CHECK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BUS_DRIVER_CHECK_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCarNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szDriverName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDriverID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szOrganize;

	public NET_TIME_EX stUsefulLife;

	public NET_GPS_STATUS_INFO stGPSStatusInfo;

	public NET_TIME_EX stCheckTime;

	public EM_A_NET_DRIVER_CHECK_METHOD emCheckMethod;

	public EM_A_NET_DRIVER_CHECK_TYPE emCheckType;
}
