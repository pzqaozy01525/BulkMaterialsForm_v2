// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_RF_JAMMING_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_RF_JAMMING_INFO
{
	public int nAction;

	public int nChannel;

	public NET_TIME_EX stuUTC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szDeviceName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
