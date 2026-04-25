// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DETECTOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DETECTOR_INFO
{
	public int nDetectBreaking;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public NET_COILCONFIG_INFO[] arstCoilCfg;

	public int nRoadwayNumber;

	public int nRoadwayDirection;

	public int nRedLightCardNum;

	public int nCoilsNumber;

	public int nOperationType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public int[] arnCoilsDistance;

	public int nCoilsWidth;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public int[] arnSmallCarSpeedLimit;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public int[] arnBigCarSpeedLimit;

	public int nOverSpeedMargin;

	public int nBigCarOverSpeedMargin;

	public int nUnderSpeedMargin;

	public int nBigCarUnderSpeedMargin;

	public byte bSpeedLimitForSize;

	public byte bMaskRetrograde;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 768)]
	public string szDrivingDirection;

	public int nOverPercentage;

	public int nCarScheme;

	public int nSigScheme;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public int[] nYellowSpeedLimit;

	public int nRoadType;

	public int nSnapMode;

	public int nDelayMode;

	public int nDelayTime;

	public int nTriggerMode;

	public int nErrorRange;

	public double dSpeedCorrection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public int[] nDirection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
	public string szCustomParkNo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] btReserved;

	public int nCoilMap;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_COIL_MAP_INFO[] stuCoilMap;
}
