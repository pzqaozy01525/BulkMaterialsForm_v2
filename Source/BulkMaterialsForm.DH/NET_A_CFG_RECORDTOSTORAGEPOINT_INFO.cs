// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_RECORDTOSTORAGEPOINT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_RECORDTOSTORAGEPOINT_INFO
{
	public int nStoragePointNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_A_CFG_STORAGEPOINT_INFO[] stStoragePoints;
}
