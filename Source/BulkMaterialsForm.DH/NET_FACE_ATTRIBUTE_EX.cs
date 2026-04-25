// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_ATTRIBUTE_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_ATTRIBUTE_EX
{
	public EM_SEX_TYPE emSex;

	public int nAge;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved;

	public EM_EYE_STATE_TYPE emEye;

	public EM_MOUTH_STATE_TYPE emMouth;

	public EM_MASK_STATE_TYPE emMask;

	public EM_BEARD_STATE_TYPE emBeard;

	public int nAttractive;

	public EM_HAS_GLASS emGlass;

	public EM_EMOTION_TYPE emEmotion;

	public NET_RECT stuBoundingBox;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public EM_STRABISMUS_TYPE emStrabismus;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public int[] nAngle;

	public NET_POINT stuObjCenter;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public byte[] byReserved;
}
