// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_AV_CFG_EventTitle

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_AV_CFG_EventTitle
{
	public int nStructSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szText;

	public NET_AV_CFG_Point stuPoint;

	public NET_AV_CFG_Size stuSize;

	public NET_AV_CFG_Color stuFrontColor;

	public NET_AV_CFG_Color stuBackColor;
}
