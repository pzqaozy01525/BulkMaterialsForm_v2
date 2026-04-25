// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_EVENT_LEFT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_EVENT_LEFT_INFO
{
	public uint dwSize;

	public int nChannelID;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nEventAction;

	public int nOccurrenceCount;

	public int nLevel;

	public short nPreserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPresetName;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
