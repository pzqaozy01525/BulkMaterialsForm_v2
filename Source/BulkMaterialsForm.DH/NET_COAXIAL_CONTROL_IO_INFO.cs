// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_COAXIAL_CONTROL_IO_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_COAXIAL_CONTROL_IO_INFO
{
	public EM_COAXIAL_CONTROL_IO_TYPE emType;

	public EM_COAXIAL_CONTROL_IO_SWITCH emSwicth;

	public EM_COAXIAL_CONTROL_IO_TRIGGER_MODE emMode;

	public EM_COAXIAL_CONTROL_IO_LIGHT_MODE emLightMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
	public byte[] byReserved;
}
