// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SPLIT_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SPLIT_CAPS
{
	public uint dwSize;

	public int nModeCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public EM_SPLIT_MODE[] emSplitMode;

	public int nMaxSourceCount;

	public int nFreeWindowCount;

	public bool bCollectionSupported;

	public uint dwDisplayType;

	public int nPIPModeCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public EM_SPLIT_MODE[] emPIPSplitMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] nInputChannels;

	public int nInputChannelCount;

	public int nBootModeCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public EM_SPLIT_MODE[] emBootMode;
}
