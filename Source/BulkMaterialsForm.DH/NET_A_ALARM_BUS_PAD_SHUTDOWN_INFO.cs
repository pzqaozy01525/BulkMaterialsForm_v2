// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BUS_PAD_SHUTDOWN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BUS_PAD_SHUTDOWN_INFO
{
	public int nDelayTime;

	public bool bConfirm;

	public NET_TIME_EX stuUtcTime;

	public uint dwUtc;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
