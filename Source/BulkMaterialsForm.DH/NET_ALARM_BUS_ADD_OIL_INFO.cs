// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_BUS_ADD_OIL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_BUS_ADD_OIL_INFO
{
	public int nAction;

	public bool bNeedConfirm;

	public uint nTime;

	public NET_TIME stuTime;

	public EM_EVENT_DATA_TYPE emDataType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
	public string szCarNo;

	public uint nAddOilVolume;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szReserved;
}
