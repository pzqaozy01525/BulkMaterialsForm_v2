// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCENE_IMAGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SCENE_IMAGE_INFO
{
	public uint nOffSet;

	public uint nLength;

	public uint nWidth;

	public uint nHeight;

	public uint nIndexInData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
	public byte[] byReserved;
}
