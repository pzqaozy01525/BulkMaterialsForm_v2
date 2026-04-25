// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DETECT_BIG_PIC_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DETECT_BIG_PIC_INFO
{
	public int nPicID;

	public uint dwOffSet;

	public uint dwFileLenth;

	public uint dwWidth;

	public uint dwHeight;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
	public byte[] bReserved;
}
