// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_BUS_SHARP_DECELERATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_BUS_SHARP_DECELERATE_INFO
{
	public uint dwSize;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public NET_TIME_EX stuStartTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserver;
}
