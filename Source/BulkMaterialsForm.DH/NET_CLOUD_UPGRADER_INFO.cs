// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CLOUD_UPGRADER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CLOUD_UPGRADER_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPackageURL;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPackageID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCheckSum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
