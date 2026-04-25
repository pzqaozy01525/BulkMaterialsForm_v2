// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CANDIDAT_PIC_PATHS_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CANDIDAT_PIC_PATHS_EX
{
	public int nFileCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public NET_PIC_INFO_CPP[] stFiles;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] bReserved;
}
