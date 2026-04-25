// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_VEHICLE_ACC_INFO

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_VEHICLE_ACC_INFO
{
	public uint dwSize;

	public int nACCStatus;

	public int nAction;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public int nConstantElectricStatus;

	public NET_TIME_EX stuTime;

	public uint nTotalMileage;

	public NET_TIME_EX stuStartTime;

	public NET_GPS_STATUS_INFO stuStartGPS;
}
