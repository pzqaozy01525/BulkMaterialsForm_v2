// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SPEAK_AUDIO_PLAY_PATH

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SPEAK_AUDIO_PLAY_PATH
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPath;

	public bool bSupportUpload;

	public int nMaxFileUploadNum;

	public int nMaxUploadFileSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 756)]
	public byte[] byReserved;
}
