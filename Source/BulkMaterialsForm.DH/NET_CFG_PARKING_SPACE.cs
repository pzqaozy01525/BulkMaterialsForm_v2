// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PARKING_SPACE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PARKING_SPACE
{
	public int nNumber;

	public NET_CFG_REGION stArea;

	public int nShieldAreaNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_CFG_REGION[] stShieldArea;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCustomParkNo;
}
