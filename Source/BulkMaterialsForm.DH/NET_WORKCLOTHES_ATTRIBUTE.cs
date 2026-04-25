// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WORKCLOTHES_ATTRIBUTE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WORKCLOTHES_ATTRIBUTE
{
	public EM_WORKCLOTHES_STATE emWorkClothesState;

	public EM_CLOTHES_COLOR emWorkClothColor;

	public EM_CLOTHES_LEGAL_STATE emWorkClothesLegalState;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
