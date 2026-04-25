// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_OVER_TEMPERATURE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_OVER_TEMPERATURE_INFO
{
	public int nAction;

	public int nChannel;

	public NET_TIME_EX stuUTC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	public int nTemperatureType;

	public int nAreaInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_EVENT_AREAR_INFO[] stuAreaInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
