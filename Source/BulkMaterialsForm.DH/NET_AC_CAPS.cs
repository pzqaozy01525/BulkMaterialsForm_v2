// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_AC_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_AC_CAPS
{
	public int nChannels;

	public bool bSupAccessControlAlarmRecord;

	public int nCustomPasswordEncryption;

	public int nSupportFingerPrint;

	public bool bHasCardAuth;

	public bool bHasFaceAuth;

	public bool bOnlySingleDoorAuth;

	public bool bAsynAuth;

	public bool bUserlsoLate;

	public int nMaxInsertRate;

	public NET_SPECIAL_DAYS_SCHEDULE_CAPS stuSpecialDaysSchedule;

	public int nUnlockModes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public EM_AC_UNLOCK_MODE[] emUnlockModes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
