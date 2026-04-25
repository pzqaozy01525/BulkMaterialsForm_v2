// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PTZ_CONTROL_ABSOLUTELY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PTZ_CONTROL_ABSOLUTELY
{
	public NET_PTZ_SPACE_UNIT stuPosition;

	public NET_PTZ_SPEED_UNIT stuSpeed;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szReserve;
}
