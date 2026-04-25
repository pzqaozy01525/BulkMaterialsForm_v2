// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_AUDIO_ENCODE_FORMAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_AUDIO_ENCODE_FORMAT
{
	public byte abCompression;

	public byte abDepth;

	public byte abFrequency;

	public byte abMode;

	public byte abFrameType;

	public byte abPacketPeriod;

	public byte abChannels;

	public byte abMix;

	public EM_CFG_AUDIO_FORAMT emCompression;

	public int nDepth;

	public int nFrequency;

	public int nMode;

	public int nFrameType;

	public int nPacketPeriod;

	public int nChannelsNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public uint[] arrChannels;

	public bool bMix;
}
