// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ACCESS_FACE_SERVICE_UserID

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ACCESS_FACE_SERVICE_UserID
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string userID;
}
