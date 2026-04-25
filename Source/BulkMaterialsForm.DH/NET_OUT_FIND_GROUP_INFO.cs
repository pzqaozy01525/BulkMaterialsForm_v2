// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_FIND_GROUP_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_FIND_GROUP_INFO
{
	public uint dwSize;

	public IntPtr pGroupInfos;

	public int nMaxGroupNum;

	public int nRetGroupNum;
}
