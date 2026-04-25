// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WPAN_CARD_READER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WPAN_CARD_READER_INFO
{
	public bool bEnable;

	public byte byEncryption;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 31)]
	public byte[] byReserved;
}
