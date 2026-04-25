// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_CONTROL_COAXIAL_CONTROL_IO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_CONTROL_COAXIAL_CONTROL_IO
{
	public uint dwSize;

	public int nChannel;

	public int nInfoCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_COAXIAL_CONTROL_IO_INFO[] stInfo;
}
