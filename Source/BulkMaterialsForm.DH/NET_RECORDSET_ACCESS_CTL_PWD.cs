// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORDSET_ACCESS_CTL_PWD

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RECORDSET_ACCESS_CTL_PWD
{
	public uint dwSize;

	public int nRecNo;

	public NET_TIME stuCreateTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szUserID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szDoorOpenPwd;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szAlarmPwd;

	public int nDoorNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] sznDoors;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szVTOPosition;

	public int nTimeSectionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nTimeSectionIndex;

	public bool bNewDoor;

	public int nNewDoorNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] nNewDoors;

	public int nNewTimeSectionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] nNewTimeSectionNo;

	public NET_TIME stuValidStartTime;

	public NET_TIME stuValidEndTime;

	public int nValidCounts;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public byte[] szCitizenIDNo;
}
