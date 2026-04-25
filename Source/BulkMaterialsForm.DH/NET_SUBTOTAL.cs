// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SUBTOTAL

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SUBTOTAL
{
	public uint nDevNum;

	public uint nInside;

	public uint nExited;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byRserved;
}
