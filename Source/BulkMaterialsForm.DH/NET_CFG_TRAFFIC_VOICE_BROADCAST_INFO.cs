// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TRAFFIC_VOICE_BROADCAST_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TRAFFIC_VOICE_BROADCAST_INFO
{
	public uint dwSize;

	public int nEnableCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public EM_PLATEENABLE_TYPE[] emEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szNormalCar;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szTrustCar;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szSuspiciousCar;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_TRAFFIC_VOICE_BROADCAST_ELEMENT[] stuElement;

	public int nElementNum;
}
