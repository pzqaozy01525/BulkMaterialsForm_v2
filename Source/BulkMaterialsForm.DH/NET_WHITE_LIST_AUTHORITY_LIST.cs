// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WHITE_LIST_AUTHORITY_LIST

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WHITE_LIST_AUTHORITY_LIST
{
	public bool bOpenGate;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] bReserved;
}
