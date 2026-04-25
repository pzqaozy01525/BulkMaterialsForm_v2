// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OSD_CUSTOM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OSD_CUSTOM_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_OSD_CUSTOM_GENERAL_INFO[] stGeneralInfos;

	public int nGeneralInfoNum;
}
