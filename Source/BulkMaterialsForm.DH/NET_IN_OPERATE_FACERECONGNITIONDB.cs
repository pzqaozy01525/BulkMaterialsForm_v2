// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_OPERATE_FACERECONGNITIONDB

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_OPERATE_FACERECONGNITIONDB
{
	public uint dwSize;

	public EM_OPERATE_FACERECONGNITIONDB_TYPE emOperateType;

	public NET_FACERECOGNITION_PERSON_INFO stPersonInfo;

	public uint nUIDNum;

	public IntPtr stuUIDs;

	public IntPtr pBuffer;

	public int nBufferLen;

	public bool bUsePersonInfoEx;

	public NET_FACERECOGNITION_PERSON_INFOEX stPersonInfoEx;

	public uint nUUIDNum;

	public IntPtr stuUUIDs;
}
