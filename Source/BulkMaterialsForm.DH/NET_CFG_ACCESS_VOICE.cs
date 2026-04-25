// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESS_VOICE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESS_VOICE
{
	public EM_CFG_EM_VOICE_ID emCurrentVoiceID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_CFG_ACCESS_VOICE_INFO[] arrayVoiceInfo;

	public uint nVoiceCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
