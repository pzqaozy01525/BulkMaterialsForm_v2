// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_BATCH_APPEND_FACERECONGNITION

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_BATCH_APPEND_FACERECONGNITION
{
	public uint dwSize;

	public uint nPersonNum;

	public IntPtr pstPersonInfo;

	public IntPtr pBuffer;

	public uint nBufferLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved;

	public NET_MULTI_APPEND_EXTENDED_INFO stuInfo;
}
