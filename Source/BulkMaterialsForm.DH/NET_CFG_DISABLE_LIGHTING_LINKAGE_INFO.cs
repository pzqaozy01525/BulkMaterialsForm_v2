// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_DISABLE_LIGHTING_LINKAGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_DISABLE_LIGHTING_LINKAGE_INFO
{
	public uint dwSize;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szName;
}
