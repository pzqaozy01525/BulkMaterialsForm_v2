// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SET_QRCODE_DECODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SET_QRCODE_DECODE_INFO
{
	public uint dwSize;

	public NET_ENUM_QRCODE_CIPHER emCipher;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
	public string szKey;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved;
}
