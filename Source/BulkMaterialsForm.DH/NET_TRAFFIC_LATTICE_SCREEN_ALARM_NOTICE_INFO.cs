// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFIC_LATTICE_SCREEN_ALARM_NOTICE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFIC_LATTICE_SCREEN_ALARM_NOTICE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szNoHelmet;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szNonMotorOverload;
}
