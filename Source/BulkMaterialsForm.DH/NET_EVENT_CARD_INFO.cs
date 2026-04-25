// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_CARD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_CARD_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
	public byte[] szCardNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] bReserved;
}
