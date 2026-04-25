// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_NET_TIME_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_NET_TIME_EX
{
	public uint dwYear;

	public uint dwMonth;

	public uint dwDay;

	public uint dwHour;

	public uint dwMinute;

	public uint dwSecond;

	public uint dwMillisecond;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public uint[] dwReserved;
}
