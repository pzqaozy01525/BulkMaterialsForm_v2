// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PUSH_ANALYSE_PICTURE_FILE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PUSH_ANALYSE_PICTURE_FILE
{
	public uint dwSize;

	public uint nTaskID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_PUSH_PICTURE_INFO[] stuPushPicInfos;

	public uint nPicNum;

	public uint nBinBufLen;

	public IntPtr pBinBuf;
}
