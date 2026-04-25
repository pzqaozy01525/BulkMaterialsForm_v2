// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ABLOCK_DOOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ABLOCK_DOOR_INFO
{
	public int nDoor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public int[] anDoor;
}
