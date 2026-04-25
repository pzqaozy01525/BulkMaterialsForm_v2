// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public int nLane;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public int nSpeed;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1016)]
	public byte[] bReserved;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stuTrafficCar;

	public NET_EVENT_COMM_INFO stCommInfo;
}
