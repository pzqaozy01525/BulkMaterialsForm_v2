// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HSJC_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HSJC_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szHSJCReportDate;

	public int nHSJCExpiresIn;

	public int nHSJCResult;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szHSJCInstitution;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 768)]
	public string szReserved;
}
