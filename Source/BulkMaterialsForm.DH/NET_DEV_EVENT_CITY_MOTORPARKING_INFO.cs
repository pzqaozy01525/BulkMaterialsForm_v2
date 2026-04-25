// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_CITY_MOTORPARKING_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_CITY_MOTORPARKING_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_MSG_OBJECT[] stuObjects;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectRegion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPresetName;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public uint nParkingDuration;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSourceID;

	public uint dwSnapFlagMask;

	public bool bPtzPosition;

	public NET_PTZ_NORMALIZED_POSITION_UNIT stuPtzPosition;

	public EM_CITYMOTOR_STATUS emMotorStatus;

	public NET_SCENE_IMAGE_INFO stuSceneImage;

	public EM_PREALARM emPreAlarm;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	public byte byVehicleHeadDirection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1011)]
	public string byReserved;
}
