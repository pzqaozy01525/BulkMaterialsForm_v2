// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IMAGE_RELATION_EX_IMAGEINFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IMAGE_RELATION_EX_IMAGEINFO
{
	public int nOffset;

	public int nLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szReserved;
}
