// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MONITOR_WALL_OUT_MODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MONITOR_WALL_OUT_MODE_INFO
{
	public int nWidth;

	public int nHeight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
