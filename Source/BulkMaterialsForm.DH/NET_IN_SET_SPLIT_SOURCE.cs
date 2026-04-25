// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SET_SPLIT_SOURCE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SET_SPLIT_SOURCE
{
	public uint dwSize;

	public EM_VIDEO_OUT_CTRL_TYPE emCtrlType;

	public int nChannel;

	public IntPtr pszCompositeID;

	public int nWindow;

	public IntPtr pstuSources;

	public int nSourceCount;
}
