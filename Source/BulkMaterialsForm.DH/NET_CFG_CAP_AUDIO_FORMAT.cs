// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_CAP_AUDIO_FORMAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_CAP_AUDIO_FORMAT
{
	public EM_TALK_AUDIO_TYPE emCompression;

	public int nPropertyNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_CFG_AUDIO_PROPERTY[] stuProperty;
}
