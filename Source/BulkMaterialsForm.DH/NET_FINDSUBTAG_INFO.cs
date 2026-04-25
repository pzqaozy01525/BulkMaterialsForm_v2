// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FINDSUBTAG_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FINDSUBTAG_INFO
{
	public NET_TIME stuStartTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSubTagName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
