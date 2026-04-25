// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WPAN_ACCESSORY_LOCK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WPAN_ACCESSORY_LOCK_INFO
{
	public bool bLockLoginEnable;

	public uint nLoginFailLockTime;

	public byte byLockLoginTimes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 31)]
	public byte[] byReserved;
}
