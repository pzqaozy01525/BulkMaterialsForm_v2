// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_DOOR_ROUTE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_DOOR_ROUTE_INFO
{
	public int nDoors;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CFG_DOOR_ROUTE_NODE_INFO[] stuDoors;

	public uint nResetTime;
}
