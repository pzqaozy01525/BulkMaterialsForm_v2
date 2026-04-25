// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WINDOW_COLLECTION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WINDOW_COLLECTION
{
	public uint dwSize;

	public int nWindowID;

	public bool bWndEnable;

	public NET_RECT stuRect;

	public bool bDirectable;

	public int nZOrder;

	public bool bSrcEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;

	public int nVideoChannel;

	public int nVideoStream;

	public int nAudioChannel;

	public int nAudioStream;

	public int nUniqueChannel;

	public NET_MONITOR_WALL_DEVICE_INFO stuDeviceInfo;

	public int nInterval;
}
