// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFIC_CONSTATE_LAMP_CONFIG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFIC_CONSTATE_LAMP_CONFIG
{
	public uint nLightMask;

	public uint nBrightness;

	public uint nPreValue;

	public EM_LAMP_WORK_MODE emLampMode;

	public EM_LAMP_AUTO_TYPE emAutoMode;

	public NET_CFG_TIME_SCHEDULE stuTimeSchedule;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
