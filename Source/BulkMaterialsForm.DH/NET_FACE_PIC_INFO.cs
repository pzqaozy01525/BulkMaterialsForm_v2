// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_PIC_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_PIC_INFO
{
	public uint dwOffSet;

	public uint dwFileLenth;

	public uint dwWidth;

	public uint dwHeight;

	public bool bIsDetected;

	public int nFilePathLen;

	public IntPtr pszFilePath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPictureID;

	public EM_PERSON_FEATURE_STATE emFeatureState;

	public EM_PERSON_FEATURE_ERRCODE emFeatureErrCode;

	public EM_PIC_OPERATE_TYPE emPicOperate;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public byte[] bReserved;
}
