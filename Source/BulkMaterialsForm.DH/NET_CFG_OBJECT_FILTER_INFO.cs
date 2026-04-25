// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_OBJECT_FILTER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_OBJECT_FILTER_INFO
{
	public uint nObjectFilterTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public EM_CFG_OBJECT_FILTER_TYPE[] emObjectFilterType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
