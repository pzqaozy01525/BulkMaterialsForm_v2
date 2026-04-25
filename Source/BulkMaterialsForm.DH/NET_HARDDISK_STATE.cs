// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HARDDISK_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HARDDISK_STATE
{
	public uint dwDiskNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_DEV_DISKSTATE[] stDisks;
}
