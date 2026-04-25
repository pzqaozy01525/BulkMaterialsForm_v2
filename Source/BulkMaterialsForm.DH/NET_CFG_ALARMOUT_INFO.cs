// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ALARMOUT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ALARMOUT_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szChnName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szOutputType;

	public int nOutputMode;

	public int nPulseDelay;

	public int nSlot;

	public int nLevel1;

	public byte abLevel2;

	public int nLevel2;

	public EM_ALARMOUT_POLE emPole;
}
