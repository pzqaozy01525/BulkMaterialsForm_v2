// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_MOTIONDETECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_MOTIONDETECT_INFO
{
	public uint dwSize;

	public int nChannelID;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nEventAction;

	public uint nRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_MOTIONDETECT_REGION_INFO[] stuRegion;

	public bool bSmartMotionEnable;

	public uint nDetectTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_MOTION_DETECT_TYPE[] emDetectType;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
