// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_PASSENGER_CARD_CHECK

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_PASSENGER_CARD_CHECK
{
	public bool bEventConfirm;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCardNum;

	public NET_GPS_STATUS_INFO stuGPS;

	public NET_TIME_EX UTC;

	public int nTime;

	public EM_PASSENGER_CARD_CHECK_TYPE emType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szMac;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1012)]
	public byte[] byReserver;
}
