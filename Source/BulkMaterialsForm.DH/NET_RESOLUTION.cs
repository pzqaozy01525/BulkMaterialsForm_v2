// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RESOLUTION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RESOLUTION
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_RESOLUTION_INFO[] stuResolutionTypes;
}
