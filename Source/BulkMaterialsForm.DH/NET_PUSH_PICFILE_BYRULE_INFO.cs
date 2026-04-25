// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PUSH_PICFILE_BYRULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PUSH_PICFILE_BYRULE_INFO
{
	public uint dwSize;

	public EM_ANALYSE_TASK_START_RULE emStartRule;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szTaskUserData;
}
