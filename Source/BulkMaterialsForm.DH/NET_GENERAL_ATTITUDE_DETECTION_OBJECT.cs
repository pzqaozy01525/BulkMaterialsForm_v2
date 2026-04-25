// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_GENERAL_ATTITUDE_DETECTION_OBJECT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_GENERAL_ATTITUDE_DETECTION_OBJECT
{
	public int nObjectID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szObjectType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szAttitudeType;

	public NET_RECT BoundingBox;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 22)]
	public string szSerialUUID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1022)]
	public string szReserved;
}
