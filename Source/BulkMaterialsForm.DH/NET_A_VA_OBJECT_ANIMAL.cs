// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_VA_OBJECT_ANIMAL

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_VA_OBJECT_ANIMAL
{
	public uint nObjectID;

	public EM_ANINAL_CATEGORY emCategory;

	public NET_RECT stuBoundingBox;

	public uint nObjectWeight;

	public NET_OBJECT_IMAGE_INFO stuImage;

	public EM_A_ENUM_MOTION_STATUS emMoveStatus;

	public EM_A_ENUM_IN_REGION_STATUS emInRegionStatus;

	public int nResultType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
