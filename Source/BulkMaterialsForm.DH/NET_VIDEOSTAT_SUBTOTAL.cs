// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VIDEOSTAT_SUBTOTAL

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VIDEOSTAT_SUBTOTAL
{
	public int nTotal;

	public int nHour;

	public int nToday;

	public int nOSD;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
	public byte[] reserved;
}
