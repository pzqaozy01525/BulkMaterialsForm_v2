// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_VEHICLE_STANDING_OVER_TIME_INFO

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_VEHICLE_STANDING_OVER_TIME_INFO
{
	public uint dwSize;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public NET_TIME_EX stuTime;

	public NET_TIME_EX stuUtc;

	public uint dwUtc;

	public bool bEventConfirm;

	public uint nParkingTime;
}
