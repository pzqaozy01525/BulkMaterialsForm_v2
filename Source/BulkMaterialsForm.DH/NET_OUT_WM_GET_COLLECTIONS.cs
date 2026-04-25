// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_WM_GET_COLLECTIONS

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_WM_GET_COLLECTIONS
{
	public uint dwSize;

	public IntPtr pCollections;

	public int nMaxCollectionsCount;

	public int nCollectionsCount;
}
