// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_IVS_CLIMB_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_IVS_CLIMB_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_RESOLUTION_INFO stuResolution;

	public int nDetectLineNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectLine;

	public byte bEventAction;

	public byte byImageIndex;

	public uint nOccurrenceCount;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 890)]
	public byte[] bReserved;
}
