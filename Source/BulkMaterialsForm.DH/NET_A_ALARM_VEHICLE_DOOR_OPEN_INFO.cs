// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_VEHICLE_DOOR_OPEN_INFO

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_VEHICLE_DOOR_OPEN_INFO
{
	public uint dwSize;

	public EM_A_NET_ACCESS_CTL_STATUS_TYPE emStatus;

	public int nDoor;

	public NET_TIME stuTime;

	public int nTime;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public EM_VEHICLE_DATA_TYPE emDataType;

	public bool bNeedConfirm;
}
