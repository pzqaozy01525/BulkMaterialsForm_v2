// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_GET_UPNPSTATUS_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_GET_UPNPSTATUS_INFO
{
	public uint dwSize;

	public bool bWorking;

	public EM_UPNP_STATUS_TYPE emStatus;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szInnerAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szOuterAddress;

	public uint nMaxPortMapStatus;

	public uint nReturnNum;

	public IntPtr pemPortMapStatus;
}
