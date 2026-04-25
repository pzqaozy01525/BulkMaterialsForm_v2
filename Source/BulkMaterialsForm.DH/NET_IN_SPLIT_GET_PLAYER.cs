// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SPLIT_GET_PLAYER

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SPLIT_GET_PLAYER
{
	public uint dwSize;

	public int nChannel;

	public IntPtr pszCompositeID;

	public EM_NET_SPLIT_PLAYER_TYPE emType;

	public int nWindow;
}
