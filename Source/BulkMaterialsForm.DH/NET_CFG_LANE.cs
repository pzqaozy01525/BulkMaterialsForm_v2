// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_LANE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_LANE
{
	public int nLaneId;

	public int nDirection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYLINE[] stuLeftLine;

	public int nLeftLineNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYLINE[] stuRightLine;

	public int nRightLineNum;

	public int nLeftLineType;

	public int nRightLineType;

	public bool bDriveDirectionEnable;

	public int nDriveDirectionNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szDriveDirection;

	public int nStopLineNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYLINE[] stuStopLine;

	public int nTrafficLightNumber;

	public byte abDetectLine;

	public byte abPreLine;

	public byte abPostLine;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
	public byte[] byReserved;

	public int nDetectLine;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYLINE[] stuDetectLine;

	public int nPreLine;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYLINE[] stuPreLine;

	public int nPostLine;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYLINE[] stuPostLine;

	public NET_CFG_TRAFFIC_FLOWSTAT_DIR_INFO stuTrafficFlowDir;

	public EM_LANE_RANK_TYPE emRankType;

	public uint nRoadwayNumber;
}
