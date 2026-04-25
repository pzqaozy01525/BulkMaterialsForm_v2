// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CFG_CAP_ACCESSCONTROL

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CFG_CAP_ACCESSCONTROL
{
	public int nAccessControlGroups;

	public bool bSupAccessControlAlarmRecord;

	public EM_CUSTOM_PASSWORD_ENCRYPTION_MODE emCustomPasswordEncryption;

	public EM_SUPPORTFINGERPRINT emSupportFingerPrint;

	public bool bOnlySingleDoorAuth;

	public bool bAsynAuth;

	public NET_SPECIAL_DAYS_SCHEDULE stSpecialDaysSchedule;

	public bool bSupportMultiUserMultiTypeAuth;

	public EM_SUPPORT_FAST_IMPORT_TYPE bSupportFastImport;

	public EM_SUPPORT_FAST_CHECK_TYPE bSupportFastCheck;

	public bool bSupportCallLift;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_SUPPORT_LIFT_CONTROL_TYPES[] emSupportLiftControlTypes;

	public int nSupportLiftControlTypesNum;

	public bool bSupportESD;

	public bool bSupportSpecialDaysAlwaysOpenOrClose;
}
