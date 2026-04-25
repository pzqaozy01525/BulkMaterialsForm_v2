// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_FIND_ANALYSE_TASK

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_FIND_ANALYSE_TASK
{
	public uint dwSize;

	public uint nTaskNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_ANALYSE_TASKS_INFO[] stuTaskInfos;
}
