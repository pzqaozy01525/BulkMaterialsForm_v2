// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PTZ_SPEED_UNIT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PTZ_SPEED_UNIT
{
	public float fPositionX;

	public float fPositionY;

	public float fZoom;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szReserve;
}
