// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_AREA_MODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_AREA_MODE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szParkNo;

	public uint nCount;

	public EM_SPACE_TYPE emSpaceTyp;

	public int nRemainCnt;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
	public byte[] byReserved;
}
