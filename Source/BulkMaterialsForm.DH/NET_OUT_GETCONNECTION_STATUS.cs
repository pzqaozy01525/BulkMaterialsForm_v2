// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GETCONNECTION_STATUS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GETCONNECTION_STATUS
{
	public uint dwSize;

	public uint nChannelNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] nStatus;
}
