// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_EVENT_TITLE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_EVENT_TITLE
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szText;

	public NET_POINT stuPoint;

	public NET_SIZE stuSize;

	public NET_COLOR_RGBA stuFrontColor;

	public NET_COLOR_RGBA stuBackColor;
}
