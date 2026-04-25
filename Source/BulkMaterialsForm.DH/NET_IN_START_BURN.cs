// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_START_BURN

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_START_BURN
{
	public uint dwSize;

	public uint dwDevMask;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nChannels;

	public int nChannelCount;

	public EM_NET_BURN_MODE emMode;

	public EM_NET_BURN_RECORD_PACK emPack;

	public EM_NET_BURN_EXTMODE emExtMode;
}
