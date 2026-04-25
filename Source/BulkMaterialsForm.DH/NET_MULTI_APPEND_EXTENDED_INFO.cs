// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MULTI_APPEND_EXTENDED_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MULTI_APPEND_EXTENDED_INFO
{
	public uint nToken;

	public EM_FACE_APPEND_STATE emState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 248)]
	public string szResvered;
}
