// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_RADAR_REGIONDETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_RADAR_REGIONDETECTION_INFO
{
	public int nAction;

	public NET_TIME_EX stuTime;

	public int nChannelID;

	public int nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_RADAR_DETECT_OBJECT[] stuObjects;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public int nPresetID;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	public EM_RADAR_ALARM_TYPE emAlarmType;

	public int nLongitude;

	public int nLatitude;

	public uint nRuleID;

	public int nCardNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_RADAR_REGIONDETECTION_RFIDCARD_INFO[] stuCardInfo;

	public uint nAlarmLevel;

	public int nAlarmFlag;

	public int nAlarmChannel;

	public uint nEventID;

	public int nSpeed;

	public int nTrackID;

	public int nObjectType;

	public int nUpDownGoing;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
	public string byReserved;
}
