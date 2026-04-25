// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_INFO
{
	public int nObjectID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szObjectType;

	public int nRelativeID;

	public NET_RECT BoundingBox;

	public NET_POINT Center;
}
