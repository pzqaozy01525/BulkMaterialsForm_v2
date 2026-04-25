// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_FACE_RECOGNITION_PUT_DISPOSITION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_FACE_RECOGNITION_PUT_DISPOSITION_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupId;

	public int nDispositionChnNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public NET_DISPOSITION_CHANNEL_INFO[] stuDispositionChnInfo;
}
