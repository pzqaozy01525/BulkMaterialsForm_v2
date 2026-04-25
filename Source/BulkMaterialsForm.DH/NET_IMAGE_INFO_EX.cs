// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IMAGE_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IMAGE_INFO_EX
{
	public EM_PIC_TYPE emPicType;

	public uint nOffset;

	public uint nLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szFilePath;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
