// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_TRAFFICACCIDENT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_TRAFFICACCIDENT_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_MSG_OBJECT[] stuObjectIDs;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public uint dwSnapFlagMask;

	public NET_EVENT_TRAFFIC_CAR_PART_INFO stuTrafficCarPartInfo;

	public uint nLane;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 460)]
	public byte[] bReserved;
}
