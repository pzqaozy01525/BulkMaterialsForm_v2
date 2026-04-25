// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_STORAGE_DEV_INFOS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_STORAGE_DEV_INFOS
{
	public uint dwSize;

	public int nDevInfosNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_A_STORAGE_DEVICE[] stuStoregeDevInfos;
}
