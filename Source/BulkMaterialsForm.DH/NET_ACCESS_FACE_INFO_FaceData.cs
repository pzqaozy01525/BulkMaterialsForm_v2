// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESS_FACE_INFO_FaceData

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESS_FACE_INFO_FaceData
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string faceData;
}
