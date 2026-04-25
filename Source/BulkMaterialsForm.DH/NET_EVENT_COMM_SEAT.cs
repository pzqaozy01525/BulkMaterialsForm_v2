// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_COMM_SEAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_COMM_SEAT
{
	public bool bEnable;

	public EM_COMMON_SEAT_TYPE emSeatType;

	public NET_EVENT_COMM_STATUS stStatus;

	public EM_NET_SAFEBELT_STATE emSafeBeltStatus;

	public EM_NET_SUNSHADE_STATE emSunShadeStatus;

	public EM_CALL_ACTION_TYPE emCallAction;

	public uint nSafeBeltConf;

	public uint nPhoneConf;

	public uint nSmokeConf;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szReserved;
}
