// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_OPEN_DOOR_GROUP

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_OPEN_DOOR_GROUP
{
	public int nUserCount;

	public int nGroupNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_CFG_OPEN_DOOR_GROUP_DETAIL[] stuGroupDetail;

	public bool bGroupDetailEx;

	public int nMaxGroupDetailNum;

	public IntPtr pstuGroupDetailEx;
}
