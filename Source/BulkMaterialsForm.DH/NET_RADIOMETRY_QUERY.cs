// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADIOMETRY_QUERY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADIOMETRY_QUERY
{
	public NET_TIME stTime;

	public int nPresetId;

	public int nRuleId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	public NET_POINT stCoordinate;

	public int nChannel;

	public NET_RADIOMETRYINFO stTemperInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] reserved;
}
