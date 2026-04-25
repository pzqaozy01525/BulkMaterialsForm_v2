// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_STORAGE_NOT_EXIST_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_STORAGE_NOT_EXIST_INFO
{
	public uint dwSize;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szGroup;

	public NET_TIME stTime;

	public NET_GPS_STATUS_INFO stGPSStatus;
}
