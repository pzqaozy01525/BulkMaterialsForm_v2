// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_INTELLIGENT_CITY_MANAGER_FILTER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_INTELLIGENT_CITY_MANAGER_FILTER
{
	public NET_INTELLIGENT_CITY_MANAGER_EVENT_FILTER stuEventFilter;

	public NET_INTELLIGENT_CITY_MANAGER_PLATENO_FILTER stuPlateNoFilter;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
	public byte[] byReserved;
}
