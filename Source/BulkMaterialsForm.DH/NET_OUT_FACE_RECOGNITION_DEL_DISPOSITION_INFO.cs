// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_FACE_RECOGNITION_DEL_DISPOSITION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_FACE_RECOGNITION_DEL_DISPOSITION_INFO
{
	public uint dwSize;

	public int nReportCnt;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public bool[] bReport;
}
