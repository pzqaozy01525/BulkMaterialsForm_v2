// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SMALL_PIC_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SMALL_PIC_INFO
{
	public int nSmallPicId;

	public NET_RECT stuRect;

	public EM_OBJECT_TYPE emDetectObjType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
	public byte[] bReserved;
}
