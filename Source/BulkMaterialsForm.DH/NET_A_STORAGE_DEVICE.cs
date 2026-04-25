// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_STORAGE_DEVICE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_STORAGE_DEVICE
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public long nTotalSpace;

	public long nFreeSpace;

	public byte byMedia;

	public byte byBUS;

	public byte byVolume;

	public byte byState;

	public int nPhysicNo;

	public int nLogicNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szParent;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szModule;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szSerial;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szFirmware;

	public int nPartitionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_A_STORAGE_PARTITION[] stuPartitions;

	public NET_STORAGE_RAID stuRaid;

	public NET_ISCSI_TARGET stuISCSI;

	public bool abTank;

	public NET_STORAGE_TANK stuTank;

	public EM_STORAGE_DISK_POWERMODE emPowerMode;

	public EM_STORAGE_DISK_PREDISKCHECK emPreDiskCheck;

	public int nOpState;
}
