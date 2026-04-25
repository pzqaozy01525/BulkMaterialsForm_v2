// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FIND_RECORD_ACCESSCTLCARD_CONDITION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FIND_RECORD_ACCESSCTLCARD_CONDITION
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public bool bIsValid;

	public bool abCardNo;

	public bool abUserID;

	public bool abIsValid;
}
