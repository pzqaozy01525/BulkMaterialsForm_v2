// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_FLOWBUSINESS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_FLOWBUSINESS_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectRegion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPresetName;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public uint nViolationDuration;

	public int nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
	public NET_MSG_OBJECT[] stuObjects;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSourceID;

	public uint dwSnapFlagMask;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2044)]
	public byte[] byReserved;
}
