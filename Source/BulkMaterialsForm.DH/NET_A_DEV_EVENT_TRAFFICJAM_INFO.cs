// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_TRAFFICJAM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_TRAFFICJAM_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nLane;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte bEventAction;

	public byte bJamLenght;

	public byte reserved;

	public byte byImageIndex;

	public NET_TIME_EX stuStartJamTime;

	public int nSequence;

	public int nAlarmIntervalTime;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public int nJamRealLength;

	public NET_EXTENSION_INFO stuExtensionInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 876)]
	public byte[] bReserved;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public NET_EVENT_COMM_INFO stCommInfo;
}
