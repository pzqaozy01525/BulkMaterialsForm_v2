// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCADA_NOTIFY_POINT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SCADA_NOTIFY_POINT_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDevName;

	public EM_NET_SCADA_POINT_TYPE emPointType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPointName;

	public float fValue;

	public int nValue;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szFSUID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSensorID;

	public NET_TIME_EX stuCollectTime;
}
