// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_TALKDECODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_TALKDECODE_INFO
{
	public EM_TALK_CODING_TYPE encodeType;

	public int nAudioBit;

	public uint dwSampleRate;

	public int nPacketPeriod;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
	public byte[] reserved;
}
