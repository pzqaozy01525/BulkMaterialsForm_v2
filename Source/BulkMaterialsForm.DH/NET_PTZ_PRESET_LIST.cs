// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PTZ_PRESET_LIST

using System;

namespace BulkMaterialsForm.DH;

public struct NET_PTZ_PRESET_LIST
{
	public uint dwSize;

	public uint dwMaxPresetNum;

	public uint dwRetPresetNum;

	public IntPtr pstuPtzPorsetList;
}
