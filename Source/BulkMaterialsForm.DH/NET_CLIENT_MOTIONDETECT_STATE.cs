// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CLIENT_MOTIONDETECT_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CLIENT_MOTIONDETECT_STATE
{
	public uint dwSize;

	public int channelcount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public uint[] dwAlarmState;
}
