// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IMAGE_RELATION_EX

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IMAGE_RELATION_EX
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRequestID;

	public int nBigPicId;

	public int nSmallPicNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_SMALL_PIC_INFO[] stuSmallPicInfo;

	public EM_MULTIFACE_DETECT_ERRCODE emDetectErrCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_RELATION_LIST[] stuImageRelation;

	public int nstuImageRelationNum;

	public uint nToken;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_RELATION_EX_IMAGEINFO[] stuImageInfo;

	public int nImageNum;

	public IntPtr pData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 248)]
	public byte[] bReserved;
}
