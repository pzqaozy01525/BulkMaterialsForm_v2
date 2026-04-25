// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_STRANGERMODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_STRANGERMODE_INFO
{
	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szColorHex;

	public bool bShowTitle;

	public bool bShowPlate;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] bReserved;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;
}
