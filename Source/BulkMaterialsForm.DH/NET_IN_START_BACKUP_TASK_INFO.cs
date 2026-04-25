// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_START_BACKUP_TASK_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_START_BACKUP_TASK_INFO
{
	public uint dwSize;

	public EM_BACKUP_SOURCE_MODE emSourceMode;

	public EM_BACKUP_TARGET_MODE emTargetMode;

	public int nSourceNum;

	public IntPtr pstuSource;

	public IntPtr pstuTarget;

	public int nTargetNum;

	public EM_BACKUP_FORMAT emFormat;

	public uint nGroupID;

	public bool bTakePlayer;
}
