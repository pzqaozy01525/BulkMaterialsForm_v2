// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_GESTURE_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_GESTURE_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szClass;

	public double dbPTS;

	public NET_TIME_EX stuUTC;

	public uint nUTCMS;

	public uint nEventID;

	public NET_GESTURE_INFO stuGestureInfo;

	public int nGroupID;

	public int nCountInGroup;

	public int nIndexInGroup;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] szReserved;
}
