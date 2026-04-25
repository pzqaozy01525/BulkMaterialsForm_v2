// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PLAYLIST_TIMESECTION

using System;

namespace BulkMaterialsForm.DH;

public struct NET_PLAYLIST_TIMESECTION
{
	public uint dwSize;

	public int nEvent;

	public IntPtr pstuTSs;

	public uint unMaxTS;

	public uint unRetTS;
}
