// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_TRAFFIC_RADAR_GET_OBJECT_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_TRAFFIC_RADAR_GET_OBJECT_INFO
{
	public uint dwSize;

	public uint nMaxObjectNum;

	public IntPtr pObjectInfo;

	public uint nObjectNum;
}
