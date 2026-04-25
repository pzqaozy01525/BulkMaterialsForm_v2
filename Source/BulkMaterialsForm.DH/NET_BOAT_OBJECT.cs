// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BOAT_OBJECT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BOAT_OBJECT
{
	public uint nObjectID;

	public int nDistance;

	public int nHeight;

	public int nWidth;

	public int nSpeed;

	public EM_ACTION emActionType;

	public NET_RECT stuBoundingBox;

	public NET_RECT stuOriginalBoundingBox;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
