// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESS_GENERAL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESS_GENERAL_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szOpenDoorAudioPath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szCloseDoorAudioPath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szInUsedAuidoPath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPauseUsedAudioPath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szNotClosedAudioPath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szWaitingAudioPath;

	public int nUnlockReloadTime;

	public int nUnlockHoldTime;

	public byte abProjectPassword;

	public byte abAccessProperty;

	public byte abABLockInfo;

	public byte byReserved;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szProjectPassword;

	public EM_CFG_ACCESS_PROPERTY_TYPE emAccessProperty;

	public NET_CFG_ABLOCK_INFO stuABLockInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDuressPassword;

	public bool bDuressEnable;

	public bool bCustomPasswordEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCommonPassword;

	public uint nPeakTimeSection;

	public bool bPeakState;

	public uint nRemoteAuthTimeOut;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] arrFloorPermission;

	public int nFloorPermission;

	public NET_CFG_ACCESS_CONTROL_ASG stuAccessControlASG;

	public NET_CFG_ACCESS_VOICE stuAccessVoice;

	public EM_ACCESS_SENSOR_TYPE emSensorType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
