// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCENE_IMAGE_INFO_EX2

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SCENE_IMAGE_INFO_EX2
{
	public uint nOffSet;

	public uint nLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string byReserved;
}
