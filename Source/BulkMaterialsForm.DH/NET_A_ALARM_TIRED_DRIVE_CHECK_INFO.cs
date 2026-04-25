// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_TIRED_DRIVE_CHECK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_TIRED_DRIVE_CHECK_INFO
{
	public bool bEventConfirm;

	public int nAction;

	public int nDriveTime;

	public NET_GPS_STATUS_INFO stuGPS;

	public NET_TIME_EX UTC;

	public int nTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] reserved;
}
