// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFICCAR_ORIGINAL_VEHICLE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFICCAR_ORIGINAL_VEHICLE
{
	public uint nOffset;

	public uint nLength;

	public uint nIndexInData;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
	public string szReserved;
}
