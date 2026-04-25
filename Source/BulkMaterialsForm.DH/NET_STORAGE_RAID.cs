// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_STORAGE_RAID

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_STORAGE_RAID
{
	public uint dwSize;

	public int nLevel;

	public int nState;

	public int nMemberNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_STORAGE_NAME_LEN_String[] szMembers;

	public float fRecoverPercent;

	public float fRecoverMBps;

	public float fRecoverTimeRemain;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_RAID_MEMBER_INFO[] stuMemberInfos;

	public int nRaidDevices;

	public int nTotalDevices;

	public int nActiveDevices;

	public int nWorkingDevices;

	public int nFailedDevices;

	public int nSpareDevices;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
	public string szAliasName;
}
