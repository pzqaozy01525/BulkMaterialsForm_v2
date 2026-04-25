// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ENCLOSURE_TIME_SCHEDULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ENCLOSURE_TIME_SCHEDULE_INFO
{
	public int nEnclosureID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;
}
