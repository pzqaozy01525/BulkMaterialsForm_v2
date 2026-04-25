// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_SEARCH_FILE_BYALIAS_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_SEARCH_FILE_BYALIAS_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved1;

	public uint nMaxCount;

	public uint nRetCount;

	public IntPtr pstuRecordInfo;
}
