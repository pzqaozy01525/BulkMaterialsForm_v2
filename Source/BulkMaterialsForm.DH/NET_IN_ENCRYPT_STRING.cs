// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ENCRYPT_STRING

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ENCRYPT_STRING
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
	public string szCard;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved1;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
	public string szKey;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved2;
}
