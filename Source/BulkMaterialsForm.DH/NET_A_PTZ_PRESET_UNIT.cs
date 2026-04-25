// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_PTZ_PRESET_UNIT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_PTZ_PRESET_UNIT
{
	public int nPositionX;

	public int nPositionY;

	public int nZoom;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szReserve;
}
