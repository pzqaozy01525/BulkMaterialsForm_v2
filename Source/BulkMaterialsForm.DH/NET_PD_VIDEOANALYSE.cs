// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PD_VIDEOANALYSE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PD_VIDEOANALYSE
{
	public bool bSupport;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_SUPPROTSCENE[] szSupportScenes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_SUPPORTRULE[] szSupportRules;
}
