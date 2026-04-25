// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PROFILE_ALARM_TRANSMIT_ALARM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PROFILE_ALARM_TRANSMIT_ALARM_INFO
{
	public NET_PROFILE_ALARM_TRANSMIT_LOWERPOWER stuLowerPower;

	public NET_PROFILE_ALARM_TRANSMIT_ALARMIN stuAlarmIn;

	public NET_PROFILE_ALARM_TRANSMIT_CLOUDINFO stuCloudInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szReserved;
}
