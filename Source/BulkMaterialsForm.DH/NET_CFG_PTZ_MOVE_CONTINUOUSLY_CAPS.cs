// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PTZ_MOVE_CONTINUOUSLY_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PTZ_MOVE_CONTINUOUSLY_CAPS
{
	public NET_CFG_PTZ_ACTION_CAPS stuPTZ;

	public NET_CFG_PTZ_CONTINUOUSLY_TYPE stuType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
