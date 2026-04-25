// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OPEN_INTELLI_OBJECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OPEN_INTELLI_OBJECT_INFO
{
	public int nObjectId;

	public NET_RECT stuBoundingBox;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szObjectTypeName;

	public int nObjectAttributeNums;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_OPEN_INTELLI_OBJECT_ATTRIBUTE_INFO[] stuObjectAttributes;
}
