// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORD_TRAFFIC_FLOW_STATE

namespace BulkMaterialsForm.DH;

public struct NET_RECORD_TRAFFIC_FLOW_STATE
{
	public uint dwSize;

	public int nRecordNum;

	public int nChannel;

	public int nLane;

	public int nVehicles;

	public float fAverageSpeed;

	public float fTimeOccupyRatio;

	public float fSpaceOccupyRatio;

	public float fSpaceHeadway;

	public float fTimeHeadway;

	public int nLargeVehicles;

	public int nMediumVehicles;

	public int nSmallVehicles;

	public float fBackOfQueue;

	public int nPasserby;
}
