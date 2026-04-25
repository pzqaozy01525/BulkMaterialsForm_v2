// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ACCESS_FACE_SERVICE_GET

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ACCESS_FACE_SERVICE_GET
{
	public uint dwSize;

	public int nUserNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_IN_ACCESS_FACE_SERVICE_UserID[] szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12800)]
	public string szUserIDEx;

	public bool bUserIDEx;
}
