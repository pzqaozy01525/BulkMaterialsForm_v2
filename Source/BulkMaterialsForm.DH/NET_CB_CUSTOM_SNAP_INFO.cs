// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CB_CUSTOM_SNAP_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CB_CUSTOM_SNAP_INFO
{
	public uint nChannelID;

	public NET_TIME stuSnapTime;

	public EM_CUSTOM_SNAP_TYPE emCustomSnapType;

	public IntPtr pDetailInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserve;
}
