// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PTZ_CONTROL_SECTORSCAN

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PTZ_CONTROL_SECTORSCAN
{
	public int nBeginAngle;

	public int nEndAngle;

	public int nSpeed;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szReserve;
}
