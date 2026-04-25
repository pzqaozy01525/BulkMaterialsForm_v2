// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ADJUST_LIGHT_COLOR

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ADJUST_LIGHT_COLOR
{
	public int nMode;

	public bool bEnable;

	public int nLevel;

	public bool bVideoEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_ADJUST_LEVEL_SEP[] stLevelSep;
}
