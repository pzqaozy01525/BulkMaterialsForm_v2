// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_RECORD_CHANGED_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_RECORD_CHANGED_INFO_EX
{
	public int nAction;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szStoragePoint;

	public EM_STREAM_TYPE emStreamType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUser;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 828)]
	public byte[] byReserved;
}
