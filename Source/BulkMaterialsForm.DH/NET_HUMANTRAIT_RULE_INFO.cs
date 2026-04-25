// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HUMANTRAIT_RULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HUMANTRAIT_RULE_INFO
{
	public uint dwSize;

	public int nHumanFaceTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public EM_ANALYSE_HUMANFACE_TYPE[] emHumanFaceType;

	public int nMinDuration;

	public int nTriggerTargets;

	public int nSensitivity;

	public bool bSizeFileter;

	public NET_CFG_SIZEFILTER_INFO stuSizeFileter;

	public bool bFeatureEnable;

	public bool bFeatureFilter;

	public int nMinQuality;

	public int nFaceFeatureNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_FACEFEATURE_TYPE[] emFaceFeatureType;

	public uint nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINTCOORDINATE[] stuDetectRegion;

	public int nExcludeRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_POLY_POINTS[] stuExcludeRegion;

	public bool bFaceSnapEnable;

	public bool bFeatureExtractEnable;

	public NET_COMPLIANT_INFO stuCompliant;

	public bool bHumanFeatureEnable;

	public int nHumanFeatureList;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szHumanFeatureList;

	public bool bFaceFeatureExtractEnable;
}
