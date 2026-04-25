// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RAID_STATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RAID_STATE_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szName;

	public byte byType;

	public byte byStatus;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public int nCntMem;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nMember;

	public int nCapacity;

	public int nRemainSpace;

	public int nTank;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] reserved;
}
