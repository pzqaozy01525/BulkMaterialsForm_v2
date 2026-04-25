// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_RADAR_ADD_RADARLINKSD

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_RADAR_ADD_RADARLINKSD
{
	public uint dwSize;

	public int nRetResultNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public NET_RADARLINKDEVICE_ADD_RESULT[] stuAddResult;
}
