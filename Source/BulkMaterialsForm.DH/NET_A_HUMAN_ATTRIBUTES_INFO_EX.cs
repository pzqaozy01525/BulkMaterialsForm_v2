// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_HUMAN_ATTRIBUTES_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_HUMAN_ATTRIBUTES_INFO_EX
{
	public EM_HAS_RAINCOAT emHasRainCoat;

	public EM_CLOTHES_COLOR emMaskColor;

	public uint nQeScore;

	public uint nIntegrality;

	public EM_ASSOCIATED_RECORD_SOURCE emExtRecordSource;

	public EM_CLOTHES_COLOR emCapColor;

	public EM_UNIFORM_STYLE emUniformStyle;

	public int nHumanClarity;

	public int nHumanCompleteScore;

	public bool bIsRelatedFace;

	public EM_COAT_TYPE emCoatStyle;

	public EM_SHOES_TYPE emShoesType;

	public EM_CLOTHES_COLOR emShoesColor;

	public EM_AGE_SEG emAgeSeg;

	public int nMask;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 984)]
	public byte[] byReserved;
}
