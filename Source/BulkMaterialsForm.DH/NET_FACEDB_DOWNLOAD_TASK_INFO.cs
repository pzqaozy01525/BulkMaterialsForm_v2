// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACEDB_DOWNLOAD_TASK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACEDB_DOWNLOAD_TASK_INFO
{
	public uint nURLNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szURLList;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szFaceUUID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
	public byte[] byReserved;
}
