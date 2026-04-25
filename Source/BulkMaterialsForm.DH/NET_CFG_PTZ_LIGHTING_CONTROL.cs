// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PTZ_LIGHTING_CONTROL

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PTZ_LIGHTING_CONTROL
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szMode;

	public uint dwNearLightNumber;

	public uint dwFarLightNumber;
}
