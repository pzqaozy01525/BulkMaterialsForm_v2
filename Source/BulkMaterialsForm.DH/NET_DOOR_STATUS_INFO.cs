// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DOOR_STATUS_INFO

namespace BulkMaterialsForm.DH;

public struct NET_DOOR_STATUS_INFO
{
	public uint dwSize;

	public int nChannel;

	public EM_NET_DOOR_STATUS_TYPE emStateType;
}
