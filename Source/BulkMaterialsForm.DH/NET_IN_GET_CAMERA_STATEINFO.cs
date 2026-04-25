// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_GET_CAMERA_STATEINFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_GET_CAMERA_STATEINFO
{
	public uint dwSize;

	public bool bGetAllFlag;

	public int nValidNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public int[] nChannels;
}
