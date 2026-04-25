// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_FLOW_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_FLOW_STATE
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] bReserved1;

	public uint PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nSequence;

	public int nStateNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_TRAFFIC_FLOW_STATE[] stuStates;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 892)]
	public byte[] bReserved;
}
