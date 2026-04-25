// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_OPEN_DOOR_ROUTE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_OPEN_DOOR_ROUTE_INFO
{
	public int nDoorList;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_CFG_DOOR_ROUTE_INFO[] stuDoorList;

	public int nTimeSection;

	public uint nResetTime;
}
