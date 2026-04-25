// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GET_SOFTWAREVERSION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GET_SOFTWAREVERSION_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szVersion;

	public NET_TIME stuBuildDate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szWebVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSecurityVersion;

	public int nPeripheralNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_PERIPHERAL_VERSIONS[] stuPeripheralVersions;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szAlgorithmTrainingVersion;
}
