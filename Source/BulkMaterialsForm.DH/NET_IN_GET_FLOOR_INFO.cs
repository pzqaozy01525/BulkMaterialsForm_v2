// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_GET_FLOOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_GET_FLOOR_INFO
{
	public uint dwSize;

	public int nFloorNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_Floor_Str[] szFloors;
}
