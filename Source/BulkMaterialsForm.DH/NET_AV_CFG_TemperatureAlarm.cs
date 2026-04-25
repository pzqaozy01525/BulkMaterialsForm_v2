// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_AV_CFG_TemperatureAlarm

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_AV_CFG_TemperatureAlarm
{
	public int nStructSize;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public float fNormalTempMin;

	public float fNormalTempMax;

	public NET_AV_CFG_EventHandler stuEventHandler;
}
