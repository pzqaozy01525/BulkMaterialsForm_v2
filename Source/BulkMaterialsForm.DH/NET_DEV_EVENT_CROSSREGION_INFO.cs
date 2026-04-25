// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_CROSSREGION_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_CROSSREGION_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved2;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public NET_EVENT_FILE_INFO stuFileInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectRegion;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] TrackLine;

	public int nTrackLineNum;

	public byte bEventAction;

	public byte bDirection;

	public byte bActionType;

	public byte byImageIndex;

	public uint dwSnapFlagMask;

	public int nSourceIndex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szSourceDevice;

	public uint nOccurrenceCount;

	public NET_CUSTOM_INFO stuCustom;

	public NET_EXTENSION_INFO stuExtensionInfo;

	public uint nRuleID;

	public NET_PRESET_POSITION stPosition;

	public uint nVisibleHFOV;

	public uint nVisibleVFOV;

	public uint nCurChannelHFOV;

	public uint nCurChannelVFOV;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRealEventType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 264)]
	public byte[] bReserved;

	public int nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_MSG_OBJECT[] stuObjectIDs;

	public int nTrackNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_POLY_POINTS[] stuTrackInfo;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	public uint nObjetcHumansNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_VAOBJECT_NUMMAN[] stuObjetcHumans;

	public NET_MSG_OBJECT stuVehicle;

	public EM_TRIGGER_TYPE emTriggerType;

	public int nMark;

	public int nSource;

	public int nFrameSequence;

	public EM_CAPTURE_PROCESS_END_TYPE emCaptureProcess;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public NET_EVENT_COMM_INFO stuCommInfo;

	public NET_PTZSPACE_UNNORMALIZED stuAbsPosition;

	public int nHFovValue;

	public double dbFocusPosition;

	public uint nObjectBoatNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_BOAT_OBJECT[] stuBoatObject;

	public int nImageNum;

	public IntPtr pImageArray;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
