// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PIC_INFO_EX3

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PIC_INFO_EX3
{
	public uint dwOffSet;

	public uint dwFileLenth;

	public ushort wWidth;

	public ushort wHeight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szFilePath;

	public byte bIsDetected;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
	public byte[] bReserved;
}
