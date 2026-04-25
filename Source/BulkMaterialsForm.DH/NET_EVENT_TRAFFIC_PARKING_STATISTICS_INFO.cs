// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_TRAFFIC_PARKING_STATISTICS_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_TRAFFIC_PARKING_STATISTICS_INFO
{
	public int nAction;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public NET_AREA_MODE_INFO[] stuAreaModeInfo;

	public int nAreaModeInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 99)]
	public NET_SPACE_MODE_INFO[] stuSpaceModeInfo;

	public int nSpaceModeInfoNum;

	public EM_STATISTICS_MODE emStatisticsMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 99)]
	public NET_UPDATE_INFO[] stuUpdateInfo;

	public int nUpdateInfoNum;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1008)]
	public byte[] byReserved;
}
