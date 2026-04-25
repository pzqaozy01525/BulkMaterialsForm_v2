// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESS_CONTROL_ASG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESS_CONTROL_ASG
{
	public EM_PASS_MODE emPassMode;

	public uint nOpenDoorSpeed;

	public uint nPassTimeOut;

	public uint nCloseDelayTime;

	public uint nSecurityLevel;

	public bool bSecondOpenEnable;

	public bool bMemoryModeEnable;

	public EM_COLLISION_MODE emCollisionMode;

	public uint nVolumeLevel;

	public EM_DIRECTION_AFTER_POWER_OFF emDirectionAfterPowerOff;

	public EM_ASG_WORK_MODE emWorkMode;

	public EM_STARTUP_MODE emStartUpMode;

	public int nMasterWingAngleAdjust;

	public int nSlaveWingAngleAdjust;

	public EM_GATE_TYPE emGateType;

	public EM_CHANNEL_WIDTH emChannelWidth;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
