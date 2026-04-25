// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_COMPANION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_COMPANION_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCompanionCard;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCompanionUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 120)]
	public string szCompanionName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
