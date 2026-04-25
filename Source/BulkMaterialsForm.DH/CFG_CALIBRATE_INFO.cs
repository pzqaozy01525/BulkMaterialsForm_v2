// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CFG_CALIBRATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CFG_CALIBRATE_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public CFG_CALIBRATE_UNIT_INFO_ARRAY[] stuCalibrateUnitInfo;

	public int nInfoNum;
}
