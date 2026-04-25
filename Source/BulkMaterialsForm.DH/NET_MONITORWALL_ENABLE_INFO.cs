// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MONITORWALL_ENABLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MONITORWALL_ENABLE_INFO
{
	public uint dwSize;

	public bool bEanble;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;
}
