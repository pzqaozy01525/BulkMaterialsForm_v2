// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SET_PARKING_SPACE_LIGHT_PLAN

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SET_PARKING_SPACE_LIGHT_PLAN
{
	public uint dwSize;

	public int nPhysicalLane;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCustomParkNo;

	public int nLightPlanNum;

	public IntPtr pstuLightPlan;
}
