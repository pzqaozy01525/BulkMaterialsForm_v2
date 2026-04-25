// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PASSERBY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PASSERBY_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPasserbyUID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPasserbyGroupId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPasserbyGroupName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
