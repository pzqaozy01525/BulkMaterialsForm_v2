// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_IVS_PERSON_TRANS_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_IVS_PERSON_TRANS_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szClass;

	public int nGroupID;

	public int nCountInGroup;

	public int nIndexInGroup;

	public uint nUTCMS;

	public double dPTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public int nViolationNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 320)]
	public sbyte[] szViolation;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
