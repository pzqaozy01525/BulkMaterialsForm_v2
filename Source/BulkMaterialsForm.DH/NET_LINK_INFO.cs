// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_LINK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_LINK_INFO
{
	public uint nLinkObjectID;

	public uint nLinkEventID;

	public uint nSpeedValue;

	public uint nAlarmType;

	public uint nLongitude;

	public uint nLatitude;

	public uint nDistance;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szObjectType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 212)]
	public string szResvered;
}
