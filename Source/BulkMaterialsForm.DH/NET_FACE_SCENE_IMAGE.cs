// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_SCENE_IMAGE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_SCENE_IMAGE
{
	public uint nOffSet;

	public uint nLength;

	public uint nWidth;

	public uint nHeight;

	public uint nIndexInData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
	public byte[] byReserved;
}
