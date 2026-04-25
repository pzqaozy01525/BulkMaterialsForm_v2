// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OPENDOOR_MATCHINFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OPENDOOR_MATCHINFO_EX
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserNameEx;

	public EM_CUSTOM_MEDICAL_VOICE_TYPE emVoiceType;

	public NET_ANTIGEN_INFO stuAntigenInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szVoiceTTSMessage;

	public uint nCheckLocal;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1616)]
	public byte[] bReserved;
}
