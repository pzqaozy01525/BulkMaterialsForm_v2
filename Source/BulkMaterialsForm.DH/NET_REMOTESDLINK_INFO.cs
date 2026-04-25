// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_REMOTESDLINK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_REMOTESDLINK_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSDLinkIP;

	public bool bRadarLink;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 476)]
	public byte[] byReserved;
}
