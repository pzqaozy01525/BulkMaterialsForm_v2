// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_FIRE_LANE_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_FIRE_LANE_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nSequence;

	public int nRuleID;

	public uint nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_MSG_OBJECT[] stuObjects;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public bool bSceneImage;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	public EM_FIRE_LANE_MOVE_STATE emMoveState;

	public EM_FIRE_LANE_OILCAP_STATE emOilCapState;

	public NET_MSG_OBJECT stuVehicle;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	public bool bNonMotorInfo;

	public NET_VA_OBJECT_NONMOTOR stuNonMotor;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string byReserved;
}
