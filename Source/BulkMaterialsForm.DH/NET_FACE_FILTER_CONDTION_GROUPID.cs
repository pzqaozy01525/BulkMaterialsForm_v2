// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_FILTER_CONDTION_GROUPID

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_FILTER_CONDTION_GROUPID
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupId;
}
