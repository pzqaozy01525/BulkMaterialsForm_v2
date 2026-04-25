// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SMART_MOTION_DETECT_OBJECT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SMART_MOTION_DETECT_OBJECT
{
	public bool bHuman;

	public bool bVehicle;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
