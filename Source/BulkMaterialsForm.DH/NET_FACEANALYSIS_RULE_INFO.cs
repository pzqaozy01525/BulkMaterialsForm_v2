// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACEANALYSIS_RULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACEANALYSIS_RULE_INFO
{
	public uint dwSize;

	public int nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINTCOORDINATE[] stuDetectRegion;

	public int nSensitivity;

	public int nLinkGroupNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_LINKGROUP_INFO[] stuLinkGroup;

	public NET_CFG_STRANGERMODE_INFO_NEW stuStrangerMode;

	public bool bSizeFileter;

	public NET_CFG_SIZEFILTER_INFO stuSizeFileter;

	public bool bFeatureEnable;

	public int nFaceFeatureNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_FACEFEATURE_TYPE[] emFaceFeatureType;

	public bool bFeatureFilter;

	public int nMinQuality;
}
