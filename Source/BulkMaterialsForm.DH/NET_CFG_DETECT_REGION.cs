// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_DETECT_REGION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_DETECT_REGION
{
	public int nRegionID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRegionName;

	public int nThreshold;

	public int nSenseLevel;

	public int nMotionRow;

	public int nMotionCol;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byRegion;
}
