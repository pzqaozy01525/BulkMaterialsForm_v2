// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OSD_CUSTOM_SORT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OSD_CUSTOM_SORT
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_OSD_CUSTOM_ELEMENT[] stElements;

	public int nElementNum;
}
