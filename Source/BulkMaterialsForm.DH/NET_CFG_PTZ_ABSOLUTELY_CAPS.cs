// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PTZ_ABSOLUTELY_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PTZ_ABSOLUTELY_CAPS
{
	public bool bSupportNormal;

	public bool bSupportReal;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
	public byte[] byReserved;
}
