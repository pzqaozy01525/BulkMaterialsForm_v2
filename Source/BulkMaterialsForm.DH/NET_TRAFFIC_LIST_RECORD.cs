// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFIC_LIST_RECORD

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFIC_LIST_RECORD
{
	public uint dwSize;

	public int nRecordNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szMasterofCar;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateNumber;

	public EM_NET_PLATE_TYPE emPlateType;

	public EM_NET_PLATE_COLOR_TYPE emPlateColor;

	public EM_NET_VEHICLE_TYPE emVehicleType;

	public EM_NET_VEHICLE_COLOR_TYPE emVehicleColor;

	public NET_TIME stBeginTime;

	public NET_TIME stCancelTime;

	public int nAuthrityNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_AUTHORITY_TYPE[] stAuthrityTypes;

	public EM_NET_TRAFFIC_CAR_CONTROL_TYPE emControlType;
}
