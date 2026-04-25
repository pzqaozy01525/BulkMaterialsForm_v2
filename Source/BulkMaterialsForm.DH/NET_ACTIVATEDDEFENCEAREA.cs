// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACTIVATEDDEFENCEAREA

using System;

namespace BulkMaterialsForm.DH;

public struct NET_ACTIVATEDDEFENCEAREA
{
	public uint dwSize;

	public int nAlarmInCount;

	public int nRetAlarmInCount;

	public IntPtr pstuAlarmInDefenceAreaInfo;

	public int nExAlarmInCount;

	public int nRetExAlarmInCount;

	public IntPtr pstuExAlarmInDefenceAreaInfo;
}
