// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_REGION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_REGION
{
	public int nPointNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYGON[] stuPolygon;
}
