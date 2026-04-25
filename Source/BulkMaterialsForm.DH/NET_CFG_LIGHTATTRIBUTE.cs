// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_LIGHTATTRIBUTE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_LIGHTATTRIBUTE
{
	public bool bEnable;

	public int nTypeNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szLightType;

	public int nDirectionNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szDirection;

	public int nYellowTime;
}
