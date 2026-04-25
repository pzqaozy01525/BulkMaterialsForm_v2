// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_ADD_ANALYSE_TASK

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_ADD_ANALYSE_TASK
{
	public uint dwSize;

	public uint nTaskID;

	public uint nVirtualChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szUrl;
}
