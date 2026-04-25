// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_RECORD_DATA

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_RECORD_DATA
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
	public byte[] byFaceData;
}
