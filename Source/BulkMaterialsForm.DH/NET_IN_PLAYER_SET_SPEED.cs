// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PLAYER_SET_SPEED

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PLAYER_SET_SPEED
{
	public uint dwSize;

	public IntPtr lPlayerID;

	public float fSpeed;
}
