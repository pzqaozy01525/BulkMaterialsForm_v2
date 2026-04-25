// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_OPEN_DOOR_GROUP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_OPEN_DOOR_GROUP_INFO
{
	public int nGroup;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_CFG_OPEN_DOOR_GROUP[] stuGroupInfo;
}
