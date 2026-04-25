// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_STORAGE_NAME_LEN_String

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_STORAGE_NAME_LEN_String
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSTORAGE_NAME;
}
