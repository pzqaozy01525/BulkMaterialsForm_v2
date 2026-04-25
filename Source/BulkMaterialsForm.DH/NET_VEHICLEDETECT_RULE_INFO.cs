// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VEHICLEDETECT_RULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VEHICLEDETECT_RULE_INFO
{
	public uint dwSize;

	public int nSnapThreshold;

	public uint nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINTCOORDINATE[] stuDetectRegion;

	public int nExcludeRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_POLY_POINTS[] stuExcludeRegion;

	public NET_COMPLIANT_INFO stuCompliant;

	public bool bFeatureExtractEnable;

	public bool bSizeFileter;

	public NET_CFG_SIZEFILTER_INFO stuSizeFileter;
}
