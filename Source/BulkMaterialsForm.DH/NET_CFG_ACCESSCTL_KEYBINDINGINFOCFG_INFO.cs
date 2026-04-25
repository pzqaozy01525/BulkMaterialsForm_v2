// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESSCTL_KEYBINDINGINFOCFG_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESSCTL_KEYBINDINGINFOCFG_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szBindingInfo;

	public uint nKey;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
	public byte[] byReserved;
}
