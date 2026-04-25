// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OSD_CFG_PTZ_COORDINATES

namespace BulkMaterialsForm.DH;

public struct NET_OSD_CFG_PTZ_COORDINATES
{
	public uint dwSize;

	public int nDisplayTime;

	public bool bEncodeBlend;

	public bool bPreviewBlend;

	public NET_COLOR_RGBA stuFrontColor;

	public NET_COLOR_RGBA stuBackColor;

	public NET_RECT stuRect;
}
