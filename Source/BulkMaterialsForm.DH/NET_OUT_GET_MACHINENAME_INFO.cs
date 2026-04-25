// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GET_MACHINENAME_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GET_MACHINENAME_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;
}
