// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTACH_ANALYSE_RESULT

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTACH_ANALYSE_RESULT
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public uint[] nTaskIDs;

	public uint nTaskIdNum;

	public NET_ANALYSE_RESULT_FILTER stuFilter;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public fAnalyseTaskResultCallBack cbAnalyseTaskResult;

	public IntPtr dwUser;
}
