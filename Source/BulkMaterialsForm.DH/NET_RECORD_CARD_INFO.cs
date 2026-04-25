// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORD_CARD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RECORD_CARD_INFO
{
	public uint dwSize;

	public int nType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szCardNo;

	public EM_ATM_TRADE_TYPE emTradeType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szAmount;

	public int nError;

	public int nFieldCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
	public byte[] szFields;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szChange;
}
