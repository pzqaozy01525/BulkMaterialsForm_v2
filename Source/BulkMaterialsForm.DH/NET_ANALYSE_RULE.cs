// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANALYSE_RULE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANALYSE_RULE
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_ANALYSE_RULE_INFO[] stuRuleInfos;

	public uint nRuleCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1028)]
	public byte[] byReserved;
}
