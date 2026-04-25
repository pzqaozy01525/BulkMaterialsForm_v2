// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_FACEDETECTION_SCENCE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_FACEDETECTION_SCENCE_INFO
{
	public double dbCameraHeight;

	public double dbCameraDistance;

	public int nMainDirection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYGON[] stuMainDirection;

	public byte byFaceAngleDown;

	public byte byFaceAngleUp;

	public byte byFaceAngleLeft;

	public byte byFaceAngleRight;

	public EM_FACEDETECTION_TYPE emDetectType;
}
