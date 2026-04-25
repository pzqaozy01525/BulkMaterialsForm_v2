// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_START_QUERYLOG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_START_QUERYLOG
{
	public uint dwSize;

	public EM_LOG_QUERY_TYPE emLogType;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public bool bLogTypeExFlag;

	public int nLogTypeExNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8192)]
	public string szLogTypeEx;

	public EM_RESULT_ORDER_TYPE emResultOrder;
}
