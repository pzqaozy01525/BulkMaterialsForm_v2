// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESSCTL_KEYBINDINGINFOCFG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESSCTL_KEYBINDINGINFOCFG
{
	public uint dwSize;

	public uint nKeyNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_ACCESSCTL_KEYBINDINGINFOCFG_INFO[] stuKeyBindingInfo;
}
