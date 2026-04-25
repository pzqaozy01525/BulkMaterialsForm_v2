// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ACCESS_CARD_SERVICE_GET

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ACCESS_CARD_SERVICE_GET
{
	public uint dwSize;

	public int nCardNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public NET_STRING_32_CARD_NO[] szCardNo;
}
