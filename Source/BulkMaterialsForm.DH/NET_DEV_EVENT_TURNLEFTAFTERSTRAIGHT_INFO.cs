// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TURNLEFTAFTERSTRAIGHT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TURNLEFTAFTERSTRAIGHT_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string Reserved;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public int nLane;

	public int nSequence;

	public byte byEventAction;

	public byte byImageIndex;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved1;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public NET_GPS_INFO stuGPSInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 984)]
	public byte[] byReserved;

	public NET_EVENT_COMM_INFO stCommInfo;
}
