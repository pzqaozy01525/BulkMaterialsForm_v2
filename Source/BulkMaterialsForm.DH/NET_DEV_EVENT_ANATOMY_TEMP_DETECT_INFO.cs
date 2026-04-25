// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_ANATOMY_TEMP_DETECT_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_ANATOMY_TEMP_DETECT_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public EM_CLASS_TYPE emClassType;

	public uint nPresetID;

	public NET_MAN_TEMP_INFO stManTempInfo;

	public NET_VIS_SCENE_IMAGE stVisSceneImage;

	public NET_THERMAL_SCENE_IMAGE stThermalSceneImage;

	public uint nSequence;

	public uint nEventRelevanceID;

	public bool bIsFaceRecognition;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1004)]
	public byte[] byReserved;
}
