// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORD_BACKUP_PROGRESS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RECORD_BACKUP_PROGRESS
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szFilePath;

	public EM_A_ENUM_RECORDBACKUP_FILE_PROGRESS_TYPE emType;

	public int nPosition;

	public uint nPercent;

	public int nRemainingTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szReserved;
}
