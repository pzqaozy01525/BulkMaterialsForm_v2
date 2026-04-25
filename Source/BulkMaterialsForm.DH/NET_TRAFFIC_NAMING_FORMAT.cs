// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFIC_NAMING_FORMAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFIC_NAMING_FORMAT
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szFormat;
}
