// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WPAN_ACCESSORY_IMAGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WPAN_ACCESSORY_IMAGE_INFO
{
	public EM_A_CAPTURE_SIZE emResolution;

	public int nSnapshotNumber;

	public int nSnapshotTimes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byReserved;
}
