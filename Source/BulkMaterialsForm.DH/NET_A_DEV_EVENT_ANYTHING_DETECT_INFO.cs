// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_ANYTHING_DETECT_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_ANYTHING_DETECT_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public EM_CLASS_TYPE emClassType;

	public uint nRuleId;

	public uint nPresetID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	public int nObjectNum;

	public IntPtr pstuObjects;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
