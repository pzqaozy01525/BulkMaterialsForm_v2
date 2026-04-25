// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IMAGE_INFO_EX2

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IMAGE_INFO_EX2
{
	public EM_IMAGE_TYPE_EX2 emType;

	public uint nOffset;

	public uint nLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string byReserverd;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPath;
}
