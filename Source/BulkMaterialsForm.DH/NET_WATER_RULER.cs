// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WATER_RULER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WATER_RULER
{
	public NET_EM_WATER_RULER_COLOR emRulerColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRulerNum;

	public float fWaterLevel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
