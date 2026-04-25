// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_OPERATE_TRAFFIC_LIST_RECORD

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_OPERATE_TRAFFIC_LIST_RECORD
{
	public uint dwSize;

	public EM_RECORD_OPERATE_TYPE emOperateType;

	public EM_NET_RECORD_TYPE emRecordType;

	public IntPtr pstOpreateInfo;
}
