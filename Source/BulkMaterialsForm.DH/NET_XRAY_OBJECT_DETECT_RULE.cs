// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_XRAY_OBJECT_DETECT_RULE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_XRAY_OBJECT_DETECT_RULE
{
	public EM_INSIDE_OBJECT_TYPE emObjectType;

	public bool bDetectEnable;

	public EM_DANGER_GRADE_TYPE emDangerGrade;

	public NET_XRAY_OBJECT_UPLOAD_RULE stuUploadRuleInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
