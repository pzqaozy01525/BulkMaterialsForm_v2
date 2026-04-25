// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_WATER_LEVEL_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_WATER_LEVEL_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPresetName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szObjectUUID;

	public NET_EM_EVENT_DATA_TYPE emEventType;

	public NET_EM_WATER_LEVEL_STATUS emStatus;

	public NET_WATER_RULER stuWaterRuler;

	public NET_INTELLIGENCE_IMAGE_INFO stuOriginalImage;

	public NET_INTELLIGENCE_IMAGE_INFO stuSceneImage;

	public bool bManual;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
