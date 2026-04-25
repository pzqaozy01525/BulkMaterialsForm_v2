// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_SMART_HARDDISK

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_SMART_HARDDISK
{
	public byte nDiskNum;

	public byte byRaidNO;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public NET_DEV_DEVICE_INFO deviceInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
	public NET_DEV_SMART_VALUE[] smartValue;
}
