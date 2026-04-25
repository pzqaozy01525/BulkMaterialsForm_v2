// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_XRAY_DETECT_BYPBJECT_RULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_XRAY_DETECT_BYPBJECT_RULE_INFO
{
	public uint dwSize;

	public int nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINTCOORDINATE[] stuDetectRegion;

	public uint nSensitivity;

	public EM_DETECT_DIRECTION_TYPE emDirectionType;

	public EM_XRAY_SCHEME_TYPE emSchemeType;

	public uint nObjectRuleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_XRAY_OBJECT_DETECT_RULE[] stuObjectRuleInfo;

	public EM_XRAY_VIEW_TYPE emViewType;
}
