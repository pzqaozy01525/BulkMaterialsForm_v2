// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_SMOKE_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_SMOKE_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public uint nRuleID;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public uint dwSnapFlagMask;

	public uint nOccurrenceCount;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public NET_PTZ_SPACE_UNIT stuPtzPosition;

	public bool bSceneImage;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	public NET_MSG_OBJECT stuVehicle;

	public EM_TRIGGER_TYPE emTriggerType;

	public int nMark;

	public int nSource;

	public int nFrameSequence;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public NET_EVENT_COMM_INFO stuCommInfo;

	public EM_CAPTURE_PROCESS_END_TYPE emCaptureProcess;

	public uint nCurChannelHFOV;

	public uint nCurChannelVFOV;

	public NET_GPS_INFO_EX stuGPS;

	public int nObjectCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_A_MSG_OBJECT_EX2[] stuObjects;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public EM_SMOKE_COLOR[] emSmokeColor;

	public int nSmokeColorNum;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 944)]
	public string szReserved;
}
