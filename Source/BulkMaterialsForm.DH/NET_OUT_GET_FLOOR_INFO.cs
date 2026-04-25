// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GET_FLOOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GET_FLOOR_INFO
{
	public uint dwSize;

	public int nFloorInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_FLOOR_INFO[] stuFloorInfo;
}
