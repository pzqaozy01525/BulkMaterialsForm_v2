// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PUSH_ANALYSE_PICTURE_FILE_BYRULE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PUSH_ANALYSE_PICTURE_FILE_BYRULE
{
	public uint dwSize;

	public uint nTaskID;

	public IntPtr pstuPushPicByRuleInfos;

	public uint nPicNum;

	public uint nBinBufLen;

	public IntPtr pBinBuf;
}
