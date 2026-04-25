// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CUSTOM_TITLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CUSTOM_TITLE_INFO
{
	public bool bEncodeBlend;

	public NET_COLOR_RGBA stuFrontColor;

	public NET_COLOR_RGBA stuBackColor;

	public NET_RECT stuRect;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szText;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
