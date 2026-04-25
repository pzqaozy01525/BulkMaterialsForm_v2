// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ACCESS_USER_SERVICE_REMOVE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ACCESS_USER_SERVICE_REMOVE
{
	public uint dwSize;

	public int nUserNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_STRING_32_USER_ID[] szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12800)]
	public string szUserIDEx;

	public bool bUserIDEx;
}
