// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SCADA_ALARM_ATTACH_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SCADA_ALARM_ATTACH_INFO
{
	public uint dwSize;

	public fSCADAAlarmAttachInfoCallBack cbCallBack;

	public IntPtr dwUser;
}
