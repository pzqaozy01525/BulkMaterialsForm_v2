// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PTZ_CONTROL_CONTINUOUSLY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PTZ_CONTROL_CONTINUOUSLY
{
	public NET_PTZ_SPEED_UNIT stuSpeed;

	public int nTimeOut;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szReserve;
}
