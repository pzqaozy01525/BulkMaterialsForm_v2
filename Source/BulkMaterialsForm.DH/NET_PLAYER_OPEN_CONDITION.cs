// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PLAYER_OPEN_CONDITION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PLAYER_OPEN_CONDITION
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDevice;

	public int nChannel;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public EM_NET_STREAM_TYPE emStreamType;

	public int nEventNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] nEvent;
}
