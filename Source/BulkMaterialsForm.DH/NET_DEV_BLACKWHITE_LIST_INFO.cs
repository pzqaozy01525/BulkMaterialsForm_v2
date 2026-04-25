// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_BLACKWHITE_LIST_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_BLACKWHITE_LIST_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 240)]
	public string szFile;

	public int nFileSize;

	public byte byFileType;

	public byte byAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 126)]
	public byte[] byReserved;
}
