// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MOTION_DETECT_WINDOW

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MOTION_DETECT_WINDOW
{
	public uint nThreshold;

	public uint nSensitive;

	public int nMotionRow;

	public int nMotionCol;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] nRegion;

	public int nId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szResvered;
}
