// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_FISHEYE_MODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_FISHEYE_MODE_INFO
{
	public int nModeType;

	public int nWindowNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_A_CFG_FISHEYE_WINDOW_INFO[] stuWindwos;
}
