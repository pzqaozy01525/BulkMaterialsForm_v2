// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FIREPROOF_CLOTHES

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FIREPROOF_CLOTHES
{
	public EM_FIREPROOF_CLOTHES_STATE emHasFireProofClothes;

	public EM_CLOTHES_COLOR emFireProofClothesColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szReserved;
}
