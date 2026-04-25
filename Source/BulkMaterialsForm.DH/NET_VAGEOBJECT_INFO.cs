// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VAGEOBJECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VAGEOBJECT_INFO
{
	public uint nObjectID;

	public uint nTypeIndex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szTypeName;

	public int nConfidence;

	public EM_A_ENUM_VAGEOBJECT_ACTION emAction;

	public NET_RECT stuBoundingBox;

	public NET_RECT stuOriginalBoundingBox;

	public NET_POINT stuCenter;

	public bool bMainColor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byMainColor;

	public NET_VAGEOBJECT_IMAGE stuImage;

	public NET_TIME_EX stuCurrentTimeStamp;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
