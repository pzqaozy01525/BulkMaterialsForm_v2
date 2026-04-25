// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_POWER_STATUS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_POWER_STATUS
{
	public uint dwSize;

	public bool bEnable;

	public int nCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_POWER_INFO[] stuPowers;

	public int nBatteryNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_BATTERY_INFO[] stuBatteries;
}
