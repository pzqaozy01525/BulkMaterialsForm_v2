// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEVICE_NET_INFO_EX2

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEVICE_NET_INFO_EX2
{
	public DEVICE_NET_INFO_EX stuDevInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szLocalIp;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
	public byte[] cReserved;
}
