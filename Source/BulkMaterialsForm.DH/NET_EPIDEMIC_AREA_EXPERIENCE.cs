// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EPIDEMIC_AREA_EXPERIENCE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EPIDEMIC_AREA_EXPERIENCE
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szAddress;

	public NET_TIME stuTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
