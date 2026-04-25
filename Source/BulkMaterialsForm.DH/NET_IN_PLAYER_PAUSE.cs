// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PLAYER_PAUSE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PLAYER_PAUSE
{
	public uint dwSize;

	public IntPtr lPlayerID;

	public bool bPause;
}
