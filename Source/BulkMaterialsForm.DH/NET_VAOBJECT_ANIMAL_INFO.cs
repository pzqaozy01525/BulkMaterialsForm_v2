// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VAOBJECT_ANIMAL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VAOBJECT_ANIMAL_INFO
{
	public uint nObjectID;

	public EM_BREED_DETECT_CATEGORY_TYPE emCategoryType;

	public NET_RECT stuBoundingBox;

	public uint nObjectWeight;

	public NET_SCENE_IMAGE_INFO_EX stuImageData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
