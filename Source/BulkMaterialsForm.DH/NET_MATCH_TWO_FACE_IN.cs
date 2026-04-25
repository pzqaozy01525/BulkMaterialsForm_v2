// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MATCH_TWO_FACE_IN

using System;

namespace BulkMaterialsForm.DH;

public struct NET_MATCH_TWO_FACE_IN
{
	public uint dwSize;

	public NET_IMAGE_COMPARE_INFO stuOriginalImage;

	public NET_IMAGE_COMPARE_INFO stuCompareImage;

	public IntPtr pSendBuf;

	public uint dwSendBufLen;
}
