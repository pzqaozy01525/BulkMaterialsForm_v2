// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_GPS_LOCATION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_GPS_LOCATION_INFO
{
	public NET_GPS_Info stuGpsInfo;

	public NET_ALARM_STATE_INFO stuAlarmStateInfo;

	public int nTemperature;

	public int nHumidity;

	public uint nIdleTime;

	public uint nMileage;

	public int nVoltage;

	public byte bOffline;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1023)]
	public byte[] byReserved;
}
