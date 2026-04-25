// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_AREAARM_MODECHANGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_AREAARM_MODECHANGE_INFO
{
	public int nAreaIndex;

	public int nEventID;

	public NET_TIME_EX UTC;

	public EM_AREAARM_TRIGGERMODE emTriggerMode;

	public EM_AREAARM_USER emUser;

	public uint nID;

	public EM_ARM_STATE emArmState;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
