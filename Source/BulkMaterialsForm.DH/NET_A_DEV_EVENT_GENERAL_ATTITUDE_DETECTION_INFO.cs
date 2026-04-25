// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_GENERAL_ATTITUDE_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_GENERAL_ATTITUDE_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double dbPTS;

	public NET_TIME_EX stuUTC;

	public int nEventID;

	public NET_GENERAL_ATTITUDE_DETECTION_OBJECT stuObject;

	public NET_SCENE_IMAGE_INFO_EX2 stuSceneImage;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
