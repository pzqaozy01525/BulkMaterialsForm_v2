// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_CONVEYER_BELT_DETECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_CONVEYER_BELT_DETECT_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRuleName;

	public bool bRuleEnable;

	public int nObjectTypeNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szObjectTypes;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;

	public int nPtzPresetId;

	public int nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYGON[] stuDetectRegion;

	public EM_CFG_CONVEYER_BELT_DETECT_TYPE emDetectType;

	public uint nMinDuration;

	public uint nReportInterval;

	public uint nSensitivity;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public NET_CFG_POLYLINE[] stuComparetLine;

	public uint nSizeFilterThreshold;

	public uint nWarningThreshold;

	public uint nDowntimeThreshold;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public NET_CFG_COAL_RATIO_LEVEL[] stuCoalRatioLevel;

	public int nCoalRatioLevelNums;

	public uint nClogThreshold;

	public uint nIsMoveAlarm;

	public uint nRunOffFlag;

	public EM_CFG_ARTICLE_TYPE emArticleType;

	public uint nConveyorBeltWidth;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4036)]
	public byte[] byReserved;
}
