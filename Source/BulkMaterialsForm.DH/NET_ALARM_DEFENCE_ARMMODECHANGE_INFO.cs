// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_DEFENCE_ARMMODECHANGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_DEFENCE_ARMMODECHANGE_INFO
{
	public EM_DEFENCEMODE emDefenceStatus;

	public int nDefenceID;

	public NET_TIME_EX stuTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] reserved;
}
