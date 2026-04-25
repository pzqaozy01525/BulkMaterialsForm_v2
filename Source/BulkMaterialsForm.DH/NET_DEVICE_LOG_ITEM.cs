// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEVICE_LOG_ITEM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEVICE_LOG_ITEM
{
	public int nLogType;

	public NETDEVTIME stuOperateTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szOperator;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved;

	public byte bUnionType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szLogContext;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] reserved;
}
