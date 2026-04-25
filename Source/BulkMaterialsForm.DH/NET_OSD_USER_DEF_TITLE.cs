// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OSD_USER_DEF_TITLE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OSD_USER_DEF_TITLE
{
	public uint dwSize;

	public int nUserDefTitleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_USER_DEF_TITLE_INFO[] stuUserDefTitle;
}
