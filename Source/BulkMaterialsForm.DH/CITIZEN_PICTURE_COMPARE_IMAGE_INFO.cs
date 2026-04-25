// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CITIZEN_PICTURE_COMPARE_IMAGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CITIZEN_PICTURE_COMPARE_IMAGE_INFO
{
	public uint dwOffSet;

	public uint dwFileLenth;

	public ushort wWidth;

	public ushort wHeight;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
