// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_STORAGEPOINT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_STORAGEPOINT_INFO
{
	public uint dwSize;

	public EM_STORAGEPOINT_TYPE emStoragePointType;

	public sbyte nLocalDir;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szCompressDir;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szRedundantDir;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szRemoteDir;

	public bool bAutoSync;

	public uint nAutoSyncRange;

	public bool bLocalEmergency;

	public uint nCompressBefore;
}
