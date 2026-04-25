// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PARKINGSPACE_LIGHT_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PARKINGSPACE_LIGHT_STATE
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] bySpaceFreeLinght;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] bySpaceFullLinght;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] bySpaceOverLineLight;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] bySpaceOrderLight;

	public int nNetPortNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byNetPortAbortLight;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] bySpaceSpecialLight;
}
