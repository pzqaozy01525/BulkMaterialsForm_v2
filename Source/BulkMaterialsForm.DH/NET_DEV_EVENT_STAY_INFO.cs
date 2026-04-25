// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_STAY_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_STAY_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectRegion;

	public uint dwSnapFlagMask;

	public int nSourceIndex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szSourceDevice;

	public uint nOccurrenceCount;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public int nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_MSG_OBJECT[] stuObjectIDs;

	public uint nAreaID;

	public bool bIsCompliant;

	public NET_A_PTZ_PRESET_UNIT stPosition;

	public uint nCurChannelHFOV;

	public uint nCurChannelVFOV;

	public NET_SCENE_IMAGE_INFO stuSceneImage;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_LINK_INFO stuLinkInfo;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	public IntPtr pstuBoatObject;

	public int nBoatObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 616)]
	public byte[] bReserved;
}
