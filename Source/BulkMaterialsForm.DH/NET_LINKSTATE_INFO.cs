// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_LINKSTATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_LINKSTATE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSDLinkIP;

	public NET_EM_RADAR_LINK_SD_STATE emState;

	public int nVirtualChannel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
