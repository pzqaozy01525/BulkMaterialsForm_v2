// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_ACCESS_CARD_SERVICE_UPDATE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_ACCESS_CARD_SERVICE_UPDATE
{
	public uint dwSize;

	public int nMaxRetNum;

	public IntPtr pFailCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;
}
