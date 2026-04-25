// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_CONGESTION_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_CONGESTION_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public EM_CLASS_TYPE emClassType;

	public uint nEventID;

	public uint nRuleID;

	public int nPresetID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPresetName;

	public int nAlarmMask;

	public int nVehicleQuantity;

	public int nQueueLength;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_POINT[] stuDetectRegion;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
