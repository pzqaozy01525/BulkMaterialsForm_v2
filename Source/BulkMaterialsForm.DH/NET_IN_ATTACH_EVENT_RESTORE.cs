// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTACH_EVENT_RESTORE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTACH_EVENT_RESTORE
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
	public string szUuid;
}
