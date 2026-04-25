// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_STORAGE_DEV_NAMES

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_STORAGE_DEV_NAMES
{
	public uint dwSize;

	public int nDevNamesNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16384)]
	public string szStoregeDevNames;
}
