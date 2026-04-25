// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_LIGHTING_V2_UNIT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_LIGHTING_V2_UNIT
{
	public EM_CFG_LC_LIGHT_TYPE emLightType;

	public EM_CFG_LC_MODE emMode;

	public int nCorrection;

	public int nSensitive;

	public int nLightSwitchDelay;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_LIGHT_INFO[] anNearLight;

	public int nNearLightLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_LIGHT_INFO[] anMiddleLight;

	public int nMiddleLightLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_LIGHT_INFO[] anFarLight;

	public int nFarLightLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
