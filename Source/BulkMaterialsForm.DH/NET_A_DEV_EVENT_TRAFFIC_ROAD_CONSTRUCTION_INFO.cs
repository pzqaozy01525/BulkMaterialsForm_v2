// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_TRAFFIC_ROAD_CONSTRUCTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_TRAFFIC_ROAD_CONSTRUCTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_RECT stuBoundingBox;

	public uint nLane;

	public NET_EVENT_COMM_INFO stCommInfo;

	public uint dwSnapFlagMask;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4092)]
	public byte[] bReserved;
}
