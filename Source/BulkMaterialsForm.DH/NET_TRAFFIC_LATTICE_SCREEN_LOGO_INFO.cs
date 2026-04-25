// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFIC_LATTICE_SCREEN_LOGO_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFIC_LATTICE_SCREEN_LOGO_INFO
{
	public EM_A_NET_EM_LATTICE_SCREEN_LOGO_TYPE emLogoType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szContent;
}
