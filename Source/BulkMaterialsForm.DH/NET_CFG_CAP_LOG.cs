// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_CAP_LOG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct NET_CFG_CAP_LOG
{
	public uint dwMaxLogItems;

	public uint dwMaxPageItems;

	public bool bSupportStartNo;

	public bool bSupportTypeFilter;

	public bool bSupportTimeFilter;
}
