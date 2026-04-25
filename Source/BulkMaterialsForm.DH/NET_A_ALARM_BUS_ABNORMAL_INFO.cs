// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BUS_ABNORMAL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BUS_ABNORMAL_INFO
{
	public uint dwSize;

	public EM_ALARM_BUS_ABNORMAL_EVENT_TYPE emEventType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCarNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szLineID;

	public EM_A_NET_LINE_DIRECTION emLineDirection;

	public NET_TIME_EX stuTime;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;
}
