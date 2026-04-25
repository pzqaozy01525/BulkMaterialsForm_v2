// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_CROWD_DETECTION_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_CROWD_DETECTION_INFO
{
	public int nChannelID;

	public int nEventID;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventAction;

	public EM_ALARM_TYPE emAlarmType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public int nCrowdListNum;

	public int nRegionListNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public NET_CROWD_LIST_INFO[] stuCrowdList;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_REGION_LIST_INFO[] stuRegionList;

	public NET_EXTENSION_INFO stuExtensionInfo;

	public int nCrowdRectListNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public NET_CROWD_RECT_LIST_INFO[] stuCrowdRectList;

	public int nGlobalPeopleNum;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 680)]
	public byte[] byReserved;
}
