// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_STORAGE_FAILURE_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_STORAGE_FAILURE_EX
{
	public uint dwSize;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDevice;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szGroup;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szPath;

	public EM_STORAGE_ERROR emError;

	public int nPhysicNo;

	public NET_TIME_EX stuTime;

	public NET_GPS_STATUS_INFO stGPSStatus;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
