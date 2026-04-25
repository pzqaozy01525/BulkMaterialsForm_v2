// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTACH_VIDEOSTAT_SUM

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTACH_VIDEOSTAT_SUM
{
	public uint dwSize;

	public int nChannel;

	public fVideoStatSumCallBack cbVideoStatSum;

	public IntPtr dwUser;
}
