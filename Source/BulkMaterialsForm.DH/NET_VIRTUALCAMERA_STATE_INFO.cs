// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VIRTUALCAMERA_STATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VIRTUALCAMERA_STATE_INFO
{
	public uint nStructSize;

	public int nChannelID;

	public EM_CONNECT_STATE emConnectState;

	public uint uiPOEPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDeviceName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSystemType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szSerialNo;

	public int nVideoInput;

	public int nAudioInput;

	public int nAlarmOutput;
}
