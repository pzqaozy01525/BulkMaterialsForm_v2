// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_OUT_MONITORWALL_GET_SCENE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_OUT_MONITORWALL_GET_SCENE
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public NET_A_MONITORWALL_SCENE stuScene;
}
