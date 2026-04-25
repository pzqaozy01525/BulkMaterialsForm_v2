// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_REC_BAK_RST_TASK

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_REC_BAK_RST_TASK
{
	public uint dwSize;

	public uint nTaskID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;

	public int nChannelID;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public int nState;

	public NET_RECORD_BACKUP_PROGRESS stuProgress;

	public EM_RECORD_BACKUP_FAIL_REASON emFailReason;

	public NET_TIME stuTaskStartTime;

	public NET_TIME stuTaskEndTime;

	public int nRemoteChannel;
}
