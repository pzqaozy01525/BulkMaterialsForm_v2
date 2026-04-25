// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FINDTAG_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FINDTAG_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szContext;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public int nSubtagInfoCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_FINDSUBTAG_INFO[] stuSubTagInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
