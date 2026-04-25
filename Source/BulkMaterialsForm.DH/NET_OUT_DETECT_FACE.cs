// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_DETECT_FACE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_DETECT_FACE
{
	public uint dwSize;

	public IntPtr pPicInfo;

	public int nMaxPicNum;

	public int nRetPicNum;

	public IntPtr pBuffer;

	public int nBufferLen;
}
