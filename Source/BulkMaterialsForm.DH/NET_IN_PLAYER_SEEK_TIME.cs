// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PLAYER_SEEK_TIME

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PLAYER_SEEK_TIME
{
	public uint dwSize;

	public IntPtr lPlayerID;

	public NET_TIME stuTime;
}
