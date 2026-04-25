// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HIGHTOSS_OBJECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HIGHTOSS_OBJECT_INFO
{
	public uint nObjectID;

	public EM_HIGHTOSS_ACTION_TYPE emObjAction;

	public NET_RECT stuBoundingBox;

	public uint nConfidence;

	public EM_ANALYSE_OBJECT_TYPE emObjectType;

	public NET_POINT stuCenter;

	public NET_EVENT_IMAGE_OFFSET_INFO stuImageInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1516)]
	public byte[] byReserved;
}
