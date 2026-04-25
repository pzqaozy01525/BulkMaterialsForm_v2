// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_REMOTE_SPEAK_CAPS

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_REMOTE_SPEAK_CAPS
{
	public uint dwSize;

	public int nRetCapNum;

	public IntPtr pstuCaps;

	public IntPtr pReserved;

	public int nMaxCapNum;
}
