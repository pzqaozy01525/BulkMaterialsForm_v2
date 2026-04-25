// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_REMOVE_DEVICE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_REMOVE_DEVICE
{
	public uint dwSize;

	public int nCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 131072)]
	public string szDeviceIDs;
}
