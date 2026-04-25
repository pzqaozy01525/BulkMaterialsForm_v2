// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TRAFFIC_LATTICE_SCREEN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TRAFFIC_LATTICE_SCREEN_INFO
{
	public uint dwSize;

	public int nStatusChangeTime;

	public NET_TRAFFIC_LATTICE_SCREEN_SHOW_INFO stuNormal;

	public NET_TRAFFIC_LATTICE_SCREEN_SHOW_INFO stuCarPass;

	public EM_A_NET_EM_LATTICE_SCREEN_SHOW_TYPE emShowType;

	public EM_A_NET_EM_LATTICE_SCREEN_CONTROL_TYPE emControlType;

	public EM_A_NET_EM_LATTICE_SCREEN_BACKGROUND_MODE emBackgroundMode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 640)]
	public string szPlayList;

	public int nPlayListNum;

	public NET_TRAFFIC_LATTICE_SCREEN_LOGO_INFO stuLogoInfo;

	public NET_TRAFFIC_LATTICE_SCREEN_ALARM_NOTICE_INFO stuAlarmNoticeInfo;
}
