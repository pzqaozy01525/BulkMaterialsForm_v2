// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_CROSSLINE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_CROSSLINE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRuleName;

	public byte bRuleEnable;

	public byte bTrackEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserved;

	public int nObjectTypeNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szObjectTypes;

	public int nDirection;

	public int nDetectLinePoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYLINE[] stuDetectLine;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;

	public bool bDisableTimeSection;

	public int nPtzPresetId;

	public bool bSizeFileter;

	public NET_CFG_SIZEFILTER_INFO_EX stuSizeFileter;

	public int nTriggerPosition;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] bTriggerPosition;

	public int nTrackDuration;

	public uint nVehicleSubTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public EM_CFG_CATEGORY_TYPE[] emVehicleSubType;

	public bool bFeatureEnable;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuRemoteEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
	public NET_CFG_TIME_SECTION[] stuRemoteTimeSection;

	public bool bDisableRemoteTimeSection;

	public bool bObjectFilter;

	public NET_CFG_OBJECT_FILTER_INFO stuObjectFilter;
}
