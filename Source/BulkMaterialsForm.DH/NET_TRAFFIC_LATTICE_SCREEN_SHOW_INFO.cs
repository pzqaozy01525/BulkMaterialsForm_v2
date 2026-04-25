// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFIC_LATTICE_SCREEN_SHOW_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFIC_LATTICE_SCREEN_SHOW_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_TRAFFIC_LATTICE_SCREEN_SHOW_CONTENTS[] stuContents;

	public int nContentsNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
