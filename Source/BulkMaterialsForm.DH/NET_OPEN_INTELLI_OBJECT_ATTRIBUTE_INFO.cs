// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OPEN_INTELLI_OBJECT_ATTRIBUTE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OPEN_INTELLI_OBJECT_ATTRIBUTE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szAttrTypeName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szAttrValueName;
}
