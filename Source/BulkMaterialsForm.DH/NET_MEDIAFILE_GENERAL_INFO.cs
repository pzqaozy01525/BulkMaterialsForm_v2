// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIAFILE_GENERAL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MEDIAFILE_GENERAL_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;

	public int nObjectUrlNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2080)]
	public string szObjectUrls;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
	public byte[] byReserved;
}
