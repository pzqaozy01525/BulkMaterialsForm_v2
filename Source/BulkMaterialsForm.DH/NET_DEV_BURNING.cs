// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_BURNING

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_BURNING
{
	public uint dwDriverType;

	public uint dwBusType;

	public uint dwTotalSpace;

	public uint dwRemainSpace;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] dwDriverName;

	public EM_NET_BURN_DEV_TRAY_TYPE emTrayType;

	public EM_NET_BURN_DEV_OPERATE_TYPE emOperateType;
}
