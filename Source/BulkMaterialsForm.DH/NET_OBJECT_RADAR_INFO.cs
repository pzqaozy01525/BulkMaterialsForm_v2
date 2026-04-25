// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OBJECT_RADAR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OBJECT_RADAR_INFO
{
	public uint nID;

	public uint nVerticalPos;

	public uint nHorizontalPos;

	public uint nObjectLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
