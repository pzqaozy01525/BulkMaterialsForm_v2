// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.SCENE_TYPE_LIST_ARRAY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct SCENE_TYPE_LIST_ARRAY
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string sceneTypeList;
}
