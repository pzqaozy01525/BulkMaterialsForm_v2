// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_NETINTERFACE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_NETINTERFACE_INFO
{
	public int dwSize;

	public bool bValid;

	public bool bVirtual;

	public int nSpeed;

	public int nDHCPState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
	public string szMAC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
	public string szSSID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szConnStatus;

	public int nSupportedModeNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
	public string szSupportedModes;

	public bool bSupportLongPoE;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szNetCardName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szModuleName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szIMEI;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
	public string szICCID;
}
