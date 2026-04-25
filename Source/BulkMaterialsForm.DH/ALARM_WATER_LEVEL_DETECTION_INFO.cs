// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.ALARM_WATER_LEVEL_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct ALARM_WATER_LEVEL_DETECTION_INFO
{
	public int nAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] reserved1;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nChannel;

	public int nEventID;

	public int nPresetID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPresetName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szObjectUUID;

	public NET_EM_EVENT_DATA_TYPE emEventType;

	public NET_EM_WATER_LEVEL_STATUS emStatus;

	public NET_WATER_RULER stuWaterRuler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
