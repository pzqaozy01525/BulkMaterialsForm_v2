// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_INSIDE_OBJECT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_INSIDE_OBJECT
{
	public EM_DANGER_GRADE_TYPE emDangerGrade;

	public EM_INSIDE_OBJECT_TYPE emObjType;

	public uint nSimilarity;

	public NET_RECT stuBoundingBox;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 108)]
	public byte[] byReserved;
}
