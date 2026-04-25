// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PASSERBY_DB_DUPLICATE_REMOVE_CONFIG_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PASSERBY_DB_DUPLICATE_REMOVE_CONFIG_INFO
{
	public bool bEnable;

	public EM_PASSERBY_DB_DUPLICATE_REMOVE_TYPE emDuplicateRemoveType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_TSECT_ARRAY[] stuTimeSections;

	public uint dwInterval;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
