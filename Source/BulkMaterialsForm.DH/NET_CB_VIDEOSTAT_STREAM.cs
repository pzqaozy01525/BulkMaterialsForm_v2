// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CB_VIDEOSTAT_STREAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CB_VIDEOSTAT_STREAM
{
	public int nChannel;

	public int nPtzPresetId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRuleNanme;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szStartTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRuleType;

	public EM_STAT_GRANULARITY emStatGranularity;

	public ushort nCycle;

	public ushort nAreaID;

	public uint nEnteredSubtotal;

	public uint nExitedSubtotal;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
