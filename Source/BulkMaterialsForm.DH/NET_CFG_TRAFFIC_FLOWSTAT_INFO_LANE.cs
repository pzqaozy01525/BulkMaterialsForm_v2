// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TRAFFIC_FLOWSTAT_INFO_LANE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TRAFFIC_FLOWSTAT_INFO_LANE
{
	public byte abEnable;

	public byte bEnable;

	public NET_CFG_TRAFFIC_FLOWSTAT_ALARM_INFO stuAlarmUpperInfo;

	public NET_CFG_TRAFFIC_FLOWSTAT_ALARM_INFO stuAlarmLowInfo;

	public int nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYGON[] stuDetectRegion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public int nPresetID;

	public bool bIsDetectLine;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public NET_CFG_POLYGON[] stuDetectLine;
}
