// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VACCINE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VACCINE_INFO
{
	public int nVaccinateFlag;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szVaccineName;

	public int nDateCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szVaccinateDate;

	public int nVaccineIntensifyFlag;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1020)]
	public string szReserved;
}
