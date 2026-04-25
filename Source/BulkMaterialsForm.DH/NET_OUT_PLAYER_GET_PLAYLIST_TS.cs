// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_PLAYER_GET_PLAYLIST_TS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_PLAYER_GET_PLAYLIST_TS
{
	public uint dwSize;

	public uint dwEventNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_PLAYLIST_TIMESECTION[] stuTS;
}
