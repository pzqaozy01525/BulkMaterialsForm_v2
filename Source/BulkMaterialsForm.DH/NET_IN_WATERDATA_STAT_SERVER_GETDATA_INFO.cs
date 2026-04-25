// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_WATERDATA_STAT_SERVER_GETDATA_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_WATERDATA_STAT_SERVER_GETDATA_INFO
{
	public uint dwSize;

	public int nTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_WATER_DETECTION_ALARM_TYPE[] emType;
}
