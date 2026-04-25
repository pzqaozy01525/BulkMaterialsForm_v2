// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CUSTOM_VISITOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CUSTOM_VISITOR_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szVisitorName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVisitorTel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVisitorStartTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVisitorEndTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szVisitorAccessFor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVisitorCitizenID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRespondentName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRespondentTel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRespondentCompany;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRespondentSection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
