// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_AUTOMT_CFG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_AUTOMT_CFG
{
	public uint dwSize;

	public byte byAutoRebootDay;

	public byte byAutoRebootTime;

	public byte byAutoDeleteFilesTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
	public byte[] reserved;
}
