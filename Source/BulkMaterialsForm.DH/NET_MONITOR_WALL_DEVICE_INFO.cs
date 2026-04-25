// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MONITOR_WALL_DEVICE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MONITOR_WALL_DEVICE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPassword;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szUserName;

	public uint nPort;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
