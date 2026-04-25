// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CB_ANALYSE_TASK_RESULT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CB_ANALYSE_TASK_RESULT_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_ANALYSE_TASK_RESULT[] stuTaskResultInfos;

	public uint nTaskResultNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1028)]
	public byte[] byReserved;
}
