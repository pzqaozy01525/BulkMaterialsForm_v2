// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_FRONTDISCONNET_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_FRONTDISCONNET_INFO
{
	public uint dwSize;

	public int nChannelID;

	public int nAction;

	public NET_TIME stuTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	public byte[] szIpAddress;

	public NET_GPS_STATUS_INFO stGPSStatus;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
