// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MATRIX_CARD_LIST

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MATRIX_CARD_LIST
{
	public uint dwSize;

	public int nCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_MATRIX_CARD[] stuCards;
}
