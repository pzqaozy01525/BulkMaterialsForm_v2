// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_ARMMODE_CHANGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_ARMMODE_CHANGE_INFO
{
	public uint dwSize;

	public NET_TIME stuTime;

	public EM_ALARM_MODE bArm;

	public EM_SCENE_MODE emSceneMode;

	public uint dwID;

	public EM_TRIGGER_MODE emTriggerMode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNetClientAddr;

	public uint nUserCode;
}
