// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CUSTOM_PROJECTS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CUSTOM_PROJECTS_INFO
{
	public NET_GPS_INFO stuGPSInfo;

	public NET_FACECOMPARISON_PTZ_INFO stuFaceComparisonPTZInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPlateNumber;

	public bool bIsAlarm;

	public int nStayEvent;

	public int nWanderEvent;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1012)]
	public byte[] byReserved;
}
