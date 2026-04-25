// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_AUDIO_PLAY_PATH

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_AUDIO_PLAY_PATH
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPath;

	public bool bSupportUpload;

	public int nMaxFileUploadNum;

	public int nMaxUploadFileSize;
}
