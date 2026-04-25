// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CUSTOM_EDUCATION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CUSTOM_EDUCATION_INFO
{
	public EM_EDUCATION_INFO_TYPE emInfoType;

	public int nStudentSeatNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szInfoContent;

	public EM_CUSTOM_EDUCATION_VOICE_TYPE emVoiceType;
}
