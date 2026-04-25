// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_USERID

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_USERID
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szUserID;
}
