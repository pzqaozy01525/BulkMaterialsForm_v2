// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_DRIVER_CALLING

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_DRIVER_CALLING
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public int nTriggerType;

	public uint PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nSequence;

	public byte byEventAction;

	public byte byImageIndex;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved1;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nLane;

	public int nMark;

	public int nFrameSequence;

	public int nSource;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stuTrafficCar;

	public int nSpeed;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public NET_EVENT_COMM_INFO stCommInfo;

	public NET_GPS_INFO stuGPSInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDriverID;

	public int nRelatingVideoInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_RELATING_VIDEO_INFO[] stuRelatingVideoInfo;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 952)]
	public byte[] byReserved;
}
