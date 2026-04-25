// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WEEK_TSECT_ARRAY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WEEK_TSECT_ARRAY
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;
}
