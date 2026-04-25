// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PTZ_PRIVACY_MASKING

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PTZ_PRIVACY_MASKING
{
	public bool bPrivacyMasking;

	public bool bSetColorSupport;

	public bool abMaskType;

	public int nMaskTypeCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_EM_MASK_TYPE[] emMaskTypes;

	public bool bSetMosaicSupport;

	public bool bSetColorIndependent;

	public bool abMosaicType;

	public int nMosaicTypeCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_EM_MOSAIC_TYPE[] emMosaicType;
}
