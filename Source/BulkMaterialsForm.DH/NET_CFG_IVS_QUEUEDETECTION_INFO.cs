// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_IVS_QUEUEDETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_IVS_QUEUEDETECTION_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szRuleName;

	public byte bRuleEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved;

	public int nObjectTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_OBJECT_LIST_SIZE_ARRAY[] szObjectTypes;

	public int nPtzPresetId;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	public NET_WEEK_TSECT_ARRAY[] stuWeekTsectArray;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public NET_CFG_POLYLINE[] stuDetectLine;

	public int nOccupyLineMargin;

	public int nTriggerTime;

	public int nMaxDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYGON[] stuDetectRegion;

	public int nThreshold;

	public int nDetectType;

	public int nPlanID;

	public int nAreaID;

	public bool bStayDetectEnable;

	public int nStayMinDuration;

	public bool bManNumAlarmEnable;
}
