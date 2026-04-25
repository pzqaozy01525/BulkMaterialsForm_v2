// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BUS_FIRE_PRESSURE_ALARM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BUS_FIRE_PRESSURE_ALARM_INFO
{
	public int nAction;

	public uint nTime;

	public double dbFirePressureThreshold;

	public double dbFirePressureValue;

	public NET_TIME stuTime;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string byReserved;
}
