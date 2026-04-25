// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTACH_ANALYSE_TASK_STATE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTACH_ANALYSE_TASK_STATE
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public uint[] nTaskIDs;

	public uint nTaskIdNum;

	public fAnalyseTaskStateCallBack cbAnalyseTaskState;

	public IntPtr dwUser;
}
