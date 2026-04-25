// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_PARKING_STATISTICS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_PARKING_STATISTICS_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szStatisticsMode;

	public int nAreaModeCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_A_CFG_AREA_MODE_INFO[] stuAreaMode;

	public int nSpaceModeCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_A_CFG_SPACE_MODE_INFO[] stuSpaceMode;

	public uint nConfidenceFilter;
}
