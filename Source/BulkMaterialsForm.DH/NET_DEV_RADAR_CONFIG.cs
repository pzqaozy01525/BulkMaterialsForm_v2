// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_RADAR_CONFIG

namespace BulkMaterialsForm.DH;

public struct NET_DEV_RADAR_CONFIG
{
	public uint dwSize;

	public bool bEnable;

	public int nPort;

	public NET_COMM_PROP stuCommAttr;

	public int nAddress;

	public int nPreSpeedWait;

	public int nDelaySpeedWait;

	public bool bDahuaRadarEnable;

	public NET_DEV_DAHUA_RADAR_CONFIG stuDhRadarConfig;

	public bool bSTJ77D5RadarEnable;

	public NET_STJ77D5_RADAR_CONFIG stuSTJ77D5RadarConfig;
}
