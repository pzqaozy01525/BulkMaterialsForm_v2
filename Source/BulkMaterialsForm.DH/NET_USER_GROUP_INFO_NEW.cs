// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_USER_GROUP_INFO_NEW

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_USER_GROUP_INFO_NEW
{
	public uint dwSize;

	public uint dwID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string name;

	public uint dwRightNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public uint[] rights;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string memo;
}
