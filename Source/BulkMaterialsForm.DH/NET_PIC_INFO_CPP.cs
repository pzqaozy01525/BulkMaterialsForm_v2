// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PIC_INFO_CPP

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PIC_INFO_CPP
{
	public uint dwFileLenth;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] bReserved;
}
