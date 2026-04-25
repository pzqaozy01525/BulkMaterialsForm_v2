// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_TAGMANAGER_DOFIND_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_TAGMANAGER_DOFIND_INFO
{
	public uint dwSize;

	public uint nMaxTagInfoCount;

	public uint nRetTagInfoCount;

	public IntPtr pstuTagInfo;
}
