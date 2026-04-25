// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_SCADA_GET_ATTRIBUTE_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_SCADA_GET_ATTRIBUTE_INFO
{
	public uint dwSize;

	public uint nMaxAttributeInfoNum;

	public IntPtr pstuAttributeInfo;

	public uint nRetAttributeInfoNum;
}
