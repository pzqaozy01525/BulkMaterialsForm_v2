// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_INFO_EXTEND

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_INFO_EXTEND
{
	public bool bRealUTC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string byReserved;

	public NET_TIME_EX stuRealUTC;

	public bool bIsEventsTypeValid;

	public uint szEventsType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1012)]
	public string szReserved;
}
