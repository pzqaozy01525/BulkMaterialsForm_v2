// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MONITORWALL_OUTPUT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MONITORWALL_OUTPUT
{
	public int nStructSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;

	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public bool bIsVirtual;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
	public string szAddress;

	public NET_MONITOR_WALL_OUT_MODE_INFO stuOutMode;
}
