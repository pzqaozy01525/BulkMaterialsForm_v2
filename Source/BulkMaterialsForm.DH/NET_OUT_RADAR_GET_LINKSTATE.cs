// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_RADAR_GET_LINKSTATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_RADAR_GET_LINKSTATE
{
	public uint dwSize;

	public int nSDLinkNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public NET_LINKSTATE_INFO[] stuSDLinkState;
}
