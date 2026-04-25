// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANALYSE_RULE_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANALYSE_RULE_INFO
{
	public EM_SCENE_CLASS_TYPE emClassType;

	public uint dwRuleType;

	public IntPtr pReserved;

	public uint nObjectTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public EM_ANALYSE_OBJECT_TYPE[] emObjectTypes;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRuleName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 828)]
	public byte[] byReserved;
}
