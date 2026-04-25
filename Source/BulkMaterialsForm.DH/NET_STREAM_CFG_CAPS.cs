// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_STREAM_CFG_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_STREAM_CFG_CAPS
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public int[] nAudioCompressionTypes;

	public int nAudioCompressionTypeNum;

	public int dwEncodeModeMask;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_RESOLUTION_INFO[] stuResolutionTypes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public int[] nResolutionFPSMax;

	public int nResolutionTypeNum;

	public int nMaxBitRateOptions;

	public int nMinBitRateOptions;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bH264ProfileRank;

	public int nH264ProfileRankNum;

	public int nCifPFrameMaxSize;

	public int nCifPFrameMinSize;

	public int nFPSMax;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_RESOLUTION[] stuIndivResolutionTypes;

	public bool abIndivResolution;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public int[] nIndivResolutionNums;
}
