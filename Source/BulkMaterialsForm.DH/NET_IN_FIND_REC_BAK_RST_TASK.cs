// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_FIND_REC_BAK_RST_TASK

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_FIND_REC_BAK_RST_TASK
{
	public uint dwSize;

	public EM_RECORD_BACKUP_FIND_TYPE emFindType;

	public uint dwTaskID;

	public int nLocalChannelID;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;
}
