// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_FIND_GROUP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_FIND_GROUP_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupId;
}
