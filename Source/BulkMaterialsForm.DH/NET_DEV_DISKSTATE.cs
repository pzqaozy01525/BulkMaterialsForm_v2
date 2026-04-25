// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_DISKSTATE

namespace BulkMaterialsForm.DH;

public struct NET_DEV_DISKSTATE
{
	public uint dwVolume;

	public uint dwFreeSpace;

	public byte dwStatus;

	public byte bDiskNum;

	public byte bSubareaNum;

	public byte bSignal;
}
