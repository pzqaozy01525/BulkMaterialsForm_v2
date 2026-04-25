// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_AUDIO_ANOMALY

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_AUDIO_ANOMALY
{
	public uint dwStructSize;

	public uint dwAction;

	public uint dwChannelID;

	public int nDecibel;

	public int nFrequency;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
