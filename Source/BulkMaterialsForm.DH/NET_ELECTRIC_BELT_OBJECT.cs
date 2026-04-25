// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ELECTRIC_BELT_OBJECT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ELECTRIC_BELT_OBJECT
{
	public uint nObjectID;

	public EM_ELECTRIC_BELT_TYPE emBeltType;

	public EM_BELT_WARE_TYPE emBeltWareType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	public NET_RECT stuBoundingBox;

	public NET_OBJECT_IMAGE_INFO stuImageData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
