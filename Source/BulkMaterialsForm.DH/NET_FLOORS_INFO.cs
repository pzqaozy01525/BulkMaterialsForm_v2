// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FLOORS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FLOORS_INFO
{
	public int nFloorNumEx2;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szFloorEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
