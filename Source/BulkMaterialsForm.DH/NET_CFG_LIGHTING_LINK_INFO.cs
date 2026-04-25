// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_LIGHTING_LINK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_LIGHTING_LINK_INFO
{
	public bool bEnable;

	public EM_FILCKERLIGHT_TYPE emFilckerLightType;

	public EM_LIGHTLINK_TYPE emLightlinkType;

	public float fFilckerIntevalTime;

	public int nFilckerTimes;

	public uint nLightDuration;

	public uint nLightBright;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
	public NET_CFG_TIME_SECTION[] stuWhiteLightTimeSection;
}
