// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OBJECT_LIST_SIZE_ARRAY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OBJECT_LIST_SIZE_ARRAY
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szObjectType;
}
