// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ALARMIN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct NET_CFG_ALARMIN_INFO
{
	public int nChannelID;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szChnName;

	public int nAlarmType;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;

	public bool abDevID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDevID;

	public int nPole;

	public EM_SENSE_METHOD emSense;

	public EM_CTRL_ENABLE emCtrl;

	public int nDisDelay;

	public EM_CFG_DEFENCEAREATYPE emDefenceAreaType;

	public int nEnableDelay;

	public int nSlot;

	public int nLevel1;

	public byte abLevel2;

	public int nLevel2;

	public int nDoorNotClosedTimeout;
}
