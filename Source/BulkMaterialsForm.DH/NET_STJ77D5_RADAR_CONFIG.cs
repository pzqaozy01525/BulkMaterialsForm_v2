// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_STJ77D5_RADAR_CONFIG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_STJ77D5_RADAR_CONFIG
{
	public uint nLaneNumber;

	public uint nDetectMode;

	public double dbHeight;

	public double dbHorizonShift;

	public int nLaneCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public double[] dbLaneWidth;

	public double dbStopLine;

	public uint nSceneMode;

	public double dbShiftAngle;

	public double dbLengthwayShiftDistance;

	public double dbSensitive;

	public uint nIDset;

	public uint nWorkMode;

	public uint nRadarFlowTime;

	public uint nRadarFlowSwitch;

	public uint nNonMotorDiscern;

	public uint nVehicleDistinguish;

	public uint nStopTargetDisappearTime;

	public uint nStartLane;

	public uint nRadarLanNumber;

	public uint nVirtualCoilTriggerCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public uint[] nVirtualCoilTrigger;

	public uint nVirtualCoilDistanceCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public double[] dbVirtualCoilDistance;

	public uint nVirtualCoilLengthCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public double[] dbVirtualCoilLength;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public uint[] nLaneDirection;

	public double dbCameraToRoadEndDistance;

	public double dbCameraToStopLane;

	public uint nLaneDirectionCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] bReserved;
}
