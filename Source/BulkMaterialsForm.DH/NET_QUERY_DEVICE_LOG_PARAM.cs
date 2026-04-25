// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_QUERY_DEVICE_LOG_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_QUERY_DEVICE_LOG_PARAM
{
	public EM_LOG_QUERY_TYPE emLogType;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public int nStartNum;

	public int nEndNum;

	public byte nLogStuType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] reserved;

	public uint nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	public byte[] bReserved;
}
