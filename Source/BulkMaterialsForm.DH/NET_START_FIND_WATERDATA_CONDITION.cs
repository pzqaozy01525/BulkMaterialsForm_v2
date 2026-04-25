// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_START_FIND_WATERDATA_CONDITION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_START_FIND_WATERDATA_CONDITION
{
	public NET_TIME_EX stuStartTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_WATER_DETECTION_ALARM_TYPE[] emType;

	public int nTypeNum;

	public int nPresetIDNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nPresetID;

	public NET_TIME_EX stuEndTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
