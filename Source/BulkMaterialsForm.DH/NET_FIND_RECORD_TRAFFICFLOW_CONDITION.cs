// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FIND_RECORD_TRAFFICFLOW_CONDITION

namespace BulkMaterialsForm.DH;

public struct NET_FIND_RECORD_TRAFFICFLOW_CONDITION
{
	public uint dwSize;

	public bool abChannelId;

	public int nChannelId;

	public bool abLane;

	public int nLane;

	public bool bStartTime;

	public NET_TIME stStartTime;

	public bool bEndTime;

	public NET_TIME stEndTime;

	public bool bStatisticsTime;
}
