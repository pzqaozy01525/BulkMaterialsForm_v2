// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_DISK_RECORD_TIME

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_DISK_RECORD_TIME
{
	public NET_TIME stuStartTime1;

	public NET_TIME stuEndTime1;

	public bool bTwoPart;

	public NET_TIME stuStartTime2;

	public NET_TIME stuEndTime2;

	public byte bDiskNum;

	public byte bSubareaNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 62)]
	public byte[] byReserved;
}
