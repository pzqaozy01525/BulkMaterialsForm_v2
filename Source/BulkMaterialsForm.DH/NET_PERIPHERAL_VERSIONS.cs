// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PERIPHERAL_VERSIONS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PERIPHERAL_VERSIONS
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVersion;

	public EM_PERIPHERAL_TYPE emPeripheralType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
	public byte[] byReserved;
}
