// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BATTERYLOWPOWER_INFO

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BATTERYLOWPOWER_INFO
{
	public uint dwSize;

	public int nAction;

	public int nBatteryLeft;

	public NET_TIME stTime;

	public int nChannelID;

	public NET_GPS_STATUS_INFO stGPSStatus;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
