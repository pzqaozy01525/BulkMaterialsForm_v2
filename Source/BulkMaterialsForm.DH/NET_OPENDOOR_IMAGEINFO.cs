// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OPENDOOR_IMAGEINFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OPENDOOR_IMAGEINFO
{
	public int nLibImageLen;

	public int nSnapImageLen;

	public IntPtr pLibImage;

	public IntPtr pSnapImage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
