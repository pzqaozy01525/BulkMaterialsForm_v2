// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CFG_NTP_SERVER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CFG_NTP_SERVER
{
	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szAddress;

	public int nPort;
}
