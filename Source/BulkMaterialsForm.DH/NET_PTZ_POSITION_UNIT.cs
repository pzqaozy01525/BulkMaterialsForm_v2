// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PTZ_POSITION_UNIT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PTZ_POSITION_UNIT
{
	public int nPositionX;

	public int nPositionY;

	public int nZoom;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szReserve;
}
