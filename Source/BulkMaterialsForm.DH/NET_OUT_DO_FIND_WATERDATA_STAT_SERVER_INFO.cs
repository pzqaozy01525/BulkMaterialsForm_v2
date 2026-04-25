// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_DO_FIND_WATERDATA_STAT_SERVER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_DO_FIND_WATERDATA_STAT_SERVER_INFO
{
	public uint dwSize;

	public uint nFound;

	public int nInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_WATERDATA_STAT_SERVER_INFO[] stuInfo;
}
