// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_VEHICLE_IN_EMERGENCY_LANE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_VEHICLE_IN_EMERGENCY_LANE_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public uint PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nLane;

	public NET_MSG_OBJECT stuObject;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	public NET_MSG_OBJECT stuVehicle;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stuTrafficCar;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved2;

	public NET_VA_OBJECT_NONMOTOR stuNonMotor;

	public int nSequence;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_EVENT_COMM_INFO stuCommInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
