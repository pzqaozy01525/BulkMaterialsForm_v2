// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_OPERATE_FACERECONGNITIONDB

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_OPERATE_FACERECONGNITIONDB
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUID;

	public int nErrorCodeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public EM_ERRORCODE_TYPE[] emErrorCodes;
}
