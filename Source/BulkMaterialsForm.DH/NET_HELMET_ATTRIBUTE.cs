// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HELMET_ATTRIBUTE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HELMET_ATTRIBUTE
{
	public EM_WORK_HELMET_STATE emHelmetState;

	public EM_CLOTHES_COLOR emHelmetColor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
