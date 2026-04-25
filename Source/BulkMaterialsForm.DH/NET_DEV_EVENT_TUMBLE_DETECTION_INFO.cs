// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TUMBLE_DETECTION_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TUMBLE_DETECTION_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public int nAction;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int UTCMS;

	public EM_CLASS_TYPE emClassType;

	public int nObjectID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szObjectType;

	public NET_RECT stuBoundingBox;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 22)]
	public string szSerialUUID;

	public NET_SCENE_IMAGE_INFO stuSceneImage;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 918)]
	public byte[] bReserved;
}
