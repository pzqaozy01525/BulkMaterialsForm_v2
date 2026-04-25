// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CB_ANALYSE_TASK_STATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CB_ANALYSE_TASK_STATE_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_ANALYSE_TASKS_INFO[] stuTaskInfos;

	public uint nTaskNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
