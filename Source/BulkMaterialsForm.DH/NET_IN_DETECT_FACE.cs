// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_DETECT_FACE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_DETECT_FACE
{
	public uint dwSize;

	public NET_PIC_INFO stPicInfo;

	public IntPtr pBuffer;

	public int nBufferLen;
}
