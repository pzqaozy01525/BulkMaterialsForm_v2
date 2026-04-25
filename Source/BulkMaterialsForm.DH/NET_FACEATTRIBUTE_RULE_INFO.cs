// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACEATTRIBUTE_RULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACEATTRIBUTE_RULE_INFO
{
	public int nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINTCOORDINATE[] stuDetectRegion;

	public int nMinDuration;

	public int nTriggerTargets;

	public int nSensitivity;

	public int nReportInterval;

	public bool bSizeFileter;

	public NET_CFG_SIZEFILTER_INFO stuSizeFileter;

	public int nFaceFeatureNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_FACEFEATURE_TYPE[] emFaceFeatureType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
	public byte[] byReserved;
}
