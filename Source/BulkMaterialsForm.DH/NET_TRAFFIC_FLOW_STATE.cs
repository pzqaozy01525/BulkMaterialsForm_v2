// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFIC_FLOW_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFIC_FLOW_STATE
{
	public int nLane;

	public uint dwState;

	public uint dwFlow;

	public uint dwPeriod;

	public NET_TRAFFIC_FLOWSTAT_INFO_DIR stTrafficFlowDir;

	public int nVehicles;

	public float fAverageSpeed;

	public float fAverageLength;

	public float fTimeOccupyRatio;

	public float fSpaceOccupyRatio;

	public float fSpaceHeadway;

	public float fTimeHeadway;

	public float fDensity;

	public int nOverSpeedVehicles;

	public int nUnderSpeedVehicles;

	public int nLargeVehicles;

	public int nMediumVehicles;

	public int nSmallVehicles;

	public int nMotoVehicles;

	public int nLongVehicles;

	public int nVolume;

	public int nFlowRate;

	public int nBackOfQueue;

	public int nTravelTime;

	public int nDelay;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] byDirection;

	public byte byDirectionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] reserved1;

	public EM_NET_TRAFFIC_JAM_STATUS emJamState;

	public int nPassengerCarVehicles;

	public int nLargeTruckVehicles;

	public int nMidTruckVehicles;

	public int nSaloonCarVehicles;

	public int nMicrobusVehicles;

	public int nMicroTruckVehicles;

	public int nTricycleVehicles;

	public int nMotorcycleVehicles;

	public int nPasserbyVehicles;

	public EM_NET_TRAFFIC_ROAD_RANK emRank;

	public int nState;

	public bool bOccupyHeadCoil;

	public bool bOccupyTailCoil;

	public bool bStatistics;

	public int nLeftVehicles;

	public int nRightVehicles;

	public int nStraightVehicles;

	public int nUTurnVehicles;

	public NET_POINT stQueueEnd;

	public double dBackOfQueue;

	public uint dwPeriodByMili;

	public int nBusVehicles;

	public int nMPVVehicles;

	public int nMidPassengerCarVehicles;

	public int nMiniCarriageVehicles;

	public int nOilTankTruckVehicles;

	public int nPickupVehicles;

	public int nSUVVehicles;

	public int nSUVorMPVVehicles;

	public int nTankCarVehicles;

	public int nUnknownVehicles;

	public EM_NET_FLOW_ATTRIBUTE emCustomFlowAttribute;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 720)]
	public byte[] reserved;
}
