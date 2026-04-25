// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HUMAN

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HUMAN
{
	public NET_RECT stuBoundingBox;

	public uint nObjectID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 22)]
	public string szSerialUUID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 230)]
	public byte[] bReserved;
}
