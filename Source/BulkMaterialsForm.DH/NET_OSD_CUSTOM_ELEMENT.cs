// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OSD_CUSTOM_ELEMENT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OSD_CUSTOM_ELEMENT
{
	public int nNameType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPrefix;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPostfix;

	public int nSeperaterCount;
}
