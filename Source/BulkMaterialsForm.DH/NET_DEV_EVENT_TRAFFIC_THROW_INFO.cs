// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_THROW_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_THROW_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] bReserved1;

	public uint PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_RESOLUTION_INFO stuResolution;

	public uint dwSnapFlagMask;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserved2;

	public byte byImageIndex;

	public int nLane;

	public NET_MSG_OBJECT stuObject;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public NET_EVENT_TRAFFIC_CAR_PART_INFO stuTrafficCarPartInfo;

	public NET_GPS_INFO stuGPSInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 340)]
	public byte[] bReserved;

	public NET_EVENT_COMM_INFO stCommInfo;
}
