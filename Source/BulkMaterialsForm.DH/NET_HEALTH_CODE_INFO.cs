// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HEALTH_CODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HEALTH_CODE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCitizenID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCitizenName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPermanentAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCurrentAddr;

	public EM_HEALTH_CODE_STATUS emHealthCodeStatus;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPhoneNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szAbnormalCodeReason;

	public NET_TIME stuQueryTime;

	public int nEpidemicAreaExperience;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_EPIDEMIC_AREA_EXPERIENCE[] stuEpidemicAreaExperience;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
