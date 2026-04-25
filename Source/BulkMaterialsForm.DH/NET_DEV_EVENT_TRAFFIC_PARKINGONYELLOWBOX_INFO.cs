// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_PARKINGONYELLOWBOX_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_PARKINGONYELLOWBOX_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string bReserved1;

	public uint PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nLane;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nInterval1;

	public int nInterval2;

	public int nFollowTime;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public NET_GPS_INFO stuGPSInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 984)]
	public byte[] bReserved;

	public NET_EVENT_COMM_INFO stCommInfo;
}
