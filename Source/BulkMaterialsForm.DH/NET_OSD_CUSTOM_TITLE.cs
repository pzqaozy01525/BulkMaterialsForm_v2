// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OSD_CUSTOM_TITLE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OSD_CUSTOM_TITLE
{
	public uint dwSize;

	public EM_OSD_BLEND_TYPE emOsdBlendType;

	public int nCustomTitleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CUSTOM_TITLE_INFO[] stuCustomTitle;
}
