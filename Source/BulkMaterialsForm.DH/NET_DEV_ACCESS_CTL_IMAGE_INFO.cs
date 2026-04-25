// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_ACCESS_CTL_IMAGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_ACCESS_CTL_IMAGE_INFO
{
	public EM_ACCESS_CTL_IMAGE_TYPE emType;

	public uint nOffSet;

	public uint nLength;

	public uint nWidth;

	public uint nHeight;

	public NET_RECT stuBoundingBox;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public byte[] byReserved;
}
