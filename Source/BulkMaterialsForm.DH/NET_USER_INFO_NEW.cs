// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_USER_INFO_NEW

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_USER_INFO_NEW
{
	public uint dwSize;

	public uint dwID;

	public uint dwGroupID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string name;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string passWord;

	public uint dwRightNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public uint[] rights;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string memo;

	public uint dwFouctionMask;

	public NET_TIME stuTime;

	public byte byIsAnonymous;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	public byte[] byReserve;

	public override string ToString()
	{
		return name;
	}
}
