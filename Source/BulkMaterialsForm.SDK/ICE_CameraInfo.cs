// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.ICE_CameraInfo

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.SDK;

public struct ICE_CameraInfo
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szAppVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szAlgoVersion;

	public int szIsEnc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szAppTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
