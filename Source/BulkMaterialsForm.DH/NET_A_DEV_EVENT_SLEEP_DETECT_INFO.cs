// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_SLEEP_DETECT_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_SLEEP_DETECT_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public uint nRuleID;

	public EM_CLASS_TYPE emClassType;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public uint nPresetID;

	public uint nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	public uint nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_MSG_OBJECT[] stuObjects;

	public bool bSceneImage;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	public int nRuleCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szRuleType;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 224)]
	public byte[] byReserved;
}
