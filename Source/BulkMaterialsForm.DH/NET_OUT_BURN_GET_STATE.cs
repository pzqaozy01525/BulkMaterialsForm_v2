// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_BURN_GET_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_BURN_GET_STATE
{
	public uint dwSize;

	public EM_NET_BURN_STATE emState;

	public EM_NET_BURN_ERROR_CODE emErrorCode;

	public uint dwDevMask;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nChannels;

	public int nChannelCount;

	public EM_NET_BURN_MODE emMode;

	public EM_NET_BURN_RECORD_PACK emPack;

	public int nFileIndex;

	public NET_TIME stuStartTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_BURN_DEV_STATE[] stuDevState;

	public int nRemainTime;

	public EM_NET_BURN_EXTMODE emExtMode;
}
