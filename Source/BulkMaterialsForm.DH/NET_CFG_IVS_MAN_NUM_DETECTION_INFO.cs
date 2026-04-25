// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_IVS_MAN_NUM_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_IVS_MAN_NUM_DETECTION_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szRuleName;

	public bool bRuleEnable;

	public byte bTrackEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved1;

	public int nObjectTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_OBJECT_LIST_SIZE_ARRAY[] szObjectTypes;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	public NET_WEEK_TSECT_ARRAY[] stuWeekTsectArray;

	public int nPtzPresetId;

	public int nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYGON[] stuDetectRegion;

	public int nThreshold;

	public int nDetectType;

	public int nSensitivity;

	public int nMaxHeight;

	public int nMinHeight;

	public bool bStayDetectEnable;

	public int nStayMinDuration;

	public bool bManNumAlarmEnable;

	public uint nAreaID;

	public uint nPlanId;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 504)]
	public byte[] bReserved;
}
