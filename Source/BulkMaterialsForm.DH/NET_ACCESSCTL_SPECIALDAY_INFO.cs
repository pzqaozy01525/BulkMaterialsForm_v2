// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESSCTL_SPECIALDAY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESSCTL_SPECIALDAY_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDayName;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
