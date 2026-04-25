// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OSD_TIME_TITLE

namespace BulkMaterialsForm.DH;

public struct NET_OSD_TIME_TITLE
{
	public uint dwSize;

	public EM_OSD_BLEND_TYPE emOsdBlendType;

	public bool bEncodeBlend;

	public NET_COLOR_RGBA stuFrontColor;

	public NET_COLOR_RGBA stuBackColor;

	public NET_RECT stuRect;

	public bool bShowWeek;
}
