// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_AREAALARM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_AREAALARM_INFO
{
	public int nAreaIndex;

	public int nEventID;

	public NET_TIME_EX UTC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public EM_DEFENCE_AREA_TYPE emDefenceAreaType;

	public int nIndex;

	public EM_AREAALARM_TRIGGER_TYPE emTrigerType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
