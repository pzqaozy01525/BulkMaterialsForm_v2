// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WATERDATA_STAT_SERVER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WATERDATA_STAT_SERVER_INFO
{
	public NET_TIME_EX stuStartTime;

	public EM_WATER_QUALITY emQuality;

	public NET_WATER_DETECTION_UPLOAD_INFO stuUploadInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
