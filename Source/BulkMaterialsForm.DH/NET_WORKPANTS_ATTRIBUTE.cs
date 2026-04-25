// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WORKPANTS_ATTRIBUTE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WORKPANTS_ATTRIBUTE
{
	public EM_WORKPANTS_STATE emWorkPantsState;

	public EM_CLOTHES_COLOR emWorkPantsColor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
