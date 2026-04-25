// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_DETECT_REGIONS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_DETECT_REGIONS_INFO
{
	public bool bEnable;

	public int nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYGON[] stuDetectRegion;
}
