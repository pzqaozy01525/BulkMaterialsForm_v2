// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CLIENT_ALARM_CHANNELS_STATE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_CLIENT_ALARM_CHANNELS_STATE
{
	public uint dwSize;

	public EM_ALARM_CHANNEL_TYPE emType;

	public int nAlarmInCount;

	public int nAlarmInRetCount;

	public IntPtr pbAlarmInState;

	public int nAlarmOutCount;

	public int nAlarmOutRetCount;

	public IntPtr pbAlarmOutState;

	public int nAlarmBellCount;

	public int nAlarmBellRetCount;

	public IntPtr pbAlarmBellState;

	public int nExAlarmInCount;

	public int nExAlarmInRetCount;

	public IntPtr pbExAlarmInState;

	public IntPtr pnExAlarmInDestionation;

	public int nExAlarmOutCount;

	public int nExAlarmOutRetCount;

	public IntPtr pbExAlarmOutState;

	public IntPtr pnExAlarmOutDestionation;
}
