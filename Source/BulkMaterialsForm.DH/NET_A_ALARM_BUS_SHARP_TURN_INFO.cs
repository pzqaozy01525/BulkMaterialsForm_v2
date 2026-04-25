// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BUS_SHARP_TURN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BUS_SHARP_TURN_INFO
{
	public uint dwSize;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public NET_TIME_EX stuTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;
}
