// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_UTURN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_UTURN_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nLane;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nSequence;

	public int nSpeed;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public NET_GPS_INFO stuGPSInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 968)]
	public byte[] bReserved;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public NET_EVENT_COMM_INFO stCommInfo;

	public NET_VA_OBJECT_NONMOTOR stuNonMotor;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
