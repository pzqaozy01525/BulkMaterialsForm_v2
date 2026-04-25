// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_CROSSLINE_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_CROSSLINE_INFO
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

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectLine;

	public int nDetectLineNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] TrackLine;

	public int nTrackLineNum;

	public byte bEventAction;

	public byte bDirection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
	public byte[] byReserved;

	public byte byImageIndex;

	public uint dwSnapFlagMask;

	public int nSourceIndex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szSourceDevice;

	public uint nOccurrenceCount;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public NET_EXTENSION_INFO stuExtensionInfo;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	public uint nObjetcHumansNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_VAOBJECT_NUMMAN[] stuObjetcHumans;

	public uint nRuleID;

	public EM_EVENT_LEVEL emEventType;

	public NET_PRESET_POSITION stPosition;

	public uint nVisibleHFOV;

	public uint nVisibleVFOV;

	public uint nCurChannelHFOV;

	public uint nCurChannelVFOV;

	public int nImageNum;

	public IntPtr pImageArray;

	public int nCarMirrorStatus;

	public int nCarLightStatus;

	public uint nObjectBoatsNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_BOAT_OBJECT[] stuBoatObjects;

	public int nUpDownGoing;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 452)]
	public byte[] byReserved1;
}
