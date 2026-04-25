// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_FACE_RECOGNITION_DETECT_MULTI_FACE_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_FACE_RECOGNITION_DETECT_MULTI_FACE_INFO
{
	public uint dwSize;

	public int nBigPicNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_DETECT_BIG_PIC_INFO[] stuBigPicInfo;

	public IntPtr pBuffer;

	public int nBufferLen;

	public EM_OBJECT_TYPE emDetectObjType;

	public bool bBigPicInfoExEnable;

	public int nBigPicNumEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_DETECT_BIG_PIC_INFO_EX[] stuBigPicInfoEx;

	public uint nToken;
}
