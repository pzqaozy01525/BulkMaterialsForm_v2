// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_IVS_LEAVE_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_IVS_LEAVE_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_RESOLUTION_INFO stuResolution;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectRegion;

	public byte bEventAction;

	public byte byImageIndex;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public EM_LEAVEDETECTION_TRIGGER_MODE emTriggerMode;

	public EM_LEAVEDETECTION_STATE emState;

	public bool bSceneImage;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserName;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public byte[] bReserved;
}
