// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANTIGEN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANTIGEN_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szAntigenReportDate;

	public int nAntigenStatus;

	public int nAntigenExpiresIn;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szResvered;
}
