// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_EVENT_TITLE_NEW

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_EVENT_TITLE_NEW
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szText;

	public NET_CFG_POLYGON stuPoint;

	public NET_CFG_SIZE stuSize;

	public NET_CFG_RGBA stuFrontColor;

	public NET_CFG_RGBA stuBackColor;
}
