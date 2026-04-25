// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ANATOMYTEMP_SCENCE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ANATOMYTEMP_SCENCE_INFO
{
	public EM_CFG_EM_FACEDETECT_TYPE emFaceDetectType;

	public NET_CFG_FACEDETECT_VISUAL_INFO stuVisual;

	public NET_CFG_TIME_SECTION stuTimeSection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
