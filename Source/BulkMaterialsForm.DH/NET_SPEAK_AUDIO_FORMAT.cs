// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SPEAK_AUDIO_FORMAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SPEAK_AUDIO_FORMAT
{
	public EM_SAFE_BELT_STATE emFormat;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
