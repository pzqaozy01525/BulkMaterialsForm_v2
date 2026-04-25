// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.PTZ_PROTOCOL_CAPS_AUX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct PTZ_PROTOCOL_CAPS_AUX
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szAux;
}
