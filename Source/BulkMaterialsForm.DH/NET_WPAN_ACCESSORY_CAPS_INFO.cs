// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WPAN_ACCESSORY_CAPS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WPAN_ACCESSORY_CAPS_INFO
{
	public bool bSupportAlarmTone;

	public bool bSupportCardReader;

	public bool bSupportChime;

	public bool bSupportOverTemperatureAlarm;

	public bool bSupportExternalWifi;

	public bool bSupportWifiInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byreserve;
}
