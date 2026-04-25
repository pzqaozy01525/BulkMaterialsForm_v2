// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_STRING_32_USER_ID

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_STRING_32_USER_ID
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;
}
