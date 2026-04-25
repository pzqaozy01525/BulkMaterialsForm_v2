// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_CARDINFO_START_FIND

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_CARDINFO_START_FIND
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	private EM_A_NET_ACCESSCTLCARD_TYPE emType;
}
