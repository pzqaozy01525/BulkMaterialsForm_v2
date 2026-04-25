// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_SMART_VALUE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_SMART_VALUE
{
	public byte byId;

	public byte byCurrent;

	public byte byWorst;

	public byte byThreshold;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szRaw;

	public int nPredict;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] reserved;
}
