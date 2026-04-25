// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CTRL_ACCESS_OPEN

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CTRL_ACCESS_OPEN
{
	public uint dwSize;

	public int nChannelID;

	public IntPtr szTargetID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public EM_OPEN_DOOR_TYPE emOpenDoorType;

	public EM_OPEN_DOOR_DIRECTION emOpenDoorDirection;

	public EM_REMOTE_CHECK_CODE emRemoteCheckCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szShortNumber;
}
