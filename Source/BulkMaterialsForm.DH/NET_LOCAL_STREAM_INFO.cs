// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_LOCAL_STREAM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_LOCAL_STREAM_INFO
{
	public uint dwSize;

	public EM_ANALYSE_TASK_START_RULE emStartRule;

	public NET_ANALYSE_RULE stuRuleInfo;

	public int nChannelID;

	public uint nStreamType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szTaskUserData;

	public int nIsRepeat;

	public NET_ANALYSE_TASK_GLOBAL stuGlobal;

	public NET_ANALYSE_TASK_MODULE stuModule;
}
