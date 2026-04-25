// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_LINKGROUP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_LINKGROUP_INFO
{
	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupID;

	public byte bySimilarity;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szColorName;

	public bool bShowTitle;

	public bool bShowPlate;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 511)]
	public byte[] bReserved;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;
}
