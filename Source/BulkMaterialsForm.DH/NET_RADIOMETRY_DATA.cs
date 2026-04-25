// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADIOMETRY_DATA

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADIOMETRY_DATA
{
	public NET_RADIOMETRY_METADATA stMetaData;

	public IntPtr pbDataBuf;

	public uint dwBufSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] reserved;
}
