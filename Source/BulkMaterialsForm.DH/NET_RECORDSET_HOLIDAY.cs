// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORDSET_HOLIDAY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RECORDSET_HOLIDAY
{
	public uint dwSize;

	public int nRecNo;

	public int nDoorNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] sznDoors;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szHolidayNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szHolidayName;
}
