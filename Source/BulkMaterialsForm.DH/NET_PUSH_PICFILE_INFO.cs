// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PUSH_PICFILE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PUSH_PICFILE_INFO
{
	public uint dwSize;

	public EM_ANALYSE_TASK_START_RULE emStartRule;

	public NET_ANALYSE_RULE stuRuleInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szTaskUserData;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
	public string szMQConfig;

	public int nIsRepeat;

	public NET_ANALYSE_TASK_GLOBAL stuGlobal;

	public NET_ANALYSE_TASK_MODULE stuModule;
}
