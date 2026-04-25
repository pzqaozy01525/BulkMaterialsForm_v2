// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PTZ_NORMALIZED_POSITION_UNIT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PTZ_NORMALIZED_POSITION_UNIT
{
	public double dbPositionX;

	public double dbPositionY;

	public double dbZoom;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szReserved;
}
