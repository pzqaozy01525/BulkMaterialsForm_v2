// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_PHONECALL_DETECT_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_PHONECALL_DETECT_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nGroupID;

	public int nCountInGroup;

	public int nIndexInGroup;

	public uint UTCMS;

	public NET_MSG_OBJECT stuObject;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public uint nRuleID;

	public uint nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_MSG_OBJECT[] stuObjects;

	public uint nSerialUUIDNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2816)]
	public string szSerialUUID;

	public bool bSceneImage;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserName;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 188)]
	public byte[] byReserved;
}
