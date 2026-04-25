// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DELETE_CAMERA_GROUP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DELETE_CAMERA_GROUP_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;

	public int nUniqueChannelNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public int[] szUniqueChannels;
}
