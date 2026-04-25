// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DATA_CALL_BACK_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_DATA_CALL_BACK_INFO
{
	public uint dwSize;

	public uint dwDataType;

	public IntPtr pBuffer;

	public uint dwBufSize;

	public NET_DATA_CALL_BACK_TIME stuTime;

	public EM_DATA_CALL_BACK_FRAM_TYPE emFramType;

	public EM_DATA_CALL_BACK_FRAM_SUB_TYPE emFramSubType;
}
