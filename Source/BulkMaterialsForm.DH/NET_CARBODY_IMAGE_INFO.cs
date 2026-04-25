// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CARBODY_IMAGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CARBODY_IMAGE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szFilePath;

	public int nLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 252)]
	public string szReserved;
}
