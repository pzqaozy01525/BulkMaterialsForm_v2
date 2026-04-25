// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_ENCRYPT_STRING

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_ENCRYPT_STRING
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szEncryptString;
}
