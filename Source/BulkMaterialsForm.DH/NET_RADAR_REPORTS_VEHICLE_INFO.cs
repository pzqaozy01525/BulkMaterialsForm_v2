// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_REPORTS_VEHICLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_REPORTS_VEHICLE_INFO
{
	public uint nVehicleId;

	public uint nVehicleLength;

	public uint nVehicleWidth;

	public uint nVehicleHeight;

	public uint nVehicleVolume;

	public uint nLaneID;

	public EM_VEHICLE_DRIVING_DIRECTION emDrivingDirection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDetectTime;

	public uint nVehicleRailingHigh;

	public uint nVehicleSpeed;

	public EM_RADAR_DETECTION_VEHICLE_TYPE emVehicleType;

	public uint nAxisNum;

	public uint nAxisType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	public byte[] byReserved;
}
