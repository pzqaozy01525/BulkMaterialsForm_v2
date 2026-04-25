// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_NEW_SOUND_ALARM_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_NEW_SOUND_ALARM_STATE
{
	public int channel;

	public int alarmType;

	public uint volume;

	public byte byState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
	public string reserved;
}
