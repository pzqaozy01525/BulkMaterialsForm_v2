// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_HOTSPOT_WARNING_INFO

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_HOTSPOT_WARNING_INFO
{
	public int nAction;

	public int nChannelID;

	public NET_POINT stuCoordinate;

	public float fHotSpotValue;

	public int nTemperatureUnit;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
