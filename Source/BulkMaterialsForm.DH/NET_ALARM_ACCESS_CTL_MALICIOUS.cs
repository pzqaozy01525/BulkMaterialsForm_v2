// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_ACCESS_CTL_MALICIOUS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_ACCESS_CTL_MALICIOUS
{
	public int nAction;

	public NET_TIME_EX stuTime;

	public NET_ACCESS_METHOD emMethod;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSerialNum;

	public int nChannel;

	public bool bRealUTC;

	public NET_TIME_EX RealUTC;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 970)]
	public byte[] byReserved;
}
