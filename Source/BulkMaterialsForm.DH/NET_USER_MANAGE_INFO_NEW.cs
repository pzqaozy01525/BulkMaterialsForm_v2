// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_USER_MANAGE_INFO_NEW

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_USER_MANAGE_INFO_NEW
{
	public uint dwSize;

	public uint dwRightNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public NET_OPR_RIGHT_NEW[] rightList;

	public uint dwGroupNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_USER_GROUP_INFO_NEW[] groupList;

	public uint dwUserNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
	public NET_USER_INFO_NEW[] userList;

	public uint dwFouctionMask;

	public byte byNameMaxLength;

	public byte byPSWMaxLength;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 254)]
	public byte[] byReserve;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_USER_GROUP_INFO_EX2[] groupListEx;
}
