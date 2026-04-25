// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CITIZEN_PICTURE_COMPARE_IMAGE_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CITIZEN_PICTURE_COMPARE_IMAGE_INFO_EX
{
	public NET_EM_CITIZEN_PICTURE_COMPARE_TYPE emType;

	public uint dwOffSet;

	public uint dwFileLenth;

	public ushort wWidth;

	public ushort wHeight;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] byReserved;
}
