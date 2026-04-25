// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FILE_SUMMARY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FILE_SUMMARY_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szKey;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szValue;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] bReserved;
}
