// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_SPACE_MODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_SPACE_MODE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szParkNo;

	public NET_CFG_POLYGON stuCoordinate;

	public int nSpaceType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
	public string szReserved;
}
