// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADIOMETRY_CONDITION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADIOMETRY_CONDITION
{
	public int nPresetId;

	public int nRuleId;

	public int nMeterType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] reserved;
}
