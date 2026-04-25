// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_RADAR_REGION_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_RADAR_REGION_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public uint nRuleID;

	public EM_CLASS_TYPE emClassType;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_RADAR_DETECT_OBJECT[] stuObjects;

	public int nPresetID;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	public EM_RADAR_ALARM_TYPE emAlarmType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szAlarmLevel;

	public int nAlarmChannel;

	public int nRFIDCardIdNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_RFID_CARD_INFO[] stuRFIDCardId;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_SCENE_IMAGE_INFO_EX[] stuSceneImageEx;

	public int nstuSceneImageExNum;

	public int nSpeed;

	public int nTrackID;

	public int nObjectType;

	public int nAlarmFlag;

	public int nLongitude;

	public int nLatitude;

	public int nUpDownGoing;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	public int nDistance;

	public int nAngle;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 988)]
	public byte[] byReserved;
}
