// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_XRAY_IMAGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_XRAY_IMAGE_INFO
{
	public EM_XRAY_VIEW_TYPE emViewType;

	public EM_XRAY_IMAGE_TYPE emImageType;

	public uint nOffset;

	public uint nLength;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
