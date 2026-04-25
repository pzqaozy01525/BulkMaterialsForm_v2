// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ADD_FACEDB_DOWNLOAD_TASK

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ADD_FACEDB_DOWNLOAD_TASK
{
	public uint dwSize;

	public bool bIsEnd;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szFaceDbVersion;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public uint nTaskNum;

	public IntPtr pstTaskInfo;

	public uint nPacketTotal;

	public uint nPacketIndex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupID;
}
