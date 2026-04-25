// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IVS_DIALRECOGNITION_RULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IVS_DIALRECOGNITION_RULE_INFO
{
	public EM_DIALDETECT_TYPE emType;

	public bool bSizeFileter;

	public NET_CFG_SIZEFILTER_INFO stuSizeFileter;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINTCOORDINATE[] stuDetectRegion;

	public int nDetectRegionNum;

	public int nKinfeOpenAngleThreshold;

	public int nKinfeClossAngleThreshold;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2044)]
	public string bReserved;
}
