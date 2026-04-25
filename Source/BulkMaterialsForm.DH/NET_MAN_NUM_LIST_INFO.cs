// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MAN_NUM_LIST_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MAN_NUM_LIST_INFO
{
	public NET_RECT stuBoudingBox;

	public int nStature;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szReversed;
}
