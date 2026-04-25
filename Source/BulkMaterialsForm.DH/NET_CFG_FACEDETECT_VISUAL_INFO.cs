// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_FACEDETECT_VISUAL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_FACEDETECT_VISUAL_INFO
{
	public uint nFaceAngleUp;

	public uint nFaceAngleRight;

	public uint nFaceRollRight;

	public bool bTempOptimization;

	public bool bEyesWidthDetection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1016)]
	public byte[] byReserved;
}
