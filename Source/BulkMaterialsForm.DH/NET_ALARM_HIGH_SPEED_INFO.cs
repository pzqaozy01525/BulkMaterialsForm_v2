// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_HIGH_SPEED_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_HIGH_SPEED_INFO
{
	public int nAction;

	public NET_TIME_EX stuTime;

	public double dbPTS;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public int nSpeedLimit;

	public int nCurSpeed;

	public int nMaxSpeed;

	public NET_TIME_EX stuStartTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 472)]
	public byte[] byReserver;
}
