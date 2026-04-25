// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_ACCESS_CTL_STATUS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_ACCESS_CTL_STATUS_INFO
{
	public uint dwSize;

	public int nDoor;

	public NET_TIME stuTime;

	public EM_A_NET_ACCESS_CTL_STATUS_TYPE emStatus;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szSerialNumber;

	public bool bRealUTC;

	public NET_TIME_EX RealUTC;
}
