// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_OVERSTOPLINE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_OVERSTOPLINE
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

	public int nLane;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nMark;

	public int nFrameSequence;

	public int nSource;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stuTrafficCar;

	public int nSpeed;

	public NET_GPS_INFO stuGPSInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 984)]
	public byte[] byReserved;

	public NET_EVENT_COMM_INFO stCommInfo;

	public bool bHasNonMotor;

	public NET_VA_OBJECT_NONMOTOR stuNonMotor;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
