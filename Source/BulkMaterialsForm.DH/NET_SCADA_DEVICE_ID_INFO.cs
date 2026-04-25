// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCADA_DEVICE_ID_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SCADA_DEVICE_ID_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDeviceID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDevName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] reserve;
}
