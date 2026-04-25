// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_SERVER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_SERVER_INFO
{
	public int nPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szAddress;
}
