// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_RADAR_RADARLINKDEVICE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_RADAR_RADARLINKDEVICE_INFO
{
	public uint dwSize;

	public int nDevNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public NET_RADARLINKDEVICE_INFO[] stuDevInfo;
}
