// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CANDIDAT_PIC_PATHS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CANDIDAT_PIC_PATHS
{
	public uint dwSize;

	public int nFileCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public NET_PIC_INFO_EX[] stFiles;
}
