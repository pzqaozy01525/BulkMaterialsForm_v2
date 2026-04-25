// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_XRAY_RELATED_IMAGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_XRAY_RELATED_IMAGE_INFO
{
	public EM_XRAY_RELATED_IMAGE_TYPE emImageType;

	public uint nOffset;

	public uint nLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string byReserved;
}
