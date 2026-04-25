// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_WATERDATA_STAT_SERVER_GETDATA_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_WATERDATA_STAT_SERVER_GETDATA_INFO
{
	public uint dwSize;

	public EM_WATER_QUALITY emQuality;

	public NET_WATER_DETECTION_UPLOAD_INFO stuUploadInfo;

	public int nFlunkTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_WATER_DETECTION_ALARM_TYPE[] emFlunkType;
}
