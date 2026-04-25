// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_ACCESS_CTL_DURESS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_ACCESS_CTL_DURESS_INFO
{
	public uint dwSize;

	public int nDoor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDoorName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	public NET_TIME stuTime;

	public uint nEventID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
	public string szUserID;

	public bool bRealUTC;

	public NET_TIME_EX RealUTC;
}
