// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_UPLOAD_CLIENT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_UPLOAD_CLIENT_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szClientID;

	public EM_UPLOAD_FLAG emUploadFlag;

	public NET_TIME stuUploadTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] byReserved;
}
