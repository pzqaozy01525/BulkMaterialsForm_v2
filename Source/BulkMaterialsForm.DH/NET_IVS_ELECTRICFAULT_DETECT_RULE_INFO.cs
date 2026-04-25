// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IVS_ELECTRICFAULT_DETECT_RULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IVS_ELECTRICFAULT_DETECT_RULE_INFO
{
	public bool bAirborneDetectEnable;

	public bool bNestDetectEnable;

	public bool bDialDetectEnable;

	public bool bLeakageDetectEnable;

	public bool bDoorDetectEnable;

	public bool bRespiratorDetectEnable;

	public bool bSmokingDetectEnable;

	public bool bInsulatorDetectEnable;

	public bool bCoverPlateDetectEnable;

	public bool bPressingPlateDetectEnable;

	public bool bMetalCorrosionEnable;

	public bool bSizeFileter;

	public NET_CFG_SIZEFILTER_INFO stuSizeFileter;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINTCOORDINATE[] stuDetectRegion;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string bReserved;
}
