// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_RADIOMETRY_RULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_RADIOMETRY_RULE_INFO
{
	public int nCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public NET_CFG_RADIOMETRY_RULE[] stRule;
}
