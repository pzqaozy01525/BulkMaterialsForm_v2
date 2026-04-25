// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VIOLATIONCODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VIOLATIONCODE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szRetrograde;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRetrogradeDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRetrogradeShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szRetrogradeHighway;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRetrogradeHighwayDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szRunRedLight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRunRedLightDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szCrossLane;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCrossLaneDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCrossLaneShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szTurnLeft;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szTurnLeftDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szTurnRight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szTurnRightDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szU_Turn;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szU_TurnDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szU_TurnShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szJam;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szJamDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szParking;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkingDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkingShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szOverSpeed;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szOverSpeedDesc;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public NET_CFG_OVERSPEED_INFO[] stOverSpeedConfig;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szOverSpeedHighway;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szOverSpeedHighwayDesc;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public NET_CFG_OVERSPEED_INFO[] stOverSpeedHighwayConfig;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szUnderSpeed;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szUnderSpeedDesc;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public NET_CFG_OVERSPEED_INFO[] stUnderSpeedConfig;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szOverLine;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szOverLineDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szOverLineShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szOverYellowLine;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szOverYellowLineDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szYellowInRoute;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szYellowInRouteDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szWrongRoute;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szWrongRouteDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szDrivingOnShoulder;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDrivingOnShoulderDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szPassing;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPassingDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szNoPassing;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNoPassingDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szFakePlate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szFakePlateDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szParkingSpaceParking;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkingSpaceParkingDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szParkingSpaceNoParking;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkingSpaceNoParkingDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szWithoutSafeBelt;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szWithoutSafeBeltShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szWithoutSafeBeltDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szDriverSmoking;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDriverSmokingShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDriverSmokingDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szDriverCalling;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDriverCallingShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDriverCallingDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szBacking;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szBackingShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szBackingDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szVehicleInBusRoute;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szVehicleInBusRouteShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szVehicleInBusRouteDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szPedestrianRunRedLight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPedestrianRunRedLightShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPedestrianRunRedLightDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szPassNotInOrder;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPassNotInOrderShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPassNotInOrderDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szTrafficBan;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szTrafficBanShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szTrafficBanDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szParkingB;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkingBDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkingBShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szParkingC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkingCDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkingCShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szParkingD;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkingDDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkingDShowName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szNonMotorHoldUmbrella;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNonMotorHoldUmbrellaDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNonMotorHoldUmbrellaShowName;

	public int nBigCarOverSpeedConfigNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public NET_CFG_OVERSPEED_INFO[] stBigCarOverSpeedConfig;
}
