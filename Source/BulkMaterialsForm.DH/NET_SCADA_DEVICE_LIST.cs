// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCADA_DEVICE_LIST

using System;

namespace BulkMaterialsForm.DH;

public struct NET_SCADA_DEVICE_LIST
{
	public uint dwSize;

	public int nMax;

	public int nRet;

	public IntPtr pstuDeviceIDInfo;
}
