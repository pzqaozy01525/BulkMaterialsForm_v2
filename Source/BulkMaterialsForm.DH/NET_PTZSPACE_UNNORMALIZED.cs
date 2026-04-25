// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PTZSPACE_UNNORMALIZED

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PTZSPACE_UNNORMALIZED
{
	public int nPosX;

	public int nPosY;

	public int nZoom;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
	public byte[] byReserved;
}
