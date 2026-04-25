// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PTZ_CONTINUOUSLY_TYPE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PTZ_CONTINUOUSLY_TYPE
{
	public bool bSupportNormal;

	public bool bSupportExtra;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
	public byte[] byReserved;
}
