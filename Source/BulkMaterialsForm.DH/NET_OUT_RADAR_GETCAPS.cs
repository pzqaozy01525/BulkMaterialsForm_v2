// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_RADAR_GETCAPS

namespace BulkMaterialsForm.DH;

public struct NET_OUT_RADAR_GETCAPS
{
	public uint dwSize;

	public int nDetectionRange;

	public int nDetectionAngle;

	public int nDetectionHuman;

	public bool bExValid;

	public NET_RADAR_CAPACITY_CAP stuCapacityCap;

	public NET_RADAR_SCENE_CAP stuSceneCap;

	public NET_RADAR_CHANNEL_CAP stuChannelCap;

	public NET_RADAR_MOVEDDETECT_CAP stuMovedDetectCap;

	public NET_RADAR_PROTOCAL_CAP stuProtocalCap;

	public EM_RADAR_GETCAPS_AREASUB_TYPE emAreaSubType;

	public EM_RADAR_GETCAPS_RADAR_TYPE emRadarType;
}
