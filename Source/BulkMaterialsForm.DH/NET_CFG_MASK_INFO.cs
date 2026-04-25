// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_MASK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_MASK_INFO
{
	public uint nOffset;

	public uint nLength;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1016)]
	public byte[] byReserved;
}
