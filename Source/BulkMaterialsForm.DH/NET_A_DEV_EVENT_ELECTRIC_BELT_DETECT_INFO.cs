// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_ELECTRIC_BELT_DETECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_ELECTRIC_BELT_DETECT_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public uint nRuleID;

	public uint nSequence;

	public EM_CLASS_TYPE emClassType;

	public uint nBeltObjNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_ELECTRIC_BELT_OBJECT[] stuBeltObjs;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1028)]
	public byte[] byReserved;
}
