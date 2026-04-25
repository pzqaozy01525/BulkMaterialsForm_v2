// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_SPLIT_WND_SOURCE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_SPLIT_WND_SOURCE
{
	public uint dwSize;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szControlID;

	public int nVideoChannel;

	public int nVideoStream;

	public int nAudioChannel;

	public int nAudioStream;

	public int nUniqueChannel;

	public bool bRemoteDevice;

	public NET_REMOTE_DEVICE stuRemoteDevice;

	public NET_RECT stuSRect;

	public int nInterval;
}
