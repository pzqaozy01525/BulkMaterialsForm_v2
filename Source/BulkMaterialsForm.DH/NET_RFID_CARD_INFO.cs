// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RFID_CARD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RFID_CARD_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
	public string szCardId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szReserved;
}
