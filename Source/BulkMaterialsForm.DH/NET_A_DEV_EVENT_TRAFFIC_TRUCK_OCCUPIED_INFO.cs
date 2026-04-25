// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_TRAFFIC_TRUCK_OCCUPIED_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_TRAFFIC_TRUCK_OCCUPIED_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szClass;

	public int nGroupID;

	public int nCountInGroup;

	public int nIndexInGroup;

	public uint nUTCMS;

	public double dbPTS;

	public NET_TIME_EX stuUTC;

	public uint nEventID;

	public int nLane;

	public int nSequence;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved1;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stuTrafficCar;

	public NET_EVENT_COMM_INFO stuCommInfo;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public uint dwSnapFlagMask;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
