// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PTZ_MOVE_ABSOLUTELY_CAP

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PTZ_MOVE_ABSOLUTELY_CAP
{
	public NET_CFG_PTZ_ACTION_CAPS stuPTZ;

	public NET_CFG_PTZ_ABSOLUTELY_CAPS stuType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 768)]
	public byte[] byReserved;
}
