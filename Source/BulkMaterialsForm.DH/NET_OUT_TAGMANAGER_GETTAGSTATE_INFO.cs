// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_TAGMANAGER_GETTAGSTATE_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_TAGMANAGER_GETTAGSTATE_INFO
{
	public uint dwSize;

	public int nState;

	public int nMaxTagStaeNumber;

	public int nRetTagStaeNumber;

	public IntPtr pstuTagStateInfo;
}
