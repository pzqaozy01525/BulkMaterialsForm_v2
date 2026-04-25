// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SEAT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SEAT_INFO
{
	public NET_RECT stuFaceRect;

	public byte bySunShade;

	public byte byDriverCalling;

	public byte byDriverSmoking;

	public byte bySafeBelt;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byReserved;
}
