// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SCADA_ATTACH_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SCADA_ATTACH_INFO
{
	public uint dwSize;

	public fSCADAAttachInfoCallBack cbCallBack;

	public EM_NET_SCADA_POINT_TYPE emPointType;

	public IntPtr dwUser;
}
