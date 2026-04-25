// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_LIGHTING_V2_DAYNIGHT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_LIGHTING_V2_DAYNIGHT
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public NET_CFG_LIGHTING_V2_UNIT[] anLightInfo;

	public int nLightInfoLen;
}
