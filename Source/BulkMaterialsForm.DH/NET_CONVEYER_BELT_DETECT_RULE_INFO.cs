// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CONVEYER_BELT_DETECT_RULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CONVEYER_BELT_DETECT_RULE_INFO
{
	public int nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINTCOORDINATE[] stuDetectRegion;

	public EM_CONVEYER_BELT_DETECT_TYPE emDetectType;

	public uint nMinDuration;

	public uint nReportInterval;

	public uint nSensitivity;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public NET_POINTCOORDINATE[] stuComparetLine;

	public uint nSizeFilterThreshold;

	public uint nWarningThreshold;

	public uint nDowntimeThreshold;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public NET_COAL_RATIO_LEVEL[] stuCoalRatioLevel;

	public int nCoalRatioLevelNums;

	public uint nClogThreshold;

	public uint nIsMoveAlarm;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4048)]
	public byte[] byReserved;
}
