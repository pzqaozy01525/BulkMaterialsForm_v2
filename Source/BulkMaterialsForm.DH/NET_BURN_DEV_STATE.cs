// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BURN_DEV_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BURN_DEV_STATE
{
	public uint dwSize;

	public int nDeviceID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDevName;

	public uint dwTotalSpace;

	public uint dwRemainSpace;

	public EM_NET_BURN_DEV_USED_STATE emUsedType;

	public EM_NET_BURN_ERROR_CODE emError;

	public EM_DISK_STATE emDiskState;
}
