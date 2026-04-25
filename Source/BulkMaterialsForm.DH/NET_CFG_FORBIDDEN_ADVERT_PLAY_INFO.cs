// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_FORBIDDEN_ADVERT_PLAY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_FORBIDDEN_ADVERT_PLAY_INFO
{
	public bool bEnable;

	public NET_TIME_EX1 stuBeginTime;

	public NET_TIME_EX1 stuEndTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] reserved;
}
