// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_UPLOAD_USER_LOCK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_UPLOAD_USER_LOCK_INFO
{
	public uint dwSize;

	public int nAction;

	public NET_TIME_EX stuTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
	public string szDeviceIP;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
	public string szDeviceMac;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szGroup;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
	public string szIllegalLoginIP;
}
