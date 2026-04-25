// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCADA_NOTIFY_POINT_INFO_LIST

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SCADA_NOTIFY_POINT_INFO_LIST
{
	public uint dwSize;

	public int nList;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_SCADA_NOTIFY_POINT_INFO[] stuList;
}
