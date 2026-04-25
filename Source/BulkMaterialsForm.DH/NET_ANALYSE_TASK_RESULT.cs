// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANALYSE_TASK_RESULT

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANALYSE_TASK_RESULT
{
	public uint nTaskID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szFileID;

	public EM_FILE_ANALYSE_STATE emFileAnalyseState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szFileAnalyseMsg;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_SECONDARY_ANALYSE_EVENT_INFO[] stuEventInfos;

	public int nEventCount;

	public NET_TASK_CUSTOM_DATA stuCustomData;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szUserData;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szTaskUserData;

	public IntPtr pstuEventInfosEx;

	public int nRetEventInfoExNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szUserDefineData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 184)]
	public byte[] byReserved;
}
