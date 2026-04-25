// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_URGENCY_ALARM_EX2

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_URGENCY_ALARM_EX2
{
	public uint dwSize;

	public NET_TIME stuTime;

	public uint nID;

	public int nAction;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szImei;

	public uint nDistance;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPlateNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szReplyNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szLine;
}
