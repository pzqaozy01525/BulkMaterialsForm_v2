// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WPAN_ARMING_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WPAN_ARMING_INFO
{
	public EM_ARMING_TYPE emType;

	public bool bEnable;

	public bool bDelayEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byReserved;
}
