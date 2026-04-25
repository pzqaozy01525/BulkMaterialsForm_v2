// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_STRANGERMODE_INFO_NEW

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_STRANGERMODE_INFO_NEW
{
	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szColorHex;

	public bool bShowTitle;

	public bool bShowPlate;

	public NET_ALARM_MSG_HANDLE stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] bReserved;
}
