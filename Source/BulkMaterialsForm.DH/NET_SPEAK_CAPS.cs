// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SPEAK_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SPEAK_CAPS
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_SPEAK_AUDIO_FORMAT[] stuAudioFormats;

	public int nAudioFormatNum;

	public int nAudioPlayPathNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_SPEAK_AUDIO_PLAY_PATH[] stuAudioPlayPaths;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
