// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OBJECT_IMAGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OBJECT_IMAGE_INFO
{
	public uint nOffSet;

	public uint nLength;

	public uint nWidth;

	public uint nHeight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;

	public uint nIndexInData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 504)]
	public byte[] byReserved;
}
