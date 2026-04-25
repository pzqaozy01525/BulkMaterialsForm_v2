// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DB_KEY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DB_KEY
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDBKey;
}
