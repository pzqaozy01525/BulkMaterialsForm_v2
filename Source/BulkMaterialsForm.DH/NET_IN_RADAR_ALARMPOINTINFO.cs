// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_RADAR_ALARMPOINTINFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_RADAR_ALARMPOINTINFO
{
	public uint dwSize;

	public fRadarAlarmPointInfoCallBack cbAlarmPointInfo;

	public IntPtr dwUser;

	public int nChannel;
}
