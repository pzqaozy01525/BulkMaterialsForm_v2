// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IPADDRESS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IPADDRESS
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szIP;
}
