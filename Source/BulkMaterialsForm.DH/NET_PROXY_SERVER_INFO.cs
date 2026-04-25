// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PROXY_SERVER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PROXY_SERVER_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
	public string szIP;

	public uint nPort;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
	public byte[] byReserved;
}
