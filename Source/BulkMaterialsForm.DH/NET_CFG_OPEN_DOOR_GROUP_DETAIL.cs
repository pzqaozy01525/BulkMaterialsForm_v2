// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_OPEN_DOOR_GROUP_DETAIL

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_OPEN_DOOR_GROUP_DETAIL
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public EM_CFG_OPEN_DOOR_GROUP_METHOD emMethod;

	public int nMethodExNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public EM_CFG_OPEN_DOOR_GROUP_METHOD[] emMethodEx;
}
