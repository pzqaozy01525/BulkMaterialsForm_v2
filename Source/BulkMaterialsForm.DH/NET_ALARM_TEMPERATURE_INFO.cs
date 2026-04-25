// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_TEMPERATURE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_TEMPERATURE_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSensorName;

	public int nChannelID;

	public int nAction;

	public float fTemperature;

	public NET_TIME stTime;

	public NET_GPS_STATUS_INFO stuGPSStatus;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
