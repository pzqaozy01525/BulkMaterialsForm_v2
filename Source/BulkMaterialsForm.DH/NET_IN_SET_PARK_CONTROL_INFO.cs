// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SET_PARK_CONTROL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SET_PARK_CONTROL_INFO
{
	public uint dwSize;

	public int nScreenShowInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_SCREEN_SHOW_INFO[] stuScreenShowInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public int nBroadcastInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_BROADCAST_INFO[] stuBroadcastInfo;
}
