// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADIOMETRYINFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADIOMETRYINFO
{
	public int nMeterType;

	public int nTemperUnit;

	public float fTemperAver;

	public float fTemperMax;

	public float fTemperMin;

	public float fTemperMid;

	public float fTemperStd;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] reserved;
}
