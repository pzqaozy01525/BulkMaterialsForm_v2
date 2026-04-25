// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PIC_INFO_EX2

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PIC_INFO_EX2
{
	public uint nLength;

	public uint nWidth;

	public uint nHeight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string byReserverd;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szFilePath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserverd;
}
