// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESS_CARD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESS_CARD_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public EM_ACCESSCTLCARD_TYPE emType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szDynamicCheckCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
	public byte[] byReserved;
}
