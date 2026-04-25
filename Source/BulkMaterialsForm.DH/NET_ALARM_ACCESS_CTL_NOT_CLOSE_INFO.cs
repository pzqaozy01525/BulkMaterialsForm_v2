// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO
{
	public uint dwSize;

	public int nDoor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDoorName;

	public NET_TIME stuTime;

	public int nAction;

	public uint nEventID;

	public bool bRealUTC;

	public NET_TIME_EX RealUTC;
}
