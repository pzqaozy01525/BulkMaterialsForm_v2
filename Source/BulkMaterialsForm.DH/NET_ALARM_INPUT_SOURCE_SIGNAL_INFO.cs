// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_INPUT_SOURCE_SIGNAL_INFO

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_INPUT_SOURCE_SIGNAL_INFO
{
	public uint dwSize;

	public int nChannelID;

	public int nAction;

	public NET_TIME stuTime;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
