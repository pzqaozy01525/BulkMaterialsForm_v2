// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTACH_BACKUP_STATE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTACH_BACKUP_STATE
{
	public uint dwSize;

	public uint nGroupID;

	public fAttachBackupTaskStateCB cbAttachState;

	public IntPtr dwUser;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string bReserved;
}
