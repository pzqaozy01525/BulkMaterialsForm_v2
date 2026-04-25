// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VAGEOBJECT_IMAGE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VAGEOBJECT_IMAGE
{
	public uint nOffset;

	public uint nLength;

	public uint nWidth;

	public uint nHeight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;
}
