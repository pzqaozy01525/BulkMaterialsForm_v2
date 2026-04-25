// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VAOBJECT_NUMMAN

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VAOBJECT_NUMMAN
{
	public uint nObjectID;

	public EM_UNIFORM_STYLE emUniformStyle;

	public NET_RECT stuBoundingBox;

	public NET_RECT stuOriginalBoundingBox;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
