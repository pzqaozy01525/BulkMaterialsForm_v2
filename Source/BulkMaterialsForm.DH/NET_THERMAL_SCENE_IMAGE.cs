// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_THERMAL_SCENE_IMAGE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_THERMAL_SCENE_IMAGE
{
	public uint nOffset;

	public uint nLength;

	public uint nWidth;

	public uint nHeight;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] byReserved;
}
