// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TIME_SECTION_ARRAY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TIME_SECTION_ARRAY
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_TIME_SECTION[] stuRemoteTimeSection;
}
