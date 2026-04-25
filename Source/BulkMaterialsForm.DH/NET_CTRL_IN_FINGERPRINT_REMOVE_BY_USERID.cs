// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CTRL_IN_FINGERPRINT_REMOVE_BY_USERID

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CTRL_IN_FINGERPRINT_REMOVE_BY_USERID
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;
}
