// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_REGISTERSERVER_VEHICLE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_REGISTERSERVER_VEHICLE
{
	public bool bEnable;

	public bool bRepeatEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szDeviceID;

	public int nSendInterval;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szAddress;

	public int nPort;

	public EM_CFG_SENDPOLICY emSendPolicy;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szTestAddress;

	public int nTestPort;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
