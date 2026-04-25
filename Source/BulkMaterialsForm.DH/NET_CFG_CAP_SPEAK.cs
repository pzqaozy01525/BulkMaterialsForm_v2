// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_CAP_SPEAK

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_CAP_SPEAK
{
	public int nAudioCapNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_CFG_CAP_AUDIO_FORMAT[] stuAudioCap;

	public int nAudioPlayPathNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CFG_AUDIO_PLAY_PATH[] stuAudioPlayPath;

	public NET_CFG_VOICE_PLAY_PLAN stuVoicePlayPlan;
}
