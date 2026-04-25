// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MANUAL_SNAP_PARAMETER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MANUAL_SNAP_PARAMETER
{
	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string bySequence;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
	public byte[] byReserved;
}
