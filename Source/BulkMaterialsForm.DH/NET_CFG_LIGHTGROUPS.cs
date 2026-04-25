// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_LIGHTGROUPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_LIGHTGROUPS
{
	public int nLightGroupId;

	public NET_CFG_RECT stuLightLocation;

	public int nDirection;

	public bool bExternalDetection;

	public bool bSwingDetection;

	public int nLightNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CFG_LIGHTATTRIBUTE[] stuLightAtrributes;
}
