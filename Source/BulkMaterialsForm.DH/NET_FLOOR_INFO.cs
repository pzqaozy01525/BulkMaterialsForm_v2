// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FLOOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FLOOR_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szFloor;

	public uint nControlModuleToken;

	public uint nControlModulePort;

	public uint nCallLiftModuleToken;

	public uint nCallLiftModulePort;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
