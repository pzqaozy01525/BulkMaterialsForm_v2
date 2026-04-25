// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_ANALYSERULE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_ANALYSERULE
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSDLinkIP;

	public int nAlarmOutNumber;

	public bool bEnable;

	public NET_CFG_ALARM_MSG_HANDLE stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
