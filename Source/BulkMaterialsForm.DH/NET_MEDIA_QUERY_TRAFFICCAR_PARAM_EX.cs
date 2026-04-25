// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIA_QUERY_TRAFFICCAR_PARAM_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MEDIA_QUERY_TRAFFICCAR_PARAM_EX
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szViolationCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szCountry;

	public bool bOnlySupportRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 968)]
	public byte[] byReserved;
}
