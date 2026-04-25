// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BACKUP_TARGET

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BACKUP_TARGET
{
	public EM_BACKUP_TARGET_TYPE emTargetType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string Reserved;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szRename;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string byReserved;
}
