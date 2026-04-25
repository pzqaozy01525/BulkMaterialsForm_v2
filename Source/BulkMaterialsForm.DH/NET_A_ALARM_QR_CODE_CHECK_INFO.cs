// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_QR_CODE_CHECK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_QR_CODE_CHECK_INFO
{
	public int nEventID;

	public NET_TIME_EX UTC;

	public double dbPTS;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szQRCode;

	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
