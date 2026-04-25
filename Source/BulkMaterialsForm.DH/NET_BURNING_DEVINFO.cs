// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BURNING_DEVINFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BURNING_DEVINFO
{
	public uint dwDevNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_DEV_BURNING[] stDevs;
}
