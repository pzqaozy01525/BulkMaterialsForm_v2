// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PTZBASE_MOVEABSOLUTELY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PTZBASE_MOVEABSOLUTELY_INFO
{
	public uint dwSize;

	public int nZoomFlag;

	public NET_PTZSPACE_UNNORMALIZED stuPosition;

	public NET_PTZSPACE_UNNORMALIZED stuSpeed;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 448)]
	public byte[] byReserved;
}
