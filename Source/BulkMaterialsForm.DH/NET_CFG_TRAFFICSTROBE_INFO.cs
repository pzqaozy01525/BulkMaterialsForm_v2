// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TRAFFICSTROBE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TRAFFICSTROBE_INFO
{
	public uint dwSize;

	public bool bEnable;

	public int nCtrlTypeCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public EM_CFG_TRAFFICSTROBE_CTRTYPE[] emCtrlType;

	public int nAllSnapCarCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_CFG_ALL_SNAP_CAR[] emAllSnapCar;

	public NET_ALARM_MSG_HANDLE stuEventHandler;

	public NET_ALARM_MSG_HANDLE stuEventHandlerClose;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szOrderIP;

	public EM_CFG_TRAFFICSTROBE_CTRTYPE emCtrlTypeOnDisconnect;

	public NET_CFG_STATIONARY_OPEN stuStationaryOpen;
}
