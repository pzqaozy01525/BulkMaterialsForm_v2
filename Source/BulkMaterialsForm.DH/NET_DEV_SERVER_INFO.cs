// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_SERVER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_SERVER_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szServerIp;

	public int nServerPort;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved;

	public byte bServerIpExEn;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
	public string szServerIpEx;
}
