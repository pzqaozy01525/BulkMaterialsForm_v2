// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_SPLIT_WINDOW

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_SPLIT_WINDOW
{
	public uint dwSize;

	public bool bEnable;

	public int nWindowID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szControlID;

	public NET_RECT stuRect;

	public bool bDirectable;

	public int nZOrder;

	public NET_A_SPLIT_WND_SOURCE stuSource;

	public uint nOSDNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_SPLIT_OSD[] stuOSD;

	public bool bLock;

	public bool bDock;

	public bool bMeetingMode;

	public bool bAudioEnable;

	public bool bTourEnable;
}
