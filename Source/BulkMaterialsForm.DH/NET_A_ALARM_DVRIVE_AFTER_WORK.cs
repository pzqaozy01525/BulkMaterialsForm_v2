// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_DVRIVE_AFTER_WORK

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_DVRIVE_AFTER_WORK
{
	public bool bEventConfirm;

	public NET_GPS_STATUS_INFO stuGPS;

	public NET_TIME_EX stuUtc;

	public uint dwUtc;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] reserved;
}
