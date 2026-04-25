// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_LINKGROUP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_LINKGROUP_INFO
{
	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupID;

	public byte bySimilarity;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved1;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szColorName;

	public bool bShowTitle;

	public bool bShowPlate;

	public NET_ALARM_MSG_HANDLE stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] bReserved;
}
