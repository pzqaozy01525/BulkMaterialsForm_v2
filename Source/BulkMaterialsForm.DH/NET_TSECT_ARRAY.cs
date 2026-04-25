// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TSECT_ARRAY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TSECT_ARRAY
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public NET_TSECT[] stuTimeSection;
}
