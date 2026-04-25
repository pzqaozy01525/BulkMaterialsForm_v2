// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_TRAFFICFLOWSTAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_TRAFFICFLOWSTAT
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMachineAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMachineName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 96)]
	public string szDrivingDirection;

	public int nLane;

	public NET_TIME_EX UTC;

	public int nPeriod;

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

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szResvered;
}
