// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_RULE_COMM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_RULE_COMM_INFO
{
	public byte bRuleId;

	public EM_SCENE_TYPE emClassType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] bReserved;
}
