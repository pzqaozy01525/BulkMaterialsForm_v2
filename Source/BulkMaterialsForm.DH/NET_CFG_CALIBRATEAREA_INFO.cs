// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_CALIBRATEAREA_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_CALIBRATEAREA_INFO
{
	public int nLinePoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYGON[] stuLine;

	public float fLenth;

	public NET_CFG_REGION stuArea;

	public int nStaffNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_STAFF[] stuStaffs;

	public EM_CALIBRATEAREA_TYPE emType;

	public EM_METHOD_TYPE emMethodType;
}
