// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CFG_CALIBRATE_UNIT_INFO_ARRAY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CFG_CALIBRATE_UNIT_INFO_ARRAY
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public CFG_CALIBRATE_UNIT_INFO[] stuCalibrateUnitInfo;
}
