// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PTZ_ACTION_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PTZ_ACTION_CAPS
{
	public bool bSupportPan;

	public bool bSupportTile;

	public bool bSupportZoom;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
	public byte[] byReserved;
}
