// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_RULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_RULE_INFO
{
	public int nRuleID;

	public int nPointNumber;

	public uint nTrackerIP;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
	public string byReserved;
}
