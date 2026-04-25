// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CLIENT_ALARM_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CLIENT_ALARM_STATE
{
	public uint dwSize;

	public int alarminputcount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public uint[] dwAlarmState;
}
