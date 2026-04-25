// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_USER_DEF_TITLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_USER_DEF_TITLE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szText;

	public bool bEncodeBlend;

	public bool bPreviewBlend;

	public NET_RECT stuRect;

	public NET_COLOR_RGBA stuFrontColor;

	public NET_COLOR_RGBA stuBackColor;

	public EM_TITLE_TEXT_ALIGNTYPE emTextAlign;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 516)]
	public byte[] byReserved;
}
