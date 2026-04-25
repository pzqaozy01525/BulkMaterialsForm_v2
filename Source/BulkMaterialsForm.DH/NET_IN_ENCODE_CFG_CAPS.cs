// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ENCODE_CFG_CAPS

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ENCODE_CFG_CAPS
{
	public uint dwSize;

	public int nChannelId;

	public int nStreamType;

	public IntPtr pchEncodeJson;
}
