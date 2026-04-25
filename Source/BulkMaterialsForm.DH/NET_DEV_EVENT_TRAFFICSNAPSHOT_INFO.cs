// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFICSNAPSHOT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFICSNAPSHOT_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserv;

	public byte bCarWayCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CARWAY_INFO[] stuCarWayInfo;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public uint dwSnapFlagMask;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 344)]
	public byte[] bReserved;

	public NET_EVENT_COMM_INFO stCommInfo;
}
