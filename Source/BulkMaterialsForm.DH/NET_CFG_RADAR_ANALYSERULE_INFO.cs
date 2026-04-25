// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_RADAR_ANALYSERULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_RADAR_ANALYSERULE_INFO
{
	public uint dwSize;

	public int nAnalyseRuleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public NET_RADAR_ANALYSERULE[] stuAnalyseRules;
}
