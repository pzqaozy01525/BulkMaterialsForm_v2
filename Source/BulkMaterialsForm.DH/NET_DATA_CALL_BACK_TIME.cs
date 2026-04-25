// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DATA_CALL_BACK_TIME

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DATA_CALL_BACK_TIME
{
	public uint dwYear;

	public uint dwMonth;

	public uint dwDay;

	public uint dwHour;

	public uint dwMinute;

	public uint dwSecond;

	public uint dwMillisecond;

	public uint dwPTS;

	public uint dwDTS;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public uint[] dwReserved;
}
