// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANALYSE_TASKS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANALYSE_TASKS_INFO
{
	public uint nTaskID;

	public EM_ANALYSE_STATE emAnalyseState;

	public EM_ANALYSE_TASK_ERROR emErrorCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szTaskUserData;

	public int nVideoAnalysisProcess;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szUrl;

	public EM_SCENE_CLASS_TYPE emClassType;

	public EM_DATA_SOURCE_TYPE emSourceType;

	public int nChipId;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 428)]
	public byte[] byReserved;
}
