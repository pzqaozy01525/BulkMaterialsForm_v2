// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TIME_SCHEDULE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TIME_SCHEDULE
{
	public bool bEnableHoliday;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public NET_TSECT[] stuTimeSection;
}
