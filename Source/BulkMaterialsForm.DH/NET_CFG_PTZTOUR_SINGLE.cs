// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PTZTOUR_SINGLE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PTZTOUR_SINGLE
{
	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	public int nPresetsNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_CFG_PTZTOUR_PRESET[] stPresets;
}
