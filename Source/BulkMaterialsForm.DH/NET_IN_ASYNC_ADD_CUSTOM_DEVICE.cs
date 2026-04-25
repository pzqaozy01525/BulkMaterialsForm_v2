// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ASYNC_ADD_CUSTOM_DEVICE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ASYNC_ADD_CUSTOM_DEVICE
{
	public uint dwSize;

	public int nPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPassword;

	public EM_CUSTOM_DEV_PROTOCOL_TYPE emProtocolType;

	public int nRemoteChannelNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public int[] nRemoteChannels;

	public bool bSetLogicChannelStart;

	public int nLogicChannelStart;

	public NET_CUSTOM_DEV_VIDEO_INPUTS stuVideoInput;
}
