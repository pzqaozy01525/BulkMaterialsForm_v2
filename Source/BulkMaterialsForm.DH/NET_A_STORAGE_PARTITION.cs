// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_STORAGE_PARTITION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_STORAGE_PARTITION
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public long nTotalSpace;

	public long nFreeSpace;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szMountOn;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szFileSystem;

	public int nStatus;

	public bool bIsSupportFs;
}
