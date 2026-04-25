// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OSD_CUSTOM_TITLE_TEXT_ALIGN

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OSD_CUSTOM_TITLE_TEXT_ALIGN
{
	public uint dwSize;

	public int nCustomTitleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public EM_TITLE_TEXT_ALIGNTYPE[] emTextAlign;
}
