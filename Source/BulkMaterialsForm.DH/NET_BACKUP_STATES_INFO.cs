// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BACKUP_STATES_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BACKUP_STATES_INFO
{
	public uint nProgress;

	public EM_BACKUP_STATES emState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDeviceName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string byReserved;
}
