// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_EVENT_CROSSLINE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_EVENT_CROSSLINE_INFO
{
	public uint dwSize;

	public int nChannelID;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nEventAction;

	public EM_CROSSLINE_DIRECTION_INFO emCrossDirection;

	public int nOccurrenceCount;

	public int nLevel;

	public bool bIsObjectInfo;

	public NET_MSG_OBJECT stuObject;

	public int nRetObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_MSG_OBJECT[] stuObjects;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
