// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PLAYER_OPEN

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PLAYER_OPEN
{
	public uint dwSize;

	public IntPtr lPlayerID;

	public IntPtr pszDevice;

	public NET_PLAYER_OPEN_CONDITION stuCondition;

	public bool bDeviceInfo;

	public NET_REMOTE_DEVICE stuDeviceInfo;

	public EM_SPLIT_TRANS_MODE emTransferMode;

	public EM_SPLIT_CONNECT_TYPE emConnectType;

	public EM_SRC_PUSHSTREAM_TYPE emPushStream;
}
