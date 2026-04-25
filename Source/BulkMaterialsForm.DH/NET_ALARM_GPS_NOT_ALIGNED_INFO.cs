// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_GPS_NOT_ALIGNED_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_GPS_NOT_ALIGNED_INFO
{
	public int nAction;

	public NET_TIME_EX stuTime;

	public NET_TIME_EX stuStartTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 988)]
	public byte[] byReserver;
}
