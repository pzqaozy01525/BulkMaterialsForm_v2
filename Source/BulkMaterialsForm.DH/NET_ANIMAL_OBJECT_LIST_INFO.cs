// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANIMAL_OBJECT_LIST_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANIMAL_OBJECT_LIST_INFO
{
	public NET_RECT stuBoundingBox;

	public NET_POINT stuPoint;

	public int nObjectID;

	public int nObjectNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
