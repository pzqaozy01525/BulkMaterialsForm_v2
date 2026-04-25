// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WPAN_ACCESSORY_BUTTON_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WPAN_ACCESSORY_BUTTON_INFO
{
	public bool bEnable;

	public EM_BUTTON_ALARM_TYPE emType;

	public uint nSirenLinkageNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public int[] nSirenLinkage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byReserved;
}
