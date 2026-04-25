// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_MANUAL_SNAP

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_MANUAL_SNAP
{
	public uint dwSize;

	public uint nMaxBufLen;

	public IntPtr pRcvBuf;

	public uint nRetBufLen;

	public EM_SNAP_ENCODE_TYPE emEncodeType;

	public uint nCmdSerial;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved;
}
