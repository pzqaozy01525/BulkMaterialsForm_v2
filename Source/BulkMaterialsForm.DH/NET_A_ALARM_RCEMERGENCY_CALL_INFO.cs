// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_RCEMERGENCY_CALL_INFO

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_RCEMERGENCY_CALL_INFO
{
	public uint dwSize;

	public int nAction;

	public EM_RCEMERGENCY_CALL_TYPE emType;

	public NET_TIME stuTime;

	public EM_RCEMERGENCY_MODE_TYPE emMode;

	public uint dwID;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
