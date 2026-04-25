// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IMAGE_RELATION_LIST

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IMAGE_RELATION_LIST
{
	public IntPtr pszFeature;

	public int nFeatureLen;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szFeatureID;

	public NET_FACE_DATA stuFaceData;

	public NET_HUMAN_ATTRIBUTES_INFO stuHumanAttributes;

	public NET_VA_OBJECT_NONMOTOR stuNonMotor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szAlgorithmVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVendor;

	public EM_OBJECT_TYPE emObjectType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public NET_POINT[] stuRectPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
