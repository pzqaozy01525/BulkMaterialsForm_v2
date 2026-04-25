// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_VERSION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_VERSION_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szDevSerialNo;

	public byte byDevType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDevType;

	public int nProtocalVer;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSoftWareVersion;

	public uint dwSoftwareBuildDate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPeripheralSoftwareVersion;

	public uint dwPeripheralSoftwareBuildDate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szGeographySoftwareVersion;

	public uint dwGeographySoftwareBuildDate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szHardwareVersion;

	public uint dwHardwareDate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szWebVersion;

	public uint dwWebBuildDate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDetailType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 192)]
	public byte[] reserved;
}
