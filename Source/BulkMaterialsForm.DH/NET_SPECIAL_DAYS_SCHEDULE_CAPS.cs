// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SPECIAL_DAYS_SCHEDULE_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SPECIAL_DAYS_SCHEDULE_CAPS
{
	public bool bSupport;

	public int nMaxSpecialDaysSchedules;

	public int nMaxTimePeriodsPerDay;

	public int nMaxSpecialDayGroups;

	public int nMaxDaysInSpecialDayGroup;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
