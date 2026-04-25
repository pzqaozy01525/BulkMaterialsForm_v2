// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_RADAR_DEL_RADARLINKSD

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_RADAR_DEL_RADARLINKSD
{
	public uint dwSize;

	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public NET_RADARLINKDEVICE_DEL_INFO[] stuDevices;

	public int nDevicesNum;
}
