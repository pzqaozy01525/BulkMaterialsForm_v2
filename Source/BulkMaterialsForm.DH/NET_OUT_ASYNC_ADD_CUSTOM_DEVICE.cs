// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_ASYNC_ADD_CUSTOM_DEVICE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_ASYNC_ADD_CUSTOM_DEVICE
{
	public uint dwSize;

	public int nLogicChannelNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] nLogicChannels;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;
}
