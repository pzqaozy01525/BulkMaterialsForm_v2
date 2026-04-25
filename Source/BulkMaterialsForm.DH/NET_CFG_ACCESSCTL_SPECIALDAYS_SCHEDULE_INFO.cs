// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESSCTL_SPECIALDAYS_SCHEDULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESSCTL_SPECIALDAYS_SCHEDULE_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSchduleName;

	public bool bSchdule;

	public int nGroupNo;

	public int nTimeSection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public NET_TSECT[] stuTimeSection;

	public int nDoorNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public int[] nDoors;
}
