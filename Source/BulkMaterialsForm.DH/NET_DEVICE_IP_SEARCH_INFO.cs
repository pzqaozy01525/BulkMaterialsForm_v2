// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEVICE_IP_SEARCH_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEVICE_IP_SEARCH_INFO
{
	public uint dwSize;

	public int nIpNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_IPADDRESS[] szIPs;
}
