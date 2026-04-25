// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TASK_CUSTOM_DATA

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TASK_CUSTOM_DATA
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szClientIP;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
