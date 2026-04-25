// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_WORKSTATDETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_WORKSTATDETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public EM_CLASS_TYPE emClassType;

	public uint nRuleID;

	public uint nObjectID;

	public uint nWorkActionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_WORKACTION_STATE[] emWorkAction;

	public NET_SCENE_IMAGE_INFO stuSceneImage;

	public EM_WORKSTATDETECTION_TYPE emRuleType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
