// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_STARTSERACH_DEVICE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_STARTSERACH_DEVICE
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szLocalIp;

	public fSearchDevicesCBEx cbSearchDevices;

	public IntPtr pUserData;

	public EM_SEND_SEARCH_TYPE emSendType;
}
