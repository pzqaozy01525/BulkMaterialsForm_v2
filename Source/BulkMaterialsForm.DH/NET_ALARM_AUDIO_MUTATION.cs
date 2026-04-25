// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_AUDIO_MUTATION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_AUDIO_MUTATION
{
	public uint dwStructSize;

	public uint dwAction;

	public uint dwChannelID;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	public EM_AUDIO_MUTATION_ALARM_TYPE emAudioType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string reserved;
}
