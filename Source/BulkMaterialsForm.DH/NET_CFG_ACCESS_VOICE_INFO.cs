// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESS_VOICE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESS_VOICE_INFO
{
	public EM_CFG_EM_VOICE_ID emVoiceID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szVoiceContent;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szFileName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
